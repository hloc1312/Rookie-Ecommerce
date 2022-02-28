using eCommerce.Application.Common;
using eCommerce.Data.EF;
using eCommerce.Data.Entities;
using eCommerce.Utilities;
using eCommerce.ViewModels.Catalog.Products;
using eCommerce.ViewModels.Catalog.Products.Manage;
using eCommerce.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace eCommerce.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly eCommerceDbContext _context;
        private readonly IStorageService _storageService;

        public ManageProductService(eCommerceDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public Task<int> AddImages(int productID, List<IFormFile> files)
        {
            throw new NotImplementedException();
        }

        public async Task AddViewCount(int productID)
        {
            var product = await _context.Products.FindAsync(productID);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public  async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Quantity = request.Quantity,
                ViewCount = 0,
                DateCreate = DateTime.Now,
                SeoAlias = request.SeoAlias,
                Name = request.Name,
                Description = request.Description,
                Details = request.Details,
                SeoDescription = request.SeoDescription,
                SeoTitle = request.SeoTitle,
                
                
            };
            // Save Image
            if (request.ThumnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumnail Image",
                        DateCreate = DateTime.Now,
                        Size = request.ThumnailImage.Length,
                        ImageUrl = await this.SaveFile(request.ThumnailImage),
                        isDefault = true,
                        SortOrder = 1

                    }

                };
            }
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if(product == null)
            {
                throw new eCommerceException($"Cannot find a product {productId}");
            }
            var images = _context.ProductImages.Where(x => x.ProductID == productId);
            foreach(var item in images)
            {
                await _storageService.DeleteFileAsync(item.ImageUrl);
            }

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            // Select Join
            var query = from p in _context.Products
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id                        
                        select new { p, pic };


            // Filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.p.Name.Contains(request.Keyword));
            }
            if(request.CategoryIDs.Count > 0)
            {
                query = query.Where(p => request.CategoryIDs.Contains(p.pic.CategoryId));
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

        public Task<List<ProductImageViewModel>> GetListImage(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveImages(int imageID)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if(product == null)
            {
                throw new eCommerceException($"Cannot find a product with id: {request.Id}");
            }

            product.DateUpdate = DateTime.Now;
            product.Name = request.Name;
            product.SeoAlias = request.SeoAlias;
            product.SeoDescription = request.SeoDescription;
            product.SeoTitle = request.SeoTitle;
            product.DateUpdate = request.DateUpdate;
            product.Description = request.Description;
            product.Details = request.Details;

            // Save Image
            if (request.ThumnailImage != null)
            {
                var thumnail = await _context.ProductImages.FirstOrDefaultAsync(x => x.isDefault == true && x.ProductID == request.Id);
                if(thumnail != null)
                {
                        thumnail.Size = request.ThumnailImage.Length;
                        thumnail.ImageUrl = await this.SaveFile(request.ThumnailImage);
                        _context.ProductImages.Update(thumnail);
                }
              
            }

            return await _context.SaveChangesAsync();
        }

        public Task<int> UpdateImages(int imageID, string caption, bool isDefault)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePrice(int productID, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productID);
            if (product == null)
            {
                throw new eCommerceException($"Cannot find a product with id: {productID}");

            }
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateQuantity(int productID, int addQuantity)
        {
            var product = await _context.Products.FindAsync(productID);
            if (product == null)
            {
                throw new eCommerceException($"Cannot find a product with id: {productID}");

            }
            product.Quantity += addQuantity;
            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
