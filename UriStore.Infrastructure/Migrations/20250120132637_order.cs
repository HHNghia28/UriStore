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
                    table.ForeignKey(
                        name: "FK_Orders_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                values: new object[] { new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(457), new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(460) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(467), new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(467) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(468), new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(469) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(470), new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(470) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedById", "DiscountFee", "FullName", "LastModifiedAt", "LastModifiedById", "Note", "Phone", "ShippingFee", "Status", "TotalPrice", "VoucherCode", "VoucherName", "VoucherValue" },
                values: new object[] { new Guid("9fda4053-eeac-49a6-92b2-242f745fc19c"), "Cần Thơ", new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(742), new Guid("d87b4b72-609b-4979-b758-7771481da883"), 0, "Huỳnh Hữu Nghĩa", new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(748), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Giao hàng nhanh", "0832474699", 32000, 0, 289814, "NGHIAHH", "Voucher 28/08", 24 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(506), new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(506) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(646), new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(646) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f203"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(650), new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(650) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f204"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(653), new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(654) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f205"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(656), new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(657) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f206"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(659), new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(660) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f208"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(662), new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(662) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(665), new DateTime(2025, 1, 20, 13, 26, 37, 349, DateTimeKind.Utc).AddTicks(665) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4b7b0200-70f9-416a-9a3f-29ccab0deec4"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 20, 13, 26, 37, 114, DateTimeKind.Utc).AddTicks(1315), new DateTime(2025, 1, 20, 13, 26, 37, 114, DateTimeKind.Utc).AddTicks(1318), "$2a$11$apf7sdPrYu8R8raOHaZuGOOtci/rFDMH2Ssk2C2q9hhh9lQ.y75J." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a85f272f-353e-4ff6-be2b-a15f1e7c0c47"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 20, 13, 26, 37, 232, DateTimeKind.Utc).AddTicks(6867), new DateTime(2025, 1, 20, 13, 26, 37, 232, DateTimeKind.Utc).AddTicks(6878), "$2a$11$V6kZbRt1cMi6ayCjJeOnv.u61Cf0MpmtoSKH0q/3I5EmahooSxSXe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 20, 13, 26, 37, 1, DateTimeKind.Utc).AddTicks(5943), new DateTime(2025, 1, 20, 13, 26, 37, 1, DateTimeKind.Utc).AddTicks(5946), "$2a$11$NJu7KPgZ9eW54YyrzUdsHuip/6.pwsoFqJzBt2tdalsb4gBFmliQa" });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Category", "Discount", "Name", "OrderId", "Photo", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("7b5eb911-df1a-43e3-bbf7-f3d7731f02a0"), "Coffee", 0, "PhinDi Cassia", new Guid("9fda4053-eeac-49a6-92b2-242f745fc19c"), "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2024/Phindi_Cassia/Phindi_Cassia_Highlands_products_Image1.jpg", 55000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"), 2 },
                    { new Guid("b7d9bf32-4990-41e3-94ee-8cbebbf11075"), "Coffee", 5, "Phindi Hạt Dẻ Cười", new Guid("9fda4053-eeac-49a6-92b2-242f745fc19c"), "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2023/Phindi_Pitaschio.jpg", 65000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"), 2 },
                    { new Guid("fe6ea58a-8305-4c89-b208-ecc6950593fa"), "Other", 3, "BÁNH TRUNG THU - BÒ XỐT VANG - HIGHLANDS COFFEE", new Guid("9fda4053-eeac-49a6-92b2-242f745fc19c"), "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2024/Mooncake/MOONCAKES_PRODUCTSBO-XOT-VANG.png", 109000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedById",
                table: "Orders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LastModifiedById",
                table: "Orders",
                column: "LastModifiedById");
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
