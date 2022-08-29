﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipesApp.Infrastructure.Context;

#nullable disable

namespace RecipesApp.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RecipesApp.Domain.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<float>("Calories")
                        .HasColumnType("real");

                    b.Property<float>("Carbs")
                        .HasColumnType("real");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<float>("Fats")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Proteins")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("RecipesApp.Domain.Models.MealPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BreakfastId")
                        .HasColumnType("int");

                    b.Property<float>("Calories")
                        .HasColumnType("real");

                    b.Property<float>("Carbs")
                        .HasColumnType("real");

                    b.Property<int?>("DinnerId")
                        .HasColumnType("int");

                    b.Property<float>("Fats")
                        .HasColumnType("real");

                    b.Property<int?>("LunchId")
                        .HasColumnType("int");

                    b.Property<float>("Proteins")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BreakfastId");

                    b.HasIndex("DinnerId");

                    b.HasIndex("LunchId");

                    b.ToTable("MealPlans");
                });

            modelBuilder.Entity("RecipesApp.Domain.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("Author")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<float>("Calories")
                        .HasColumnType("real");

                    b.Property<float>("Carbs")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Fats")
                        .HasColumnType("real");

                    b.Property<int>("MealType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("Proteins")
                        .HasColumnType("real");

                    b.Property<int>("ServingTime")
                        .HasColumnType("int");

                    b.Property<float>("Servings")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RecipesApp.Domain.Models.RecipeImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<string>("StorageImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeImages");
                });

            modelBuilder.Entity("RecipesApp.Domain.Models.RecipeIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("RecipesApp.Domain.Models.RecipeWithRecipeIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeIngredientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("RecipeIngredientId");

                    b.ToTable("RecipeWithRecipeIngredients");
                });

            modelBuilder.Entity("RecipesApp.Domain.Models.MealPlan", b =>
                {
                    b.HasOne("RecipesApp.Domain.Models.Recipe", "Breakfast")
                        .WithMany()
                        .HasForeignKey("BreakfastId");

                    b.HasOne("RecipesApp.Domain.Models.Recipe", "Dinner")
                        .WithMany()
                        .HasForeignKey("DinnerId");

                    b.HasOne("RecipesApp.Domain.Models.Recipe", "Lunch")
                        .WithMany()
                        .HasForeignKey("LunchId");

                    b.Navigation("Breakfast");

                    b.Navigation("Dinner");

                    b.Navigation("Lunch");
                });

            modelBuilder.Entity("RecipesApp.Domain.Models.RecipeImage", b =>
                {
                    b.HasOne("RecipesApp.Domain.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("RecipesApp.Domain.Models.RecipeIngredient", b =>
                {
                    b.HasOne("RecipesApp.Domain.Models.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("RecipesApp.Domain.Models.RecipeWithRecipeIngredient", b =>
                {
                    b.HasOne("RecipesApp.Domain.Models.Recipe", "Recipe")
                        .WithMany("RecipeWithRecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipesApp.Domain.Models.RecipeIngredient", "RecipeIngredient")
                        .WithMany("RecipeWithRecipeIngredients")
                        .HasForeignKey("RecipeIngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("RecipeIngredient");
                });

            modelBuilder.Entity("RecipesApp.Domain.Models.Ingredient", b =>
                {
                    b.Navigation("RecipeIngredients");
                });

            modelBuilder.Entity("RecipesApp.Domain.Models.Recipe", b =>
                {
                    b.Navigation("RecipeWithRecipeIngredients");
                });

            modelBuilder.Entity("RecipesApp.Domain.Models.RecipeIngredient", b =>
                {
                    b.Navigation("RecipeWithRecipeIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
