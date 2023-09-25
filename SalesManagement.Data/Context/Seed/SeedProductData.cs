﻿using Microsoft.EntityFrameworkCore;
using SalesManagement.Data.Entities;

namespace SalesManagement.Data.Context.Seed
{
    public static class SeedProductData
    {
        public static void AddProductData(ModelBuilder modelBuilder)
        {
            //Add Categories - Road Bikes - Mountain Bikes - Camping - Hiking - Boots
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 1,
                Name = "Mountain Bikes"

            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 2,
                Name = "Road Bikes"

            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 3,
                Name = "Camping"

            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 4,
                Name = "Hiking"

            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 5,
                Name = "Boots"

            });
            //Products
            //Category Mountain Bikes
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Mountain Bike 1",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/MountainBike1.jpg",
                Price = 200,
                CategoryId = 1

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Mountain Bike 2",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/MountainBike2.jpg",
                Price = 210,
                CategoryId = 1

            });
            //Category Road Bikes
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Road Bike 1",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/RoadBike1.jpg",
                Price = 240,
                CategoryId = 2

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Road Bike 2",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/RoadBike2.jpg",
                Price = 250,
                CategoryId = 2

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Road Bike 3",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/RoadBike3.jpg",
                Price = 252,
                CategoryId = 2

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Road Bike 4",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/RoadBike4.jpg",
                Price = 230,
                CategoryId = 2

            });
            //Camping
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Name = "Tent 1",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/Tent1.jpg",
                Price = 230,
                CategoryId = 3

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 8,
                Name = "Tent 2",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/Tent2.jpg",
                Price = 230,
                CategoryId = 3

            });
            //Category Camping - Mattresses
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 9,
                Name = "Air Mattress 1",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/Mattress1.jpg",
                Price = 11,
                CategoryId = 3

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 10,
                Name = "Air Mattress 2",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/Mattress2.jpg",
                Price = 40,
                CategoryId = 3

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 11,
                Name = "Air Mattress 3",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/Mattress3.jpg",
                Price = 54,
                CategoryId = 3

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 12,
                Name = "Air Mattress 4",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/Mattress4.jpg",
                Price = 15,
                CategoryId = 3

            });

            //Hiking
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 13,
                Name = "Pack 1",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/Pack1.jpg",
                Price = 24,
                CategoryId = 4

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 14,
                Name = "Pack 2",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/Pack2.jpg",
                Price = 30,
                CategoryId = 4

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 15,
                Name = "Pack 3",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/Pack3.jpg",
                Price = 35,
                CategoryId = 4

            });
            //Category Boots
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 16,
                Name = "Boot 1",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/Boot1.jpg",
                Price = 20,
                CategoryId = 5

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 17,
                Name = "Boot 2",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/Boot2.jpg",
                Price = 38,
                CategoryId = 5

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 18,
                Name = "Boot 3",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/Boot3.jpg",
                Price = 35,
                CategoryId = 5

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 19,
                Name = "Boot 4",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia. ",
                ImagePath = "/Images/Products/Boot4.jpg",
                Price = 31,
                CategoryId = 5

            });
        }
    }
}
