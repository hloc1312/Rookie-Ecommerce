using eCommerce.ViewModels.Catalog.Products;
using eCommerce.ViewModels.Catalog.Products.Public;
using eCommerce.ViewModels.Common;
using System.Threading.Tasks;

namespace eCommerce.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryID(GetProductPagingRequest request);
    }
}
