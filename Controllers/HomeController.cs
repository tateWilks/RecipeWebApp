using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeWebApp.Models;
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

        public HomeController(ILogger<HomeController> logger, RecipesContext ctx)
        {
            _logger = logger;
            _context = ctx;
        }

        //[HttpGet]
        public IActionResult Index(long? mealTypeId)
        {            
            return View(_context.Recipes
                .FromSqlInterpolated($"SELECT * FROM Recipes WHERE RecipeClassId = {mealTypeId} OR {mealTypeId} IS NULL")
                .ToList()); //this is a set of data, not just a record of data
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
