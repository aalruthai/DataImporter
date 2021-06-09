using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moj.DataImporter.Models;
using OfficeOpenXml;

namespace Moj.DataImporter.Contracts.Data
{
    public interface IItemHandler
    {
        List<Item> GetItemsFromSheet(ExcelWorksheet sheet);

        List<Item> AddItemOrder(List<Item> items,Order order, string itemCode);

        Task SaveItems(List<Item> items);
    }
}
