using eCommerce.ViewModels.Catalog.Products;

using eCommerce.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryID(GetPublicProductPagingRequest request);

        Task<List<ProductViewModel>> GetAll();
    }
}
