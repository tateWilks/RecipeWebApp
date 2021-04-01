using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebApp.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Recipes> Recipes { get; set; }
        public Paging PageInfo { get; set; }
        public string Category { get; set; }
    }
}
