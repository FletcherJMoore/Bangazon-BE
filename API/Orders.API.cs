using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Bangazon_BE.Models;
using System.Threading.Channels;
using Bangazon_BE.Migrations;

namespace Bangazon_BE.API
{
    public class OrdersAPI
    {

        public static void Map(WebApplication app)
        {

            //GET ALL ORDERS
            app.MapGet("/api/orders", (BangazonDbContext db) =>
            {
                return db.Orders.ToList();
            });

            // GET ORDER BY ID
            app.MapGet("/api/order/{id}", (BangazonDbContext db, int id) =>
            {
                Orders order = db.Orders.FirstOrDefault(o => o.Id == id);
                if (order == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(order);
            });

            // GET ORDER BY UID

            app.MapGet("api/order/{userId}", (BangazonDbContext db, int userId) =>
            {
                Orders order = db.Orders.FirstOrDefault(o => o.UserId == userId);
                if (order == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(order);
            });

            //get cutomer's completed orders with the details, by customer id
            app.MapGet("/api/closedOrders/customers/{id}", (BangazonDbContext db, int id) =>
            {
                return db.Orders
                .Include(o => o.Products)
                .Where(o => o.Closed == true && o.Id == id)
                .ToList();

            });

            // POST ORDER
            app.MapPost("/api/order", (BangazonDbContext db, Orders order) =>
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return Results.Created($"/api/order/{order.Id}", order);
            });
        }
    }
}
