﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bangazon_BE.Migrations
{
    [DbContext(typeof(BangazonDbContext))]
    [Migration("20240827010702_OrderProductDto")]
    partial class OrderProductDto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bangazon_BE.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Closed")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Closed = true,
                            DateCreated = new DateTime(2024, 8, 26, 20, 7, 2, 87, DateTimeKind.Local).AddTicks(1646),
                            PaymentTypeId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Closed = false,
                            DateCreated = new DateTime(2024, 8, 26, 20, 7, 2, 87, DateTimeKind.Local).AddTicks(1703),
                            PaymentTypeId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Bangazon_BE.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PaymentType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Card"
                        },
                        new
                        {
                            Id = 2,
                            Name = "PayPal"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("Bangazon_BE.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("PricePerUnit")
                        .HasColumnType("numeric");

                    b.Property<string>("ProductImage")
                        .HasColumnType("text");

                    b.Property<int>("QuantityAvailable")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The Nintendo Switch is a hybrid video game console, consisting of a console unit, a dock, and two Joy-Con controllers. Although it is a hybrid console, Nintendo classifies it as a home console that you can take with you on the go.",
                            PricePerUnit = 300.00m,
                            ProductImage = "https://a.media-amazon.com/images/I/61nqNujSF2L._SX522_.jpg",
                            QuantityAvailable = 5,
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Nintendo Switch",
                            UserId = 0
                        },
                        new
                        {
                            Id = 2,
                            Description = "A guitar is a stringed instrument with a long neck, flat body, and usually six strings. The strings are typically played with the fingers or a pick, and the player presses the strings against frets on the fingerboard to create notes.",
                            PricePerUnit = 500.00m,
                            ProductImage = "https://a.media-amazon.com/images/I/71xAmVPkfVL.__AC_SX300_SY300_QL70_FMwebp_.jpg",
                            QuantityAvailable = 2,
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Guitar",
                            UserId = 0
                        },
                        new
                        {
                            Id = 3,
                            Description = "World-class noise cancellation, quieter than ever before. Breakthrough spatialized audio for immersive listening, no matter the content or source. Elevated design and luxe materials for unrivaled comfort. It’s everything music makes you feel taken to new highs. Bose Immersive Audio pushes the boundary of what it means to listen by taking what you’re hearing out of your head and placing it in front of you. It sounds so real it’s almost like you could reach out and touch it.",
                            PricePerUnit = 20.00m,
                            ProductImage = "https://a.media-amazon.com/images/I/51NC9ErIQtL.__AC_SX300_SY300_QL70_FMwebp_.jpg",
                            QuantityAvailable = 20,
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Bose QuietComfort Ultra Headphones",
                            UserId = 0
                        },
                        new
                        {
                            Id = 4,
                            Description = "MASCULINE ELEGANCE: Immerse yourself in the magical allure of our scented candle crafted specifically for men. Designed to capture the essence of the season and the cozy warmth of masculine charm, these candles are an irresistible delight. Perfect for those who savor luxury and the comforting scents of the season, each gift comes in captivating, ready-to-give packaging. Elevate your gift-giving experience with this thoughtful and unforgettable present for any man deserving of a touch of elegance.",
                            PricePerUnit = 18.99m,
                            ProductImage = "https://a.media-amazon.com/images/I/81O7p61D1iL._AC_SX679_.jpg",
                            QuantityAvailable = 10,
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Craft & Kin Smoke & Vanilla Candle",
                            UserId = 0
                        },
                        new
                        {
                            Id = 5,
                            Description = "Lightweight, skin-improving mineral foundation that provides buildable sheer-to-full coverage with a natural, luminous finish.",
                            PricePerUnit = 37.05m,
                            ProductImage = "https://a.media-amazon.com/images/I/419G9NNdFIL._SY445_SX342_QL70_FMwebp_.jpg",
                            QuantityAvailable = 30,
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "bareMinerals Original Matte Loose Mineral Foundation SPF 15",
                            UserId = 0
                        });
                });

            modelBuilder.Entity("Bangazon_BE.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "fletcherjmoore14@gmail.com",
                            FirstName = "Fletcher",
                            ImageUrl = "ImageUrl",
                            LastName = "Moore",
                            Password = "Password",
                            Username = "FletcherJMoore"
                        });
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductsId")
                        .HasColumnType("integer");

                    b.HasKey("OrdersId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("Bangazon_BE.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bangazon_BE.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
