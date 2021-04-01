using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeWebApp.Models;
using RecipeWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RecipesContext _context { get; set; }
        public int ItemsPerPage = 2;

        public HomeController(ILogger<HomeController> logger, RecipesContext ctx)
        {
            _logger = logger;
            _context = ctx;
        }

        //[HttpGet]
        public IActionResult Index(long? icategory, string category, int pagenum=1)
        {            
            int PageNum = pagenum;
            
            if (!System.String.IsNullOrEmpty(category))
            {
                return View(new IndexViewModel
                {
                    Recipes = _context.Recipes
                        .FromSqlInterpolated($"SELECT * FROM Recipes WHERE RecipeClassId = {icategory} OR {icategory} IS NULL")
                        .ToList(),
                    PageInfo = new Paging
                    {
                        NumItemsPage = ItemsPerPage,
                        CurrPage = pagenum,
                        //if no category is selected, get the full count. otherwise, run a query to get the meals only associated with the category
                        TotalItems = _context.Recipes.Where(r => r.RecipeClassId == icategory).Count()
                    },
                    Category = category
                });                              
            } 
            else
            {
                return View(new IndexViewModel
                {
                    Recipes = _context.Recipes                        
                        .OrderBy(r => r.RecipeTitle)
                        .Skip((PageNum - 1) * ItemsPerPage)
                        .Take(ItemsPerPage)
                        .ToList(),
                    PageInfo = new Paging
                    {
                        NumItemsPage = ItemsPerPage,
                        CurrPage = pagenum,
                        //if no category is selected, get the full count. otherwise, run a query to get the meals only associated with the category
                        TotalItems = (icategory == null) ? _context.Recipes.Count() : _context.Recipes.Where(r => r.RecipeClassId == icategory).Count()
                    },
                    Category = category
                });                   
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
