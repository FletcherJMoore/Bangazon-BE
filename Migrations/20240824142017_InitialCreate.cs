using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bangazon_BE.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductImage = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PricePerUnit = table.Column<decimal>(type: "numeric", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "DateCreated", "PaymentTypeId", "ProductId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 24, 9, 20, 17, 743, DateTimeKind.Local).AddTicks(6658), 1, 1, 1 },
                    { 2, new DateTime(2024, 8, 24, 9, 20, 17, 743, DateTimeKind.Local).AddTicks(6709), 1, 9, 1 }
                });

            migrationBuilder.InsertData(
                table: "PaymentType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Card" },
                    { 2, "PayPal" },
                    { 3, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "PricePerUnit", "ProductImage", "QuantityAvailable", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "The Nintendo Switch is a hybrid video game console, consisting of a console unit, a dock, and two Joy-Con controllers. Although it is a hybrid console, Nintendo classifies it as a home console that you can take with you on the go.", 300.00m, "https://a.media-amazon.com/images/I/61nqNujSF2L._SX522_.jpg", 5, "Nintendo Switch", 0 },
                    { 2, "A guitar is a stringed instrument with a long neck, flat body, and usually six strings. The strings are typically played with the fingers or a pick, and the player presses the strings against frets on the fingerboard to create notes.", 500.00m, "https://a.media-amazon.com/images/I/71xAmVPkfVL.__AC_SX300_SY300_QL70_FMwebp_.jpg", 2, "Guitar", 0 },
                    { 3, "World-class noise cancellation, quieter than ever before. Breakthrough spatialized audio for immersive listening, no matter the content or source. Elevated design and luxe materials for unrivaled comfort. It’s everything music makes you feel taken to new highs. Bose Immersive Audio pushes the boundary of what it means to listen by taking what you’re hearing out of your head and placing it in front of you. It sounds so real it’s almost like you could reach out and touch it.", 20.00m, "https://a.media-amazon.com/images/I/51NC9ErIQtL.__AC_SX300_SY300_QL70_FMwebp_.jpg", 20, "Bose QuietComfort Ultra Headphones", 0 },
                    { 4, "MASCULINE ELEGANCE: Immerse yourself in the magical allure of our scented candle crafted specifically for men. Designed to capture the essence of the season and the cozy warmth of masculine charm, these candles are an irresistible delight. Perfect for those who savor luxury and the comforting scents of the season, each gift comes in captivating, ready-to-give packaging. Elevate your gift-giving experience with this thoughtful and unforgettable present for any man deserving of a touch of elegance.", 18.99m, "https://a.media-amazon.com/images/I/81O7p61D1iL._AC_SX679_.jpg", 10, "Craft & Kin Smoke & Vanilla Candle", 0 },
                    { 5, "Lightweight, skin-improving mineral foundation that provides buildable sheer-to-full coverage with a natural, luminous finish.", 37.05m, "https://a.media-amazon.com/images/I/419G9NNdFIL._SY445_SX342_QL70_FMwebp_.jpg", 30, "bareMinerals Original Matte Loose Mineral Foundation SPF 15", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "ImageUrl", "LastName", "Password", "Uid", "Username" },
                values: new object[] { 1, "fletcherjmoore14@gmail.com", "Fletcher", "ImageUrl", "Moore", "Password", "1", "FletcherJMoore" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
