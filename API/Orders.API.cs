using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Bangazon_BE.Models;
using Bangazon_BE.DTO;

namespace Bangazon_BE.API
{
    public class OrdersAPI
    {
        private static object addUserMovieDto;

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
                Order order = db.Orders.FirstOrDefault(o => o.Id == id);
                if (order == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(order);
            });

            //GET CART
            app.MapGet("/api/cart/{userId}", (BangazonDbContext db, int userId) =>
            {
                return db.Orders
                        .Include(o => o.Products)
                        .SingleOrDefault(o => o.UserId == userId && o.Closed == false);
            });

            // ADDING PRODUCT TO ORDER (CART)
            app.MapPost("/api/order/addProduct", (BangazonDbContext db, OrderProductDto orderProduct) =>
            {
                 var orderToUpdate = db.Orders
                 .Include(o => o.Products)
                 .FirstOrDefault(o => o.Id == orderProduct.OrderId);
                 var addProduct = db.Products.FirstOrDefault(op => op.Id == orderProduct.ProductId);
                try
                 {
                    orderToUpdate.Products.Add(addProduct);
                   db.SaveChanges();
                    return Results.NoContent();
                }
               catch (DbUpdateException)
                {
                   return Results.BadRequest("Invalid data submitted");
               }
           });



            // GET CLOSED ORDERS
            app.MapGet("api/user/{userId}/order-history", (BangazonDbContext db, int userId) =>
            {
                List<Order> orders = db.Orders
                .Include(o => o.Products)
                .Where(o => o.UserId == userId && o.Closed == true)
                .ToList();

                if (orders == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(orders);
            });

            //REMOVE PRODUCT FROM CART
            app.MapDelete("/api/order/{orderId}/deleteProduct/{productId}", (BangazonDbContext db, int orderId, int productId) =>
            {
                var singleOrderToUpdate = db.Orders
                .Include(o => o.Products)
                .FirstOrDefault(o => o.Id == orderId);
                var productToDelete = db.Products.FirstOrDefault(p => p.Id == productId);

                try
                {
                    singleOrderToUpdate.Products.Remove(productToDelete);
                    db.SaveChanges();
                    return Results.NoContent();

                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Invalid data submitted");
                }
            });
            app.Run();

        }
    }
}
