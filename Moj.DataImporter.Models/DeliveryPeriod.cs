using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moj.DataImporter.Models
{
    public class DeliveryPeriod
    {
        public int ID { get; set; }
        public string Period { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
