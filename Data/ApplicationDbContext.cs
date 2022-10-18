using FPTBook.Models;
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedCategory(builder);
            SeedBook(builder);
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
