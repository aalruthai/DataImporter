using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Moj.DataImporter.Contracts.Excel
{
    public interface IExcel
    {
        void ProcessFile(Stream file);
    }
}
