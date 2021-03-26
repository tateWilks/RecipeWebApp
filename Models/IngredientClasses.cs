using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecipeWebApp.Models
{
    public partial class IngredientClasses
    {
        public IngredientClasses()
        {
            Ingredients = new HashSet<Ingredients>();
        }

        public long IngredientClassId { get; set; }
        public string IngredientClassDescription { get; set; }

        public virtual ICollection<Ingredients> Ingredients { get; set; }
    }
}
