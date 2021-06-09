using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moj.DataImporter.Models.Dto
{
    public class OrderDto
    {
        public int ID { get; set; }
        public string Key { get; set; }
        public string ItemCode { get; set; }
        public string ColorCode { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public string DeliverdIn { get; set; }
        public string Q1 { get; set; }
        public double Size { get; set; }
        public string Color { get; set; }
    }
}
