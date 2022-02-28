using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public string  ImageUrl { get; set; }
        public string Caption { get; set; }
        public bool isDefault { get; set; }
        public DateTime DateCreate { get; set; }
        public int  SortOrder { get; set; }
        public long  Size { get; set; }

        public Product Product { get; set; }
    }
}
