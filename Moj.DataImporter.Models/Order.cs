using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moj.DataImporter.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string Key { get; set; }
        [ForeignKey("Item")]
        public int ItemID { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        [ForeignKey("DeliveryPeriod")]
        public int DeliveryPeriodID { get; set; }
        [ForeignKey("Category")]
        public int? CategoryID { get; set; }
        public double Size { get; set; }
        [ForeignKey("Color")]
        public int ColorID { get; set; }


        public virtual Color Color { get; set; }
        public virtual Category Category { get; set; }
        public virtual Item Item { get; set; }
        public virtual DeliveryPeriod DeliveryPeriod { get; set; }
    }
}
