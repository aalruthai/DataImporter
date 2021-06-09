using Moj.DataImporter.Contracts.Data;
using Moj.DataImporter.Data;
using Moj.DataImporter.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moj.DataImporter.Models.Dto;
using AutoMapper;

namespace Moj.DataImporter.Business
{
    public class OrderHandler : IOrderHandler
    {
        private readonly ApplicationDbContext context;
        private readonly IColorHandler colorHandler;
        private readonly ICategoryHandler categoryHandler;
        private readonly IDeliveryPeriodHandler deliveryPeriodHandler;
        private readonly IItemHandler itemHandler;
        private readonly IMapper mapper;

        public OrderHandler(ApplicationDbContext context, 
            IColorHandler colorHandler, 
            ICategoryHandler categoryHandler, 
            IDeliveryPeriodHandler deliveryPeriodHandler, 
            IItemHandler itemHandler,
            IMapper mapper)
        {
            this.context = context;
            this.colorHandler = colorHandler;
            this.categoryHandler = categoryHandler;
            this.deliveryPeriodHandler = deliveryPeriodHandler;
            this.itemHandler = itemHandler;
            this.mapper = mapper;
        }

        public List<OrderDto> GetOrdersDto(List<Item> items)
        {
            List<OrderDto> orders = new List<OrderDto>();
            foreach (var item in items)
            {
                orders.AddRange(mapper.Map<ICollection<Order>, List<OrderDto>>(item.Orders));
            }

            return orders;
        }
            

        public async Task<List<Item>> GetOrdersFromSheet(ExcelWorksheet sheet, List<Item> items)
        {
            var colors = await colorHandler.GetAllColors();
            var categories = await categoryHandler.GetAllCategories();
            var deliveryPeriods = await deliveryPeriodHandler.GetAllDeliveryPeriods();
            int rows = sheet.Dimension.Rows;

            string itemCode;
            string color;
            string category;
            string deliveryPeriod;

            for (int i = 2; i <= rows; i++)
            {
                Order order = new Order();

                order.Key = sheet.GetValue<string>(i, 1);
                itemCode = sheet.GetValue<string>(i, 2);
                order.Price = sheet.GetValue<double>(i, 5);
                order.DiscountPrice = sheet.GetValue<double>(i, 6);
                deliveryPeriod = sheet.GetValue<string>(i, 7);
                category = sheet.GetValue<string>(i, 8);
                order.Size = sheet.GetValue<double>(i, 9);
                color = sheet.GetValue<string>(i, 10);

                

                var dPeriod = deliveryPeriods.FirstOrDefault(dp => dp.Period == deliveryPeriod);
                if (dPeriod != null)
                {
                    order.DeliveryPeriodID = dPeriod.ID;
                }

                var cat = categories.FirstOrDefault(c => c.CategoryName == category);
                if (cat != null)
                {
                    order.CategoryID = cat.ID;
                }

                var clr = colors.FirstOrDefault(c => c.ColorName == color);
                if (clr != null)
                {
                    order.ColorID = clr.ID;
                }

                items = itemHandler.AddItemOrder(items, order, itemCode);
                
            }
                return items;
        }
    }
}
