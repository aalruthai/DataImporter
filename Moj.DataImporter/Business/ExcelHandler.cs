using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Moj.DataImporter.Contracts.Excel;
using Moj.DataImporter.Data;
using Moj.DataImporter.Models;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using Moj.DataImporter.Contracts.Data;
using Moj.DataImporter.Models.Dto;


namespace Moj.DataImporter.Business
{
    public class ExcelHandler : IExcel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ExcelHandler> logger;
        private readonly IItemHandler itemHandler;
        private readonly IOrderHandler orderHandler;
        

        public ExcelHandler(ApplicationDbContext context, 
            ILogger<ExcelHandler> logger, 
            IItemHandler itemHandler, 
            IOrderHandler orderHandler
            )
        {
            _context = context;
            this.logger = logger;
            this.itemHandler = itemHandler;
            this.orderHandler = orderHandler;
            
        }

        

        public async Task<List<OrderDto>> ProcessFile(Stream file)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    await package.LoadAsync(file);


                    var sheet = VerifyFile(package);

                    var items = itemHandler.GetItemsFromSheet(sheet);

                    items = await orderHandler.GetOrdersFromSheet(sheet, items);

                    await itemHandler.SaveItems(items);
                    
                    
                    return orderHandler.GetOrdersDto(items);
                }
            }
            catch (InvalidDataException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ExcelWorksheet VerifyFile(ExcelPackage package)
        {
            if (package.Workbook.Worksheets.Count < 1)
            {
                throw new Exception("Invalid excel file");
            }
            var sheet = package.Workbook.Worksheets[0];
            if (sheet.Dimension.Columns != 10 || sheet.Dimension.Rows < 2)
            {
                throw new Exception("Empty File");
            }

            return sheet;
        }
    }
}
