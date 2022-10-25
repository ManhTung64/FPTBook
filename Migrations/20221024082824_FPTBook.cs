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
                    { "admin", "cf20329d-9e08-430f-9610-d37eeac18257", "Administrator", "Administrator" },
                    { "customer", "a6b5328c-afb1-43d4-81ca-ad9dbce699fb", "Customer", "Customer" },
                    { "storeOwner", "3474018c-771a-46cd-8ae1-318cc1bd57b5", "StoreOwner", "StoreOwner" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3", 0, "149cc77d-c153-44b2-bffa-963d0e199bcf", "storeOwner@gmail.com", true, false, null, null, "storeOwner@gmail.com", "AQAAAAEAACcQAAAAELq6Mo4/c4ZDZELNLH2Q7so0FyfYliF7ggS4Xxv0UI5FRb2CUzVIGpUUfIp3HqU0kQ==", null, false, "19600d13-5dac-4798-9a44-f3e03af23a27", false, "storeOwner@gmail.com" },
                    { "9", 0, "1fdb51df-e5d4-4b5e-8de2-1de8c68bfba4", "storeOwner4@gmail.com", true, false, null, null, "storeOwner4@gmail.com", "AQAAAAEAACcQAAAAEAulHHJxGCtPfCNHsFSy4auw5yM0B2ZnR3/ToTqPR8M6mUthkbrUauX6kmNqa3IyEA==", null, false, "087e455e-e7cd-4b7a-b73d-42dab3b91b28", false, "storeOwner4@gmail.com" },
                    { "8", 0, "55120bc1-a9df-404e-b4f3-5df0ab5fe88a", "customer4@gmail.com", true, false, null, null, "customer4@gmail.com", "AQAAAAEAACcQAAAAEODv7oTJk2oJfu2xt1tUOHL6/Sv6I6zsn57hQxZA9cpukUTMa+Em9UXfTrx4eQY+xA==", null, false, "65dd92b9-01e6-4021-b656-da93b828f80f", false, "customer4@gmail.com" },
                    { "7", 0, "d922d73f-8660-4925-8928-38a8ad2c414b", "storeOwner3@gmail.com", true, false, null, null, "storeOwner3@gmail.com", "AQAAAAEAACcQAAAAEHUg+6pQPR2KqwFHpuGCl+E8D9CvArqNHU0kp5h9yxg454xBYJHeeX7i2h18n+I0YA==", null, false, "e0df6c83-0a95-4fca-8721-1775fb899347", false, "storeOwner3@gmail.com" },
                    { "6", 0, "0400aecc-4830-4c49-8d79-80ea38cb1200", "customer3@gmail.com", true, false, null, null, "customer3@gmail.com", "AQAAAAEAACcQAAAAECq5BRH6Vrkmr2DvsuLTBYW0lugsA7W+r597IIOwqvNfKMkpiSWEvbWycd9VrJEseA==", null, false, "18ea4c2a-218d-49f0-8f96-5e95474b4e88", false, "customer3@gmail.com" },
                    { "5", 0, "92d6e533-b5c6-48d7-ac6c-22946d91f5ac", "storeOwner2@gmail.com", true, false, null, null, "storeOwner2@gmail.com", "AQAAAAEAACcQAAAAELLir18QmT+VA8FXz6uAgZEEuxF20JOMZGAn3VzLiaESATfhRxDFAqsWNyaheUSUJg==", null, false, "ab4a55d3-fd03-458b-b188-30902353eabd", false, "storeOwner2@gmail.com" },
                    { "11", 0, "9f6a6709-3b55-42d4-92ed-b0e005557126", "storeOwner5@gmail.com", true, false, null, null, "storeOwner5@gmail.com", "AQAAAAEAACcQAAAAEPK7zPVuDqOWE94k1v7Yjf6BxK+OgPfVCup+CkeKsToYrea11XPVvVzSTV4aS0F0dg==", null, false, "21670b2b-b49b-402b-a99b-5d01a593fa12", false, "storeOwner5@gmail.com" },
                    { "10", 0, "c5b2174c-b07e-4df0-9b79-c6e822fde2df", "customer5@gmail.com", true, false, null, null, "customer5@gmail.com", "AQAAAAEAACcQAAAAEOD2U2kZwOdCXR/gLcuWx591SIAq67ze3QhNsezYqaFw06rxmppKT4TcJBvrN/Ub6g==", null, false, "9065d6b3-ba7a-4c84-bace-a1423b9831c0", false, "customer5@gmail.com" },
                    { "2", 0, "b8707a02-f8cb-44f0-803a-5c25df36e35a", "customer@gmail.com", true, false, null, null, "customer@gmail.com", "AQAAAAEAACcQAAAAEG0kSINPB/yzS4l/OCI6Iowr3Ro7ZiEnAJb4v1b8lUgPhA97uizmwPoJwlKQhI7pkw==", null, false, "05343659-c7a2-43b4-ad42-85992f51bd04", false, "customer@gmail.com" },
                    { "1", 0, "6b992344-a757-4cf0-b7d5-b3812fa91bba", "admin@gmail.com", true, false, null, null, "admin@gmail.com", "AQAAAAEAACcQAAAAEMt1fdfJQkIoUH7PlurIAoU4QFXAJtJkGj5lIcAlsLf414YEvyR/WwoumDE7518VHQ==", null, false, "2b89b10c-21f3-44f5-bcac-3d98012d53ab", false, "admin@gmail.com" },
                    { "4", 0, "e6304050-2b63-43c5-84dc-b3911f4bba99", "customer2@gmail.com", true, false, null, null, "customer2@gmail.com", "AQAAAAEAACcQAAAAEGjDtLnEoSSrqywmQw9r9UD7E+Dfy5F1Iie+ojg4f/P0XAGIzXyE6LXu/1bWSwgpUw==", null, false, "a41de85a-94c9-4d16-ae72-35c08655ca3f", false, "customer2@gmail.com" }
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
                columns: new[] { "Id", "Author", "CategoryId", "Image", "Page", "Price", "Publisher", "Quantity", "Title", "Year" },
                values: new object[,]
                {
                    { 20, "zhongli", 3, "sc11.webp", 999, 9999.0, "Manh Tung", 3, "Shape history", 2004 },
                    { 21, "Sciencer", 3, "sc4.webp", 1093, 225.19999999999999, "Sciencer", 3, "The sience of can and can't ", 1997 },
                    { 19, "Geoper", 3, "sc3.webp", 299, 29.600000000000001, "Geoper", 19, "Geopedia", 1991 },
                    { 18, "PDPT", 3, "sc8.webp", 100, 59.0, "Trog non", 5, "Hand made", 2002 },
                    { 17, "Edison second", 3, "sc2.webp", 10, 5999.0, "Edison", 100, "Beeeeeeeeeee", 1951 },
                    { 16, "Edison", 3, "sc1.webp", 10, 599.0, "Edison", 100, "Be who you want", 1950 },
                    { 9, "Eichiro Oda", 2, "op6.jpg", 200, 2.1899999999999999, "Eichiro Oda", 10, "One piece vol 25", 1999 },
                    { 8, "Eichiro Oda", 2, "op5.jpg", 200, 2.1899999999999999, "Eichiro Oda", 5, "One piece vol 21", 1999 },
                    { 7, "Eichiro Oda", 2, "op4.jpg", 200, 1.99, "Eichiro Oda", 7, "One piece vol 16", 1999 },
                    { 6, "Eichiro Oda", 2, "op3.jpg", 200, 2.0899999999999999, "Eichiro Oda", 15, "One piece vol 15", 1999 },
                    { 5, "Eichiro Oda", 2, "op2.jpg", 200, 2.9900000000000002, "Eichiro Oda", 15, "One piece vol 10", 1998 },
                    { 4, "Eichiro Oda", 2, "op1.jpg", 200, 2.1899999999999999, "Eichiro Oda", 15, "One piece vol 1", 1997 },
                    { 2, "Manh Tung", 2, "st.png", 49, 195.0, "Manh Tung", 10, "How to defeat", 2020 },
                    { 15, "Vladimir Putin", 1, "hor6.jpg", 10, 99.0, "Vladimir Putin", 10, "Monday is tomorrow vol 5", 2022 },
                    { 14, "Vladimir Putin", 1, "hor5.jpg", 10, 169.0, "Manh Tung", 10, "Monday is tomorrow vol 4", 2022 },
                    { 13, "Vladimir Putin", 1, "hor4.jpg", 10, 169.0, "Manh Tung", 10, "Monday is tomorrow vol 3", 2021 },
                    { 12, "Joker", 1, "hor3.jpg", 10, 159.0, "Joker", 9, "Monday is tomorrow vol 2", 2020 },
                    { 11, "Manh Tung", 1, "hor2.jpg", 10, 149.0, "Manh Tung", 9, "Monday is tomorrow vol 1", 2020 },
                    { 10, "Manh Tung", 1, "hor1.jpg", 500, 197.0, "Manh Tung", 1, "Horro1", 2018 },
                    { 1, "Manh Tung", 3, "sth.png", 99, 199.0, "Manh Tung", 5, "How to have megakill", 2022 },
                    { 3, "Manh Tung", 1, "sth.png", 49, 195.0, "Manh Tung", 10, "You are mine", 2019 }
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
