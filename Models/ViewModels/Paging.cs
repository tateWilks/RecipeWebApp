using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebApp.Models.ViewModels
{
    public class Paging
    {
        public int NumItemsPage { get; set; }
        public int CurrPage { get; set; }
        public int TotalItems { get; set; }
        public int NumPages => (int) Math.Ceiling((decimal)TotalItems / NumItemsPage);
    }
}
