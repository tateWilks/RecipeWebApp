using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecipeWebApp.Models
{
    public partial class Ingredients
    {
        public Ingredients()
        {
            RecipeIngredients = new HashSet<RecipeIngredients>();
        }

        public long IngredientId { get; set; }
        public string IngredientName { get; set; }
        public long? IngredientClassId { get; set; }
        public long? MeasureAmountId { get; set; }

        public virtual IngredientClasses IngredientClass { get; set; }
        public virtual Measurements MeasureAmount { get; set; }
        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
