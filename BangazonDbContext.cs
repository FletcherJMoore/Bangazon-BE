using Microsoft.EntityFrameworkCore;
using Bangazon_BE.Models;
    public class BangazonDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(new Product[]
            {
        new Product {
            Id = 1,
            Title = "Nintendo Switch",
            ProductImage="https://a.media-amazon.com/images/I/61nqNujSF2L._SX522_.jpg",
            PricePerUnit = 300.00M,
            Description="The Nintendo Switch is a hybrid video game console, consisting of a console unit, a dock, and two Joy-Con controllers. Although it is a hybrid console, Nintendo classifies it as a home console that you can take with you on the go.",
            QuantityAvailable = 5,
        },
        new Product {
            Id = 2,
            Title = "Guitar",
            ProductImage="https://a.media-amazon.com/images/I/71xAmVPkfVL.__AC_SX300_SY300_QL70_FMwebp_.jpg",
            PricePerUnit = 500.00M,
            Description="A guitar is a stringed instrument with a long neck, flat body, and usually six strings. The strings are typically played with the fingers or a pick, and the player presses the strings against frets on the fingerboard to create notes.",
            QuantityAvailable = 2
        },
        new Product {
            Id = 3,
            Title = "Bose QuietComfort Ultra Headphones",
            ProductImage = "https://a.media-amazon.com/images/I/51NC9ErIQtL.__AC_SX300_SY300_QL70_FMwebp_.jpg",
            PricePerUnit = 20.00M,
            Description="World-class noise cancellation, quieter than ever before. Breakthrough spatialized audio for immersive listening, no matter the content or source. Elevated design and luxe materials for unrivaled comfort. It’s everything music makes you feel taken to new highs. Bose Immersive Audio pushes the boundary of what it means to listen by taking what you’re hearing out of your head and placing it in front of you. It sounds so real it’s almost like you could reach out and touch it.",
            QuantityAvailable = 20
        },
        new Product {
            Id = 4,
            Title = "Craft & Kin Smoke & Vanilla Candle",
            ProductImage="https://a.media-amazon.com/images/I/81O7p61D1iL._AC_SX679_.jpg",
            PricePerUnit = 18.99M,
            Description="MASCULINE ELEGANCE: Immerse yourself in the magical allure of our scented candle crafted specifically for men. Designed to capture the essence of the season and the cozy warmth of masculine charm, these candles are an irresistible delight. Perfect for those who savor luxury and the comforting scents of the season, each gift comes in captivating, ready-to-give packaging. Elevate your gift-giving experience with this thoughtful and unforgettable present for any man deserving of a touch of elegance.",
            QuantityAvailable = 10
        },
        new Product {
            Id = 5,
            Title = "bareMinerals Original Matte Loose Mineral Foundation SPF 15",
            ProductImage = "https://a.media-amazon.com/images/I/419G9NNdFIL._SY445_SX342_QL70_FMwebp_.jpg",
            PricePerUnit = 37.05M,
            Description = "Lightweight, skin-improving mineral foundation that provides buildable sheer-to-full coverage with a natural, luminous finish.",
            QuantityAvailable = 30
        },

        });

        modelBuilder.Entity<Order>().HasData(new Order[]
        {
            new Order
            {
                Id = 1,
                UserId = 1,
                DateCreated = DateTime.Now,
                ProductId = 1,
                PaymentTypeId = 1,
            },
            new Order
            {
                Id = 2,
                UserId = 1,
                DateCreated = DateTime.Now,
                ProductId = 9,
                PaymentTypeId = 1,
            },
        });

        modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
           {
                new PaymentType
                {
                    Id = 1,
                    Name = "Card",
                },
                new PaymentType
                {
                    Id = 2,
                    Name = "PayPal",
                },
                new PaymentType
                {
                    Id = 3,
                    Name = "Other",
                },
           });

        modelBuilder.Entity<User>().HasData(new User[]
      {
            new User
            {
                Id = 1,
                Uid = "1",
                FirstName = "Fletcher",
                LastName = "Moore",
                Username = "FletcherJMoore",
                Password = "Password",
                Email = "fletcherjmoore14@gmail.com",
                ImageUrl = "ImageUrl"
            },
      });
    }

    public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
        {

        }
    }
