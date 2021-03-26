using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecipeWebApp.Models
{
    public partial class RecipeIngredients
    {
        public long RecipeId { get; set; }
        public long RecipeSeqNo { get; set; }
        public long? IngredientId { get; set; }
        public long? MeasureAmountId { get; set; }
        public double? Amount { get; set; }

        public virtual Ingredients Ingredient { get; set; }
        public virtual Measurements MeasureAmount { get; set; }
        public virtual Recipes Recipe { get; set; }
    }
}
