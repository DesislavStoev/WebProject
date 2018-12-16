using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
using App.Web.Areas.Identity.Data;
using System.Linq;
using HtmlAgilityPack;
using System.Text;

namespace App.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

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

                var doc1 = web.Load(url);
                var recipesUrl = doc1.DocumentNode.SelectNodes(@".//table[@class='rec search_results']//a");

                foreach (var recipeUrl in recipesUrl)
                {

                    var recipeName = recipeUrl.InnerText.Trim();
                    var recipeDoc = web.Load(recipeUrl.Attributes["href"].Value);
                    var recipePicUrl = recipeDoc.DocumentNode.SelectSingleNode(".//div[@id='r1']//p//img").Attributes["src"].Value;

                    var content = recipeDoc.DocumentNode.SelectSingleNode(@".//p[@class='recipe_step']").InnerText.Trim();
                    var ingredients = recipeDoc.DocumentNode.SelectNodes(@".//span[@typeof='v:RecipeIngredient']");
                    foreach (var ingredient in ingredients)
                    {
                        var amount = ingredient.SelectSingleNode(@".//span[@property='v:amount']").InnerText.Trim();
                        var name = ingredient.SelectSingleNode(@".//a[@property='v:name']").InnerText.Trim();
                    }

                    var readyTime = recipeDoc.DocumentNode.SelectSingleNode(".//span[@property='v:totalTime']").InnerText.Trim();   

                }

            }

            //var db = serviceProvider.GetService<AppRContext>();
            //Console.WriteLine(db.Users.Count());
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
