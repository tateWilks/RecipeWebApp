using Microsoft.AspNetCore.Mvc;
using RecipeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebApp.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private RecipesContext _context;
        public CategoryViewComponent(RecipesContext ctx)
        {
            _context = ctx;
        }

        public IViewComponentResult Invoke()
        {             
            return View(
                _context.RecipeClasses                    
                    .Distinct()
                    .OrderBy(r => r)                    
            ); //select only the recipe class descriptions from this table of recipe classes
        }
    }
}
