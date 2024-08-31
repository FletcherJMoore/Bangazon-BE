using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Bangazon_BE.Models;

namespace Bangazon_BE.API
{
    public class PaymentTypesAPI
    {
        public static void Map(WebApplication app)
        {

            // GET ALL PAYMENT TYPES
            app.MapGet("/api/paymentType", (BangazonDbContext db) =>
            {
                return db.PaymentType.ToList();
            });

            // GET PAYMENT TYPE BY ID
            app.MapGet("/api/paymentType/{id}", (BangazonDbContext db, int id) =>
            {
                PaymentType paymentType = db.PaymentType.FirstOrDefault(o => o.Id == id);
                if (paymentType == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(paymentType);
            });

        }
    }
}
