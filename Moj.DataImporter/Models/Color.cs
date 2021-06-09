using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moj.DataImporter.Models
{
    public class Color
    {
        public int ID { get; set; }
        public string ColorName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
