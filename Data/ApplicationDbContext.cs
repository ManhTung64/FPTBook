using FPTBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTBook.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedCategory(builder);
            SeedBook(builder);
            SeedUser(builder);
            SeedRole(builder);
            SeedUserRole(builder);
        }

        private void SeedUser(ModelBuilder builder)
        {
            var admin = new IdentityUser
            {
                Id = "1",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com",
                EmailConfirmed = true
            };

            var customer = new IdentityUser
            {
                Id = "2",
                UserName = "customer@gmail.com",
                Email = "customer@gmail.com",
                NormalizedUserName = "customer@gmail.com",
                EmailConfirmed = true
            };

            var storeOwner = new IdentityUser
            {
                Id = "3",
                UserName = "storeOwner@gmail.com",
                Email = "storeOwner@gmail.com",
                NormalizedUserName = "storeOwner@gmail.com",
                EmailConfirmed = true
            };
            var customer2 = new IdentityUser
            {
                Id = "4",
                UserName = "customer2@gmail.com",
                Email = "customer2@gmail.com",
                NormalizedUserName = "customer2@gmail.com",
                EmailConfirmed = true
            };

            var storeOwner2 = new IdentityUser
            {
                Id = "5",
                UserName = "storeOwner2@gmail.com",
                Email = "storeOwner2@gmail.com",
                NormalizedUserName = "storeOwner2@gmail.com",
                EmailConfirmed = true
            };
            var customer3 = new IdentityUser
            {
                Id = "6",
                UserName = "customer3@gmail.com",
                Email = "customer3@gmail.com",
                NormalizedUserName = "customer3@gmail.com",
                EmailConfirmed = true
            };

            var storeOwner3 = new IdentityUser
            {
                Id = "7",
                UserName = "storeOwner3@gmail.com",
                Email = "storeOwner3@gmail.com",
                NormalizedUserName = "storeOwner3@gmail.com",
                EmailConfirmed = true
            };
            var customer4 = new IdentityUser
            {
                Id = "8",
                UserName = "customer4@gmail.com",
                Email = "customer4@gmail.com",
                NormalizedUserName = "customer4@gmail.com",
                EmailConfirmed = true
            };

            var storeOwner4 = new IdentityUser
            {
                Id = "9",
                UserName = "storeOwner4@gmail.com",
                Email = "storeOwner4@gmail.com",
                NormalizedUserName = "storeOwner4@gmail.com",
                EmailConfirmed = true
            };
            var customer5 = new IdentityUser
            {
                Id = "10",
                UserName = "customer5@gmail.com",
                Email = "customer5@gmail.com",
                NormalizedUserName = "customer5@gmail.com",
                EmailConfirmed = true
            };

            var storeOwner5 = new IdentityUser
            {
                Id = "11",
                UserName = "storeOwner5@gmail.com",
                Email = "storeOwner5@gmail.com",
                NormalizedUserName = "storeOwner5@gmail.com",
                EmailConfirmed = true
            };

            var hasher = new PasswordHasher<IdentityUser>();

            admin.PasswordHash = hasher.HashPassword(admin, "123456");

            customer.PasswordHash = hasher.HashPassword(customer, "123456");
            storeOwner.PasswordHash = hasher.HashPassword(storeOwner, "123456");

            customer2.PasswordHash = hasher.HashPassword(customer2, "123456");
            storeOwner2.PasswordHash = hasher.HashPassword(storeOwner2, "123456");

            customer3.PasswordHash = hasher.HashPassword(customer3, "123456");
            storeOwner3.PasswordHash = hasher.HashPassword(storeOwner3, "123456");

            customer4.PasswordHash = hasher.HashPassword(customer4, "123456");
            storeOwner4.PasswordHash = hasher.HashPassword(storeOwner4, "123456");

            customer5.PasswordHash = hasher.HashPassword(customer5, "123456");
            storeOwner5.PasswordHash = hasher.HashPassword(storeOwner5, "123456");

            builder.Entity<IdentityUser>().HasData(admin, customer, storeOwner, customer2, 
                storeOwner2, customer3, storeOwner3, customer4, storeOwner4, customer5, storeOwner5);
        }

        private void SeedRole(ModelBuilder builder)
        {
            var admin = new IdentityRole
            {
                Id = "admin",
                Name = "Administrator",
                NormalizedName = "Administrator"
            };
            var customer = new IdentityRole
            {
                Id = "customer",
                Name = "Customer",
                NormalizedName = "Customer"
            };
            var storeOwner = new IdentityRole
            {
                Id = "storeOwner",
                Name = "StoreOwner",
                NormalizedName = "StoreOwner"
            };

            builder.Entity<IdentityRole>().HasData(admin, customer, storeOwner);
        }

        private void SeedUserRole(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "1",
                    RoleId = "admin"
                },
                new IdentityUserRole<string>
                {
                    UserId = "2",
                    RoleId = "customer"
                },
                new IdentityUserRole<string>
                {
                    UserId = "4",
                    RoleId = "customer"
                },
                new IdentityUserRole<string>
                {
                    UserId = "6",
                    RoleId = "customer"
                },
                new IdentityUserRole<string>
                {
                    UserId = "8",
                    RoleId = "customer"
                },
                new IdentityUserRole<string>
                {
                    UserId = "10",
                    RoleId = "customer"
                },
                new IdentityUserRole<string>
                {
                    UserId = "5",
                    RoleId = "storeOwner"
                },
                new IdentityUserRole<string>
                {
                    UserId = "7",
                    RoleId = "storeOwner"
                },
                new IdentityUserRole<string>
                {
                    UserId = "9",
                    RoleId = "storeOwner"
                },
                new IdentityUserRole<string>
                {
                    UserId = "11",
                    RoleId = "storeOwner"
                }
             );
        }

        private void SeedBook(ModelBuilder builder)
        {
            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "How to have megakill",
                    Author = "Manh Tung",
                    Publisher = "Manh Tung",
                    Year = 2022,
                    Page = 99,
                    Price = 199,
                    Quantity = 5,
                    Image = "sth.png",
                    Description = "dexplosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment",
                    CategoryId = 3
                },
                new Book
                {
                    Id = 2,
                    Title = "How to defeat",
                    Author = "Manh Tung",
                    Publisher = "Manh Tung",
                    Year = 2020,
                    Page = 49,
                    Price = 195,
                    Quantity = 10,
                    Image = "st.png",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",
                    CategoryId = 2
                },
                new Book
                {
                    Id = 3,
                    Title = "You are mine",
                    Author = "Manh Tung",
                    Publisher = "Manh Tung",
                    Year = 2019,
                    Page = 49,
                    Price = 195,
                    Quantity = 10,
                    Image = "sth.png",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",
                    CategoryId = 1
                },
                new Book
                {
                    Id = 4,
                    Title = "One piece vol 1",
                    Author = "Eichiro Oda",
                    Publisher = "Eichiro Oda",
                    Year = 1997,
                    Page = 200,
                    Price = 2.19,
                    Quantity = 15,
                    Image = "op1.jpg",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",

                    CategoryId = 2
                },
                new Book
                {
                    Id = 5,
                    Title = "One piece vol 10",
                    Author = "Eichiro Oda",
                    Publisher = "Eichiro Oda",
                    Year = 1998,
                    Page = 200,
                    Price = 2.99,
                    Quantity = 15,
                    Image = "op2.jpg",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",

                    CategoryId = 2
                },
                new Book
                {
                    Id = 6,
                    Title = "One piece vol 15",
                    Author = "Eichiro Oda",
                    Publisher = "Eichiro Oda",
                    Year = 1999,
                    Page = 200,
                    Price = 2.09,
                    Quantity = 15,
                    Image = "op3.jpg",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",

                    CategoryId = 2
                },
                new Book
                {
                    Id = 7,
                    Title = "One piece vol 16",
                    Author = "Eichiro Oda",
                    Publisher = "Eichiro Oda",
                    Year = 1999,
                    Page = 200,
                    Price = 1.99,
                    Quantity = 7,
                    Image = "op4.jpg",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",

                    CategoryId = 2
                },
                new Book
                {
                    Id = 8,
                    Title = "One piece vol 21",
                    Author = "Eichiro Oda",
                    Publisher = "Eichiro Oda",
                    Year = 1999,
                    Page = 200,
                    Price = 2.19,
                    Quantity = 5,
                    Image = "op5.jpg",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",

                    CategoryId = 2
                },
                new Book
                {
                    Id = 9,
                    Title = "One piece vol 25",
                    Author = "Eichiro Oda",
                    Publisher = "Eichiro Oda",
                    Year = 1999,
                    Page = 200,
                    Price = 2.19,
                    Quantity = 10,
                    Image = "op6.jpg",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",

                    CategoryId = 2
                },
                new Book
                {
                    Id = 10,
                    Title = "Horro1",
                    Author = "Manh Tung",
                    Publisher = "Manh Tung",
                    Year = 2018,
                    Page = 500,
                    Price = 197,
                    Quantity = 1,
                    Image = "hor1.jpg",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",

                    CategoryId = 1
                },
                new Book
                {
                    Id = 11,
                    Title = "Monday is tomorrow vol 1",
                    Author = "Manh Tung",
                    Publisher = "Manh Tung",
                    Year = 2020,
                    Page = 10,
                    Price = 149,
                    Quantity = 9,
                    Image = "hor2.jpg",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",

                    CategoryId = 1
                },
                new Book
                {
                    Id = 12,
                    Title = "Monday is tomorrow vol 2",
                    Author = "Joker",
                    Publisher = "Joker",
                    Year = 2020,
                    Page = 10,
                    Price = 159,
                    Quantity = 9,
                    Image = "hor3.jpg",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",

                    CategoryId = 1
                },
                new Book
                {
                    Id = 13,
                    Title = "Monday is tomorrow vol 3",
                    Author = "Vladimir Putin",
                    Publisher = "Manh Tung",
                    Year = 2021,
                    Page = 10,
                    Price = 169,
                    Quantity = 10,
                    Image = "hor4.jpg",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",

                    CategoryId = 1
                },
                new Book
                {
                    Id = 14,
                    Title = "Monday is tomorrow vol 4",
                    Author = "Vladimir Putin",
                    Publisher = "Manh Tung",
                    Year = 2022,
                    Page = 10,
                    Price = 169,
                    Quantity = 10,
                    Image = "hor5.jpg",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",

                    CategoryId = 1
                },
                new Book
                {
                    Id = 15,
                    Title = "Monday is tomorrow vol 5",
                    Author = "Vladimir Putin",
                    Publisher = "Vladimir Putin",
                    Year = 2022,
                    Page = 10,
                    Price = 99,
                    Quantity = 10,
                    Image = "hor6.jpg",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",

                    CategoryId = 1
                },
                new Book
                {
                    Id = 16,
                    Title = "Be who you want",
                    Author = "Edison",
                    Publisher = "Edison",
                    Year = 1950,
                    Page = 10,
                    Price = 599,
                    Quantity = 100,
                    Image = "sc1.webp",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",

                    CategoryId = 3
                },
                new Book
                {
                    Id = 17,
                    Title = "Beeeeeeeeeee",
                    Author = "Edison second",
                    Publisher = "Edison",
                    Year = 1951,
                    Page = 10,
                    Price = 5999,
                    Quantity = 100,
                    Image = "sc2.webp",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",

                    CategoryId = 3
                },
                new Book
                {
                    Id = 18,
                    Title = "Hand made",
                    Author = "PDPT",
                    Publisher = "Trog non",
                    Year = 2002,
                    Page = 100,
                    Price = 59,
                    Quantity = 5,
                    Image = "sc8.webp",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",

                    CategoryId = 3
                },
                new Book
                {
                    Id = 19,
                    Title = "Geopedia",
                    Author = "Geoper",
                    Publisher = "Geoper",
                    Year = 1991,
                    Page = 299,
                    Price = 29.6,
                    Quantity = 19,
                    Image = "sc3.webp",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",

                    CategoryId = 3
                },
                new Book
                {
                    Id = 21,
                    Title = "The sience of can and can't ",
                    Author = "Sciencer",
                    Publisher = "Sciencer",
                    Year = 1997,
                    Page = 1093,
                    Price = 225.2,
                    Quantity = 3,
                    Image = "sc4.webp",
                    Description = "In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to\r\ncharge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",

                    CategoryId = 3
                },
                new Book
                {
                    Id = 20,
                    Title = "Shape history",
                    Author = "zhongli",
                    Publisher = "Manh Tung",
                    Year = 2004,
                    Page = 999,
                    Price = 9999,
                    Quantity = 3,
                    Image = "sc11.webp",
                    Description = "In the era offficlectr e of the refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ",

                    CategoryId = 3
                }
                );
        }

        private void SeedCategory(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Horror", Description = "18+"},
                new Category { Id = 2, Name = "Manga", Description = "12+" },
                new Category { Id = 3, Name = "Science", Description = "everyone" }
                );
        }
    }
}
