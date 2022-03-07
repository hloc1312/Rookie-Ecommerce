using eCommerce.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.ApiItegration
{
    public interface IProductApi
    {
        Task<List<ProductViewModel>> GetFeaturedProducts(int take);
    }
}