using eCommerce.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.ViewModels.Catalog.Products
{
    public class GetManageProductPagingRequest: PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryIDs { get; set; }
    }
}
