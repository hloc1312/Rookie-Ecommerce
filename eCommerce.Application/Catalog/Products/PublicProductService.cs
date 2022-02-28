using eCommerce.Data.EF;
using eCommerce.ViewModels.Catalog.Products;
using eCommerce.ViewModels.Catalog.Products.Public;
using eCommerce.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {

        private readonly eCommerceDbContext _context;
        public PublicProductService(eCommerceDbContext context)
        {
            _context = context;
        }


        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryID(GetProductPagingRequest request)
        {
            // Select Join
            var query = from p in _context.Products
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pic };


            // Filter

            if (request.CategoryID.Value > 0 && request.CategoryID.HasValue)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryID);
            }


            // Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                            .Take(request.pageSize)
                            .Select(x => new ProductViewModel()
                            {
                                Id = x.p.Id,
                                Name = x.p.Name,
                                DateCreate = x.p.DateCreate,
                                Description = x.p.Description,
                                Details = x.p.Details,
                                OriginalPrice = x.p.OriginalPrice,
                                Price = x.p.Price,
                                SeoAlias = x.p.SeoAlias,
                                SeoDescription = x.p.SeoDescription,
                                SeoTitle = x.p.SeoTitle,
                                ViewCount = x.p.ViewCount,
                                Quantity = x.p.Quantity,
                                DateUpdate = x.p.DateUpdate
                            }).ToListAsync();

            // Select and project 
            var pageResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data,
            };
            return pageResult;
        }
    }
}
