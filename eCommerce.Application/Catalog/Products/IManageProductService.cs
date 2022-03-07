using eCommerce.ViewModels.Catalog.ProductImages;
using eCommerce.ViewModels.Catalog.Products;
using eCommerce.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<ProductViewModel> GetByID(int productID);

        Task<bool> UpdatePrice(int productID, decimal newPrice);

        Task<bool> UpdateQuantity(int productID, int addQuantity);

        Task AddViewCount(int productID);

        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<List<ProductViewModel>> GetList();

        Task<int> AddImage(int productID, ProductImageCreateRequest request);

        Task<int> RemoveImages(int imageID);

        Task<int> UpdateImages(int imageID, ProductImageUpdateRequest request);

        Task<ProductImageViewModel> GetImageByID(int imageID);

        Task<List<ProductImageViewModel>> GetListImages(int productId);

        Task<List<ProductViewModel>> GetFeaturedProducts(int take);
    }
}