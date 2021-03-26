using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecipeWebApp.Models
{
    public partial class Measurements
    {
        public Measurements()
        {
            Ingredients = new HashSet<Ingredients>();
            RecipeIngredients = new HashSet<RecipeIngredients>();
        }

        public long MeasureAmountId { get; set; }
        public string MeasurementDescription { get; set; }

        public virtual ICollection<Ingredients> Ingredients { get; set; }
        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
