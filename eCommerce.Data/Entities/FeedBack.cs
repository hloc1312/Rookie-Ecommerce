using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Entities
{
    public class FeedBack
    {
        public int ID { get; set; }
        public int  Rating { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }

    }
}
