using eCommerce.Application.Catalog.Products;
using eCommerce.ViewModels.Catalog.ProductImages;
using eCommerce.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IManageProductService _manageProductService;

        public ProductsController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }

        // http://localhost:port/products?pageIndex=1&pageSize=10&CategoryID=1
        [HttpGet]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetPublicProductPagingRequest request)
        {
            var products = await _publicProductService.GetAllByCategoryID(request);
            return Ok(products);
        }

        #region Get By ID

        // http://localhost:port/product/{id}
        [HttpGet("{productID}")]
        public async Task<IActionResult> GetByID(int productID)
        {
            var product = await _manageProductService.GetByID(productID);
            if (product == null)
            {
                return BadRequest("Cannot find product");
            }
            return Ok(product);
        }

        #endregion Get By ID

        #region Create Product

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productID = await _manageProductService.Create(request);
            if (productID == 0)
            {
                return BadRequest();
            }
            var product = await _manageProductService.GetByID(productID);
            return CreatedAtAction(nameof(GetByID), new { id = productID }, product);
        }

        #endregion Create Product

        #region Update Product

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _manageProductService.Update(request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        #endregion Update Product

        #region Delete Product

        [HttpDelete("{productID}")]
        public async Task<IActionResult> Delete(int productID)
        {
            var affectedResult = await _manageProductService.Delete(productID);
            if (affectedResult == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        #endregion Delete Product

        #region Update Price

        // HttpPatch update 1 phần của bảng ghi
        [HttpPatch("{productID}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productID, decimal newPrice)
        {
            var isSuccess = await _manageProductService.UpdatePrice(productID, newPrice);
            if (isSuccess)
            {
                return Ok();
            }

            return BadRequest();
        }

        #endregion Update Price

        #region Create Image

        [HttpPost("{productID}/images")]
        public async Task<IActionResult> Create(int productID, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageProductService.AddImage(productID, request);
            if (result == 0)
            {
                return BadRequest();
            }
            var image = await _manageProductService.GetImageByID(result);
            return CreatedAtAction(nameof(GetImageByID), new { id = result }, image);
        }

        #endregion Create Image

        #region Update Image

        [HttpPut("{productID}/images/{imageID}")]
        public async Task<IActionResult> UpdateImage(int imageID, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageProductService.UpdateImages(imageID, request);
            if (result == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        #endregion Update Image

        #region Delete Image

        [HttpDelete("{productID}/images/{imageID}")]
        public async Task<IActionResult> DeleteImage(int imageID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageProductService.RemoveImages(imageID);
            if (result == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        #endregion Delete Image

        #region Get Image By ID

        // http://localhost:port/product/{id}
        [HttpGet("{productID}/images/{imageID}")]
        public async Task<IActionResult> GetImageByID(int productID, int imageID)
        {
            var image = await _manageProductService.GetImageByID(productID);
            if (image == null)
            {
                return BadRequest("Cannot find product");
            }
            return Ok(image);
        }

        #endregion Get Image By ID
    }
}