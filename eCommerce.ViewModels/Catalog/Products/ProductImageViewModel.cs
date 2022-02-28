using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.ViewModels.Catalog.Products
{
    public class ProductImageViewModel
    {
        public int ID { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDefault { get; set; }
        public long Size { get; set; }
    }
}
