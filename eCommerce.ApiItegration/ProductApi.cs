using eCommerce.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.ApiItegration
{
    public class ProductApi : IProductApi
    {
        public Task<List<ProductViewModel>> GetFeaturedProducts(int take)
        {
            var data = GetListAsync<ProductViewModel>($"/api/products/featured/{take}");
            return (Task<List<ProductViewModel>>)data;
        }

        private async Task GetListAsync<T>(string v)
        {
            throw new NotImplementedException();
        }
    }
}