using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;
using Moj.DataImporter.Models;
using Moj.DataImporter.Models.Dto;

namespace Moj.DataImporter.Contracts.Excel
{
    public interface IExcel
    {
        Task<List<OrderDto>> ProcessFile(Stream file);

        ExcelWorksheet VerifyFile(ExcelPackage package);

        
    }
}
