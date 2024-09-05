using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Bangazon_BE.Models;
using Bangazon_BE.DTO;

namespace Bangazon_BE.API
{
    public class UsersAPI
    {
        public static void Map(WebApplication app)
        {

            //GET ALL USERS
            app.MapGet("/api/users", (BangazonDbContext db) =>
            {
                return db.Users.ToList();
            });

            // GET USER DETAILS
            app.MapGet("/api/singleUser/{id}", (BangazonDbContext db, int id) =>
            {
                User singleUser = db.Users.FirstOrDefault(user => user.Id == id);
                if (singleUser == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(singleUser);
            });
               

            // CHECK USERS
            app.MapPost("/api/checkUser/{uid}", (BangazonDbContext db, string uid) =>
            {
                var user = db.Users
                  .Where(u => u.Uid == uid)
                  .FirstOrDefault();

                if (user == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(user);
            });

            // GET USERS CART 
            app.MapGet("/singleUser/cart/{userId}", (BangazonDbContext db, int userId) =>
            {
                var cart = db.Users
                                .Include(m => m.Products)
                                .Where(u => u.Id == userId)
                                 .Select(u => new
                                 {
                                     u.Uid,
                                     u.Name,
                                     Products = u.Products.Select(m => new
                                     {
                                         m.Id,
                                         m.Title,
                                         m.ProductImage,
                                         m.Description,
                                         m.PricePerUnit,
                                         ReleasedDate = m.ReleaseDate.ToString("MM/dd/yyyy"),
                                     })
                                 })
                        .FirstOrDefault();

                if (cart == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(cart);
            });

            // ADD PRODUCT TO USERS CART
            app.MapPost("/cart/addProduct", (BangazonDbContext db, OrderProductDto addOrderProductDto) =>
            {
                if (addOrderProductDto == null)
                {
                    return Results.BadRequest("Invalid request payload");
                }

                var singleUserListToUpdate = db.Users
                                                .Include(u => u.Products)
                                                .FirstOrDefault(u => u.Id == addOrderProductDto.UserId);

                if (singleUserListToUpdate == null)
                {
                    return Results.NotFound($"User with ID {addOrderProductDto.UserId} not found");
                }

                var productToAdd = db.Products
                                      .FirstOrDefault(m => m.Id == addOrderProductDto.ProductsId);

                if (productToAdd == null)
                {
                    return Results.NotFound($"Product with ID {addOrderProductDto.ProductsId} not found");
                }

                try
                {
                    singleUserListToUpdate.Products.Add(productToAdd);
                    db.SaveChanges();
                    return Results.NoContent();
                }
                catch (DbUpdateException ex)
                {
                    return Results.BadRequest($"Invalid data submitted: {ex.Message}");
                }
            });

            //REMOVE PRODUCT FROM USERS CART
            app.MapDelete("/users/{userId}/deleteProduct/{productsId}", (BangazonDbContext db, int productsId, int userId) =>
            {
                var user = db.Users
                                .Include(u => u.Products)
                                .FirstOrDefault(u => u.Id == userId);

                if (user == null)
                {
                    return Results.NotFound();
                }

                var productToRemove = user.Products.FirstOrDefault(m => m.Id == productsId);

                if (productToRemove == null)
                {
                    return Results.NotFound();
                }

                user.Products.Remove(productToRemove);
                db.SaveChanges();
                return Results.Ok();
            });

            // CHECKOUT USERS CART 



        }
        }
    }
