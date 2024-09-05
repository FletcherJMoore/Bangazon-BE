using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Bangazon_BE.Models;

namespace Bangazon_BE.API
{
    public class ProductsAPI
    {
        public static void Map(WebApplication app)
        {
            //GET ALL PRODUCTS
            app.MapGet("/api/products", (BangazonDbContext db) =>
            {
                return db.Products.ToList();
            });

            app.MapGet("/api/products/{productId}", (BangazonDbContext db, int productId) =>
            {
                return db.Products
                .Where(p => p.Id == productId)
                .Select(p => new
                {
                    p.Id,
                    p.Title,
                    p.ProductImage,
                    p.Description,
                    p.QuantityAvailable,
                    p.PricePerUnit,
                    ReleaseDate = p.ReleaseDate.ToString("MM/dd/yy"),

                })
                .FirstOrDefault();
            });

            // GET RECENT 20 PRODUCTS
            app.MapGet("/api/recent", (BangazonDbContext db) =>
            {
                return db.Products
                .OrderByDescending(o => o.ReleaseDate)
                .Take(20)
                 .Select(o => new
                 {
                     o.Id,
                     o.Title,
                     o.ProductImage,
                     o.Description,
                     ReleaseDate = o.ReleaseDate.ToString("mm/dd/yyyy"),
                     o.PricePerUnit,
                     o.QuantityAvailable,
                 });
            });

        }
    }
}
