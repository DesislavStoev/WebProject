using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
using App.Web.Areas.Identity.Data;
using System.Linq;
using HtmlAgilityPack;
using System.Text;
using App.Models;
using System.Collections.Generic;

namespace App.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start seeding ...");

            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;

                SandboxCode(serviceProvider);
            }
        }

        private static void SandboxCode(IServiceProvider serviceProvider)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var siteUrl = @"http://www.1001recepti.com/recipes/";
            var web = new HtmlWeb { OverrideEncoding = Encoding.GetEncoding("windows-1251") };
            var doc = web.Load(siteUrl);

            var categories = doc.DocumentNode.SelectNodes(".//div[@id='cont_recipe_browse_big']//div");
            foreach (var category in categories)
            {
                var categoryName = category.InnerText.Trim();
                var url = category.SelectSingleNode(".//a").Attributes["href"].Value;
                var db = serviceProvider.GetService<AppRContext>();

                try
                {
                    var doc1 = web.Load(url);
                    var recipes = doc1.DocumentNode.SelectNodes(@".//table[@class='rec search_results']"); //(@".//td[@class='td1']//a");

                    for (int i = 0; i < 11; i++)
                    {
                        var recipeUrl = recipes[i].SelectSingleNode(@".//td[@class='td1']//a");
                        var recipeSmallPicture = recipes[i].SelectSingleNode(@".//img[@class='pic']")?.Attributes["src"]?.Value;
                        var recipeName = recipeUrl.InnerText.Trim();
                        var recipeDoc = web.Load(recipeUrl.Attributes["href"].Value);
                        var recipeBigPicUrl = recipeDoc.DocumentNode.SelectSingleNode(".//div[@id='r1']//p//img")?.Attributes["src"]?.Value;
                        if (string.IsNullOrEmpty(recipeBigPicUrl))
                        {
                            continue;
                        }
                        var recipeSmallPicUrl = recipeSmallPicture;
                        var content = recipeDoc.DocumentNode.SelectSingleNode(@".//p[@class='recipe_step']").InnerText.Trim();
                        var ingredients = recipeDoc.DocumentNode.SelectNodes(@".//span[@typeof='v:RecipeIngredient']");
                        var ingredietList = new List<Ingredient>();
                        foreach (var ingredient in ingredients)
                        {
                            var amount = ingredient.SelectSingleNode(@".//span[@property='v:amount']").InnerText.Trim();
                            var name = ingredient.SelectSingleNode(@".//a[@property='v:name']").InnerText.Trim();
                            var ingrDb = db.Ingredients.Where(x => x.Name == name).FirstOrDefault();
                            if (ingrDb == null)
                            {
                                ingrDb = new Ingredient
                                {
                                    Name = name,
                                };
                            }
                            ingrDb.Quantity = amount;
                            ingredietList.Add(ingrDb);
                        }

                        var cookTime = recipeDoc.DocumentNode.SelectSingleNode(".//span[@property='v:totalTime']").InnerText.Trim();
                        var kcal = decimal.Parse(recipeDoc.DocumentNode.SelectSingleNode(".//span[@property='v:calories']").InnerText.Trim());
                        var fat = decimal.Parse(recipeDoc.DocumentNode.SelectSingleNode(".//span[@property='v:fat']").InnerText.Trim());
                        var saturates = decimal.Parse(recipeDoc.DocumentNode.SelectSingleNode(".//span[@property='v:saturatedFat']").InnerText.Trim());
                        var protein = decimal.Parse(recipeDoc.DocumentNode.SelectSingleNode(".//span[@property='v:protein']").InnerText.Trim());
                        var carbs = decimal.Parse(recipeDoc.DocumentNode.SelectSingleNode(".//span[@property='v:carbohydrates']").InnerText.Trim());
                        var serviceSize = recipeDoc.DocumentNode.SelectSingleNode(".//span[@property='v:servingSize']").InnerText.Trim();

                        var nutrition = new Nutrition
                        {
                            Kcal = kcal,
                            Fat = fat,
                            Saturates = saturates,
                            Protein = protein,
                            Carbs = carbs,
                            ServiceSize = serviceSize
                        };

                        var categoryDb = db.Categories.Where(s => s.Name == categoryName).FirstOrDefault();
                        if (categoryDb == null)
                        {
                            categoryDb = new Category
                            {
                                Name = categoryName
                            };
                            db.Categories.Add(categoryDb);
                            db.SaveChanges();
                        }


                        var r = new Recipe
                        {
                            Category = categoryDb,
                            Name = recipeName,
                            Directions = new Directions
                            {
                                CookTime = cookTime,
                                Method = content,
                                Serves = 4,
                            },
                            Author = "Uncknown",
                            MenuType = Models.Enums.MenuType.Other,
                            BigPictureUrl = recipeBigPicUrl,
                            SmallPictureUrl = recipeSmallPicUrl,
                            Ingredients = ingredietList,
                            Nutrition = nutrition
                        };
                        Console.WriteLine($"{r.Category.Name} => {r.Name}");
                        db.Recipes.Add(r);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                db.SaveChanges();
            }
        }

        private static void ConfigureServices(ServiceCollection service)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            service.AddDbContext<AppRContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
