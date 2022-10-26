using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FPTBook.Migrations
{
    public partial class FPTBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Publisher = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Page = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    CustomerEmail = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookId = table.Column<int>(nullable: true),
                    Item_Quantity = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admin", "a0dc88cc-e21c-4499-ab21-0f4bc2a4aa24", "Administrator", "Administrator" },
                    { "customer", "b1d46d99-a208-49d1-8142-79cb04c4af18", "Customer", "Customer" },
                    { "storeOwner", "28f8dc3a-ddad-4ce4-a121-aa1dc1c403b3", "StoreOwner", "StoreOwner" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3", 0, "f8610140-4a93-481e-b9aa-4be16af0279a", "storeOwner@gmail.com", true, false, null, null, "storeOwner@gmail.com", "AQAAAAEAACcQAAAAEAKeImludGimOWbzqmKa7T8bPqm7HElkTb++mVfCOfeyQ+/sh4Z+fKCXk6yYIzAisQ==", null, false, "5e77c9ba-2aa7-4eb4-8a4a-d12319e24521", false, "storeOwner@gmail.com" },
                    { "9", 0, "1320d58e-89ec-4a49-b292-87c5f58c5826", "storeOwner4@gmail.com", true, false, null, null, "storeOwner4@gmail.com", "AQAAAAEAACcQAAAAEIqajVr27XCnNhLu5iT83Psz4AgRUz3IOpL6fpmHamXrKER0S7pqihyppe5WJt3S8A==", null, false, "91036281-19aa-4be8-9efa-9b80d175ddbc", false, "storeOwner4@gmail.com" },
                    { "8", 0, "a88bf748-51c2-4874-be9e-e5efc249f719", "customer4@gmail.com", true, false, null, null, "customer4@gmail.com", "AQAAAAEAACcQAAAAEAXHCas3e7MJWv65deezuco0Hxamx3L0E2J7KnYBcS/TMAz3ayPR6Wopcu3xhzctqQ==", null, false, "6a60c127-20ac-4a36-abac-67203bd9a5eb", false, "customer4@gmail.com" },
                    { "7", 0, "af15250a-ad48-4df3-8f23-6f969bf770e5", "storeOwner3@gmail.com", true, false, null, null, "storeOwner3@gmail.com", "AQAAAAEAACcQAAAAEEd4G5pPADANL1rqUTubKdI2naKSoWxCBszYbDkeX0H7pemnxKVB6mSv6sbTzFzZJg==", null, false, "a5ba2d56-fd6e-4f28-8703-1345ec3b5215", false, "storeOwner3@gmail.com" },
                    { "6", 0, "4c4f4ba1-fc6d-4908-aae0-e1cfea5bde3c", "customer3@gmail.com", true, false, null, null, "customer3@gmail.com", "AQAAAAEAACcQAAAAEDZO8QBvCAz64xX0Fbi77XuBx2sd+eJYqT2w/dwprUpjA8cJypXzVDawyO7+ADZrYg==", null, false, "6cae41dd-a23a-4ab5-9285-7a38d6ef4fdf", false, "customer3@gmail.com" },
                    { "5", 0, "43fecadc-c81c-43ea-baed-b2042c644ee0", "storeOwner2@gmail.com", true, false, null, null, "storeOwner2@gmail.com", "AQAAAAEAACcQAAAAEP+aO1K+65kasdPjcNLfJK8Vc5HfiZvSG6vnGHHuu6enm5cNTQDIPAv77IbbkmD8OQ==", null, false, "a6fd7df1-363c-4e8d-83b1-837e1d0aa733", false, "storeOwner2@gmail.com" },
                    { "11", 0, "7c73afb9-cda2-4c93-a8d1-5e1d8224e9ab", "storeOwner5@gmail.com", true, false, null, null, "storeOwner5@gmail.com", "AQAAAAEAACcQAAAAECl90ZL1AkOafqHXpN0xxKK3ynXDnPh8y1epF0Ifu9P9eQ/BaVGe0t7tSve/SNMpxw==", null, false, "8bb749da-e908-4074-b7fb-2e8a026702c0", false, "storeOwner5@gmail.com" },
                    { "10", 0, "73873750-d4e0-4d73-8684-6a7221d58344", "customer5@gmail.com", true, false, null, null, "customer5@gmail.com", "AQAAAAEAACcQAAAAEE0bd5bc815ruUTOJxseDxxswyjXICE0VDbDyLwvV7oh9SXVnKwhVR7Jgk/Bz1Flqw==", null, false, "ae84311f-1b15-4200-ab01-1d79fb50c497", false, "customer5@gmail.com" },
                    { "2", 0, "80a2ce3e-5799-4482-bdfc-0e7fc5009a5f", "customer@gmail.com", true, false, null, null, "customer@gmail.com", "AQAAAAEAACcQAAAAEIBOB/lFBywf2KKvJ6cwxoxaz05apcEcw/0iJ4dL69osoF0a/zwyWurQZzIBWMs4Rg==", null, false, "10e2babd-74a0-43e2-8577-250c59cd3b99", false, "customer@gmail.com" },
                    { "1", 0, "52557ff0-aaa9-4827-8127-fea61990e5b2", "admin@gmail.com", true, false, null, null, "admin@gmail.com", "AQAAAAEAACcQAAAAEKWG/rI9ooB9pASBMIeys5qp1tq1i+EmEzsm4SIioGbzjRXYZ03QAFi/r8OLUkgg/A==", null, false, "a8fa5825-1dbb-4be9-9057-550b71dc9b22", false, "admin@gmail.com" },
                    { "4", 0, "fe99cd57-dcbb-4838-a290-034a0f69b543", "customer2@gmail.com", true, false, null, null, "customer2@gmail.com", "AQAAAAEAACcQAAAAEDXjE8WXqChaYQDZeONBkUGIgno+x0n6YgZF1tRPlqOPYEt0hhNCzW8qZ4LkfJ5Ofg==", null, false, "32e28eb8-e737-4267-9025-5a78aada5ff0", false, "customer2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 3, "everyone", "Science" },
                    { 2, "12+", "Manga" },
                    { 1, "18+", "Horror" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "11", "storeOwner" },
                    { "9", "storeOwner" },
                    { "8", "customer" },
                    { "7", "storeOwner" },
                    { "6", "customer" },
                    { "5", "storeOwner" },
                    { "4", "customer" },
                    { "2", "customer" },
                    { "1", "admin" },
                    { "10", "customer" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "Image", "Page", "Price", "Publisher", "Quantity", "Title", "Year" },
                values: new object[,]
                {
                    { 20, "zhongli", 3, "In the era offficlectr e of the refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "sc11.webp", 999, 9999.0, "Manh Tung", 3, "Shape history", 2004 },
                    { 21, "Sciencer", 3, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "sc4.webp", 1093, 225.19999999999999, "Sciencer", 3, "The sience of can and can't ", 1997 },
                    { 19, "Geoper", 3, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "sc3.webp", 299, 29.600000000000001, "Geoper", 19, "Geopedia", 1991 },
                    { 18, "PDPT", 3, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "sc8.webp", 100, 59.0, "Trog non", 5, "Hand made", 2002 },
                    { 17, "Edison second", 3, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "sc2.webp", 10, 5999.0, "Edison", 100, "Beeeeeeeeeee", 1951 },
                    { 16, "Edison", 3, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "sc1.webp", 10, 599.0, "Edison", 100, "Be who you want", 1950 },
                    { 9, "Eichiro Oda", 2, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "op6.jpg", 200, 2.1899999999999999, "Eichiro Oda", 10, "One piece vol 25", 1999 },
                    { 8, "Eichiro Oda", 2, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "op5.jpg", 200, 2.1899999999999999, "Eichiro Oda", 5, "One piece vol 21", 1999 },
                    { 7, "Eichiro Oda", 2, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "op4.jpg", 200, 1.99, "Eichiro Oda", 7, "One piece vol 16", 1999 },
                    { 6, "Eichiro Oda", 2, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "op3.jpg", 200, 2.0899999999999999, "Eichiro Oda", 15, "One piece vol 15", 1999 },
                    { 5, "Eichiro Oda", 2, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "op2.jpg", 200, 2.9900000000000002, "Eichiro Oda", 15, "One piece vol 10", 1998 },
                    { 4, "Eichiro Oda", 2, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "op1.jpg", 200, 2.1899999999999999, "Eichiro Oda", 15, "One piece vol 1", 1997 },
                    { 2, "Manh Tung", 2, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "st.png", 49, 195.0, "Manh Tung", 10, "How to defeat", 2020 },
                    { 15, "Vladimir Putin", 1, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "hor6.jpg", 10, 99.0, "Vladimir Putin", 10, "Monday is tomorrow vol 5", 2022 },
                    { 14, "Vladimir Putin", 1, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "hor5.jpg", 10, 169.0, "Manh Tung", 10, "Monday is tomorrow vol 4", 2022 },
                    { 13, "Vladimir Putin", 1, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "hor4.jpg", 10, 169.0, "Manh Tung", 10, "Monday is tomorrow vol 3", 2021 },
                    { 12, "Joker", 1, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "hor3.jpg", 10, 159.0, "Joker", 9, "Monday is tomorrow vol 2", 2020 },
                    { 11, "Manh Tung", 1, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "hor2.jpg", 10, 149.0, "Manh Tung", 9, "Monday is tomorrow vol 1", 2020 },
                    { 10, "Manh Tung", 1, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "hor1.jpg", 500, 197.0, "Manh Tung", 1, "Horro1", 2018 },
                    { 1, "Manh Tung", 3, "dexplosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment", "sth.png", 99, 199.0, "Manh Tung", 5, "How to have megakill", 2022 },
                    { 3, "Manh Tung", 1, @"In the era of economic development, digital transformation is taking place rapidly, the demand for energy use and storage is enormous. Therefore, the use of power storage devices to be able to
                charge electrical devices is a lot. Batteries are an incredibly efficient storage tool that can be reused over and over again. With the explosion of electric cars today, the use of electric cars is a solution to replace cars using gasoline fuels to limit gas emissions into the environment. However, when used a lot, it will lead to battery bottles, reducing the storage capacity of the battery. Currently, people are faced with the elimination of a large number of electric vehicle batteries. Thereby, increasing the amount of batteries discharged into the environment, causing great environmental pollution. As a member of the research and development department, I was assigned a small project to explore solutions to the impact of digital terminals and how to reduce their impact on the environment or functionality. potential to refurbish, repair and reuse digital devices instead of replacing them. And the main topic that I will talk about in this report is ", "sth.png", 49, 195.0, "Manh Tung", 10, "You are mine", 2019 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BookId",
                table: "Bills",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_bookId",
                table: "Items",
                column: "bookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
