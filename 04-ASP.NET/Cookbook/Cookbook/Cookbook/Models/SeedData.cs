using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cookbook.Data;
using System;
using System.Linq;
using Cookbook.Models;

namespace Cookbook.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RecipeContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RecipeContext>>()))
            {
                // Look for any movies.
                if (context.Recipe.Any())
                {
                    return;   // DB has been seeded
                }

                context.Recipe.AddRange(
                    new Recipe
                    {
                        Name = "When Harry Met Sally",
                        Time = 30,
                        Difficulty = "4",
                        NumberOfLikes = 24,
                        Ingredients = "apple, egg",
                        Process = "123",
                        TipsAndTricks = "..."
                    },

                    new Recipe
                    {
                        Name = "Ghostbusters ",
                        Time = 30,
                        Difficulty = "4",
                        NumberOfLikes = 24,
                        Ingredients = "apple, egg",
                        Process = "123",
                        TipsAndTricks = "..."
                    },

                    new Recipe
                    {
                        Name = "Ghostbusters 2",
                        Time = 30,
                        Difficulty = "4",
                        NumberOfLikes = 24,
                        Ingredients = "apple, egg",
                        Process = "123",
                        TipsAndTricks = "..."
                    },

                    new Recipe
                    {
                        Name = "Rio Bravo",
                        Time = 30,
                        Difficulty = "4",
                        NumberOfLikes = 24,
                        Ingredients = "apple, egg",
                        Process = "123",
                        TipsAndTricks = "..."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}