using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Bangazon_BE.Models;

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
            app.MapGet("/api/singleUser/{userId}", (BangazonDbContext db, int userId) =>
            {
                User singleUser = db.Users.FirstOrDefault(user => user.Id == userId);
                if (singleUser == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(singleUser);
            });

            // CHECK USERS
            app.MapPost("/api/checkUser/{uid}", (BangazonDbContext db, string uid) =>
            {
                var checkUser = db.Users.Where(u => u.Uid == uid);

                if (checkUser == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(checkUser);
            });

        }
        }
    }
