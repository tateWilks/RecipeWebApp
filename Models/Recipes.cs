using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecipeWebApp.Models
{
    public partial class Recipes
    {
        public Recipes()
        {
            RecipeIngredients = new HashSet<RecipeIngredients>();
        }

        public long RecipeId { get; set; }
        public string RecipeTitle { get; set; }
        public long? RecipeClassId { get; set; }
        public string Preparation { get; set; }
        public string Notes { get; set; }

        public virtual RecipeClasses RecipeClass { get; set; }
        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
