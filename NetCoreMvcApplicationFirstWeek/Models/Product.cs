using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcApplicationFirstWeek.Models
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Ürün Adı")]
        public string Name { get; set; }

        [DisplayName("Fiyat")]
        public decimal Price { get; set; }

        [DisplayName("Stok Miktarı")]
        public double Stock { get; set; }

        [DisplayName("Resim")]
        public string Image { get; set; }
    }
}
