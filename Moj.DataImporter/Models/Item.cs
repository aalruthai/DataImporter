using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moj.DataImporter.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string ItemCode { get; set; }
        public string ColorCode { get; set; }
        public string Description { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
