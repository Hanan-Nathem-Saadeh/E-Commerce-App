using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastMarket.Models;
using FastMarket.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FastMarket.Pages.CategPage
{
    public class CategProductModel : PageModel
    {

        private readonly ICategories _categories;

        public CategProductModel(ICategories categories1)
        {
            _categories = categories1;
        }

        public Categories categories { get; set; }
        public async Task OnGet(int id)
        {
            categories = await _categories.GetCategory(id);
        }
    }
}
