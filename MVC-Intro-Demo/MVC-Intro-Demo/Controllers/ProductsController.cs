using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVC_Intro_Demo.Models;
using System.Text;
using System.Text.Json;

namespace MVC_Intro_Demo.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IEnumerable<ProductViewModel> products
            = new List<ProductViewModel>()
            {
                new ProductViewModel()
                {
                    Id = 1,
                    Name = "Beer Zagorka",
                    Price = 1.90m
                },

                new ProductViewModel()
                {
                    Id = 2,
                    Name = "Tomato",
                    Price = 2.20m
                },

                new ProductViewModel()
                {
                    Id = 3,
                    Name = "Bubble Gum Turbo",
                    Price = 1.10m
                }
            };
       
        public IActionResult Index()
        {
            return View();
        }

        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
            if (keyword != null)
            {
                var foundProducts = this.products
                    .Where(pr => pr.Name.ToLower().Contains(keyword.ToLower()));

                return View(foundProducts);
            }

            return View(this.products);
        }

        public IActionResult ById(int id)
        {
            var product = this.products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return BadRequest(product);
            }

            return View(product);
        }


        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return Json(this.products, options);
        }

        public IActionResult AllAsText()
        {
            var text = String.Empty;
            foreach (var product in products)
            {
                text += $"Product {product.Id}: {product.Name} - {product.Price}lv";
                text += "\r\n";
            }

            return Content(text);
        }

        public IActionResult AllAsTextFile()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var product in products)
            {
                sb.AppendLine($"Product file: {product.Id}: {product.Name} - {product.Price:f2} lv");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition,"@attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }

    }
}
