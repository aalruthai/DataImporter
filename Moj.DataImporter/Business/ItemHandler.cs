using Moj.DataImporter.Contracts.Data;
using Moj.DataImporter.Data;
using Moj.DataImporter.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Z.EntityFramework.Extensions;

namespace Moj.DataImporter.Business
{
    public class ItemHandler : IItemHandler
    {
        private readonly ApplicationDbContext context;

        public ItemHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public List<Item> AddItemOrder(List<Item> items, Order order, string itemCode)
        {
            var item = items.Single(it => it.ItemCode == itemCode);
            item.Orders.Add(order);
            return items;
        }

        public List<Item> GetItemsFromSheet(ExcelWorksheet sheet)
        {
            List<Item> items = new List<Item>();
            int rows = sheet.Dimension.Rows;
            for (int i = 2; i <= rows; i++)
            {
                var item = new Item
                {
                    ItemCode = sheet.GetValue<string>(i, 2),
                    ColorCode = sheet.GetValue<string>(i, 3),
                    Description = sheet.GetValue<string>(i, 4),
                    Orders = new List<Order>()
                };

                if (string.IsNullOrWhiteSpace(item.ItemCode))
                {
                    throw new Exception($"Missing item code on row: {i}");
                }

                if (!items.Any(t => t.ItemCode == item.ItemCode))
                {
                    items.Add(item);
                }
            }

            return items;
        }

        public async Task SaveItems(List<Item> items)
        {
            EntityFrameworkManager.ContextFactory = context => context;
            await context.BulkInsertAsync(items, options => {
                
                options.IncludeGraph = true; 
            });
        }
    }
}
