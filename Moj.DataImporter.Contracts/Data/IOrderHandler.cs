using Moj.DataImporter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using Moj.DataImporter.Models.Dto;

namespace Moj.DataImporter.Contracts.Data
{
    public interface IOrderHandler
    {
        Task<List<Item>> GetOrdersFromSheet(ExcelWorksheet sheet, List<Item> items);
        List<OrderDto> GetOrdersDto(List<Item> items);
    }
}
