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

            var hasher = new PasswordHasher<IdentityUser>();

            admin.PasswordHash = hasher.HashPassword(admin, "123456");
            customer.PasswordHash = hasher.HashPassword(customer, "123456");
            storeOwner.PasswordHash = hasher.HashPassword(storeOwner, "123456");
            builder.Entity<IdentityUser>().HasData(admin, customer, storeOwner);
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
                    UserId = "3",
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
                    Image = "https://image.lag.vn/upload/news/17/12/16/lien_quan_mobile_top_5_trang_bi_manh_nhung_it_dung_5_VJXG.JPG",
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
                    Image = "https://lienquan.garena.vn/files/items/icon/13b087b42ee35a7138a782d260cff7c9583eb099e321d.png",
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
                    Image = "https://lienquan.garena.vn/files/items/icon/13b087b42ee35a7138a782d260cff7c9583eb099e321d.png",
                    CategoryId = 1
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
