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
    public class HomePageModel : PageModel
    {
        private readonly IManageProductService _test;
        //private readonly ProductViewModel _db;

        public HomePageModel(IManageProductService test)
        {
            _test = test;
            //_db = db;
        }

        public ProductViewModel ProductViewModel { get; set; }
        public List<ProductViewModel> Product { get; set; }

        public async Task OnGet()
        {
            //ProductViewModel = await _test.GetByID();

            Product = await _test.GetList();
            Product
            //ProductViewModel = await _db.ToString();
        }
    }
}