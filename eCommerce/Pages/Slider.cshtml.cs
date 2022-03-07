using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Application.Catalog.Products;
using eCommerce.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eCommerce.WebApp.Pages
{
    public class SliderModel : PageModel
    {
        private readonly IManageProductService _test;

        public SliderModel(IManageProductService test)
        {
            _test = test;
        }

        public ProductViewModel ProductViewModel { get; set; }

        public async Task OnGet()
        {
            ProductViewModel = await _test.GetByID(1);
        }
    }
}