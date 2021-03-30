using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecipeWebApp.Models
{
    public partial class RecipesContext : DbContext
    {
        public RecipesContext()
        {
        }

        public RecipesContext(DbContextOptions<RecipesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<IngredientClasses> IngredientClasses { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<Measurements> Measurements { get; set; }
        public virtual DbSet<RecipeClasses> RecipeClasses { get; set; }
        public virtual DbSet<RecipeIngredients> RecipeIngredients { get; set; }
        public virtual DbSet<Recipes> Recipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source = Recipes.sqlite");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientClasses>(entity =>
            {
                entity.HasKey(e => e.IngredientClassId);

                entity.ToTable("Ingredient_Classes");

                entity.Property(e => e.IngredientClassId)
                    .HasColumnName("IngredientClassID")
                    .HasColumnType("smallint")
                    .ValueGeneratedNever();

                entity.Property(e => e.IngredientClassDescription).HasColumnType("nvarchar (255)");
            });

            modelBuilder.Entity<Ingredients>(entity =>
            {
                entity.HasKey(e => e.IngredientId);

                entity.HasIndex(e => e.IngredientClassId)
                    .HasName("Ingredient_ClassesIngredients");

                entity.HasIndex(e => e.MeasureAmountId)
                    .HasName("MeasurementsIngredients");

                entity.Property(e => e.IngredientId)
                    .HasColumnName("IngredientID")
                    .HasColumnType("int")
                    .ValueGeneratedNever();

                entity.Property(e => e.IngredientClassId)
                    .HasColumnName("IngredientClassID")
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IngredientName).HasColumnType("nvarchar (255)");

                entity.Property(e => e.MeasureAmountId)
                    .HasColumnName("MeasureAmountID")
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.IngredientClass)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.IngredientClassId);

                entity.HasOne(d => d.MeasureAmount)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.MeasureAmountId);
            });

            modelBuilder.Entity<Measurements>(entity =>
            {
                entity.HasKey(e => e.MeasureAmountId);

                entity.Property(e => e.MeasureAmountId)
                    .HasColumnName("MeasureAmountID")
                    .HasColumnType("smallint")
                    .ValueGeneratedNever();

                entity.Property(e => e.MeasurementDescription).HasColumnType("nvarchar (255)");
            });

            modelBuilder.Entity<RecipeClasses>(entity =>
            {
                entity.HasKey(e => e.RecipeClassId);

                entity.ToTable("Recipe_Classes");

                entity.Property(e => e.RecipeClassId)
                    .HasColumnName("RecipeClassID")
                    .HasColumnType("smallint")
                    .ValueGeneratedNever();

                entity.Property(e => e.RecipeClassDescription).HasColumnType("nvarchar (255)");
            });

            modelBuilder.Entity<RecipeIngredients>(entity =>
            {
                entity.HasKey(e => new { e.RecipeId, e.RecipeSeqNo });

                entity.ToTable("Recipe_Ingredients");

                entity.HasIndex(e => e.IngredientId)
                    .HasName("IngredientID");

                entity.HasIndex(e => e.MeasureAmountId)
                    .HasName("MeasureAmountID");

                entity.HasIndex(e => e.RecipeId)
                    .HasName("RecipeID");

                entity.Property(e => e.RecipeId)
                    .HasColumnName("RecipeID")
                    .HasColumnType("int");

                entity.Property(e => e.RecipeSeqNo).HasColumnType("smallint");

                entity.Property(e => e.Amount).HasDefaultValueSql("0");

                entity.Property(e => e.IngredientId)
                    .HasColumnName("IngredientID")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MeasureAmountId)
                    .HasColumnName("MeasureAmountID")
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.IngredientId);

                entity.HasOne(d => d.MeasureAmount)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.MeasureAmountId);

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Recipes>(entity =>
            {
                entity.HasKey(e => e.RecipeId);

                entity.HasIndex(e => e.RecipeClassId)
                    .HasName("Recipe_ClassesRecipes");

                entity.Property(e => e.RecipeId)
                    .HasColumnName("RecipeID")
                    .HasColumnType("int")
                    .ValueGeneratedNever();

                entity.Property(e => e.RecipeClassId)
                    .HasColumnName("RecipeClassID")
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RecipeTitle).HasColumnType("nvarchar (255)");

                entity.HasOne(d => d.RecipeClass)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.RecipeClassId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
