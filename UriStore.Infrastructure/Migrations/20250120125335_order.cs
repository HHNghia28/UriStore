using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UriStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ShippingFee = table.Column<int>(type: "integer", nullable: false),
                    DiscountFee = table.Column<int>(type: "integer", nullable: false),
                    VoucherName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    VoucherCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    VoucherValue = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Photo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2324), new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2327) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2334), new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2334) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2335), new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2336) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2337), new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2337) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedById", "DiscountFee", "FullName", "LastModifiedAt", "LastModifiedById", "Note", "Phone", "ShippingFee", "Status", "TotalPrice", "VoucherCode", "VoucherName", "VoucherValue" },
                values: new object[] { new Guid("780bdfae-15d0-460d-af8a-b6eb9cb0d44e"), "Cần Thơ", new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2582), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), 0, "Huỳnh Hữu Nghĩa", new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2583), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "Giao hàng nhanh", "0832474699", 32000, 0, 289814, "NGHIAHH", "Voucher 28/08", 24 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2375), new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2375) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2395), new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2395) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f203"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2399), new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2399) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f204"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2402), new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2402) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f205"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2405), new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2406) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f206"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2408), new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2408) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f208"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2411), new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2412) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2413), new DateTime(2025, 1, 20, 12, 53, 33, 358, DateTimeKind.Utc).AddTicks(2414) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4b7b0200-70f9-416a-9a3f-29ccab0deec4"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 53, 33, 134, DateTimeKind.Utc).AddTicks(1060), new DateTime(2025, 1, 20, 12, 53, 33, 134, DateTimeKind.Utc).AddTicks(1063), "$2a$11$i2CpUAG9isX.hw8Kn2itW.mB8zYIgIJAMLjlXmMZQIsVTgEjAjyjG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a85f272f-353e-4ff6-be2b-a15f1e7c0c47"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 53, 33, 246, DateTimeKind.Utc).AddTicks(7144), new DateTime(2025, 1, 20, 12, 53, 33, 246, DateTimeKind.Utc).AddTicks(7147), "$2a$11$r29lQlN7UOgqJpXr6Mivs.gIG9NumJSH40AfakV049JoMz5lIP3qq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 53, 33, 22, DateTimeKind.Utc).AddTicks(9578), new DateTime(2025, 1, 20, 12, 53, 33, 22, DateTimeKind.Utc).AddTicks(9582), "$2a$11$ycm1GWGTLuJuxq010juzwO4nHKarUx3/a2qf2TOSC4IEtrCZ2rzrK" });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Category", "Discount", "Name", "OrderId", "Photo", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("17e1e257-de51-4653-91e8-ea069cf04cc1"), "Coffee", 0, "PhinDi Cassia", new Guid("780bdfae-15d0-460d-af8a-b6eb9cb0d44e"), "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2024/Phindi_Cassia/Phindi_Cassia_Highlands_products_Image1.jpg", 55000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"), 2 },
                    { new Guid("75d38986-2f93-4d51-ab7c-bdc8a1bc4a90"), "Coffee", 5, "Phindi Hạt Dẻ Cười", new Guid("780bdfae-15d0-460d-af8a-b6eb9cb0d44e"), "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2023/Phindi_Pitaschio.jpg", 65000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"), 2 },
                    { new Guid("bf701b54-0022-470b-8dc8-59666fd3abb8"), "Other", 3, "BÁNH TRUNG THU - BÒ XỐT VANG - HIGHLANDS COFFEE", new Guid("780bdfae-15d0-460d-af8a-b6eb9cb0d44e"), "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2024/Mooncake/MOONCAKES_PRODUCTSBO-XOT-VANG.png", 109000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3414), new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3418) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3426), new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3426) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3428), new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3428) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3429), new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3429) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3464), new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3464) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3486), new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3486) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f203"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3490), new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3490) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f204"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3493), new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3493) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f205"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3497), new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3498) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f206"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3502), new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3502) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f208"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3505), new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3505) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3508), new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3508) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4b7b0200-70f9-416a-9a3f-29ccab0deec4"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 51, 32, 382, DateTimeKind.Utc).AddTicks(2175), new DateTime(2025, 1, 19, 15, 51, 32, 382, DateTimeKind.Utc).AddTicks(2181), "$2a$11$Djs/yoOLqyFbq6L2CaTbIOwl9UeeAVy.5MpUg1PiUISavYCk.TiJi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a85f272f-353e-4ff6-be2b-a15f1e7c0c47"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 51, 32, 498, DateTimeKind.Utc).AddTicks(9237), new DateTime(2025, 1, 19, 15, 51, 32, 498, DateTimeKind.Utc).AddTicks(9242), "$2a$11$ACun7mTyhjmJyPsYVRyxQedMPo5D7IbMM6y7yCtFR8euN8QoFi5Vi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 51, 32, 268, DateTimeKind.Utc).AddTicks(7993), new DateTime(2025, 1, 19, 15, 51, 32, 268, DateTimeKind.Utc).AddTicks(7995), "$2a$11$7fGWNzMwM8lYbf9LHrWzguCzet59Mh/zhM6xOeoos9ZbAZ/BY4/HW" });
        }
    }
}
