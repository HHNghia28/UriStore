using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UriStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: new Guid("224a59c1-d620-42ed-b9de-e2e426d4bcfa"));

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: new Guid("9c2199de-7e23-4c27-b222-6a8840afd334"));

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: new Guid("f17d969f-7bba-49ce-bc92-c0497ecb3313"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 20250120000001L);

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    AmountCharged = table.Column<int>(type: "integer", nullable: false),
                    TimeCharge = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    PaymentLink = table.Column<string>(type: "text", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_Id",
                        column: x => x.Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(129), new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(133) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(139), new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(140) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(141), new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(141) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(142), new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(142) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedById", "DiscountFee", "FullName", "LastModifiedAt", "LastModifiedById", "Note", "Phone", "ShippingFee", "Status", "TotalPrice", "VoucherCode", "VoucherName", "VoucherValue" },
                values: new object[] { 20250123000001L, "Cần Thơ", new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(575), new Guid("d87b4b72-609b-4979-b758-7771481da883"), 0, "Huỳnh Hữu Nghĩa", new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(576), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Giao hàng nhanh", "0832474699", 32000, 0, 289814, "NGHIAHH", "Voucher 28/08", 24 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(173), new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(173) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(197), new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(197) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f203"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(200), new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(201) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f204"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(204), new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(204) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f205"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(309), new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(309) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f206"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(312), new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(314) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f208"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(317), new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(317) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(321), new DateTime(2025, 1, 23, 10, 9, 11, 473, DateTimeKind.Utc).AddTicks(321) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4b7b0200-70f9-416a-9a3f-29ccab0deec4"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 23, 10, 9, 11, 242, DateTimeKind.Utc).AddTicks(257), new DateTime(2025, 1, 23, 10, 9, 11, 242, DateTimeKind.Utc).AddTicks(262), "$2a$11$uM6an/JePadYtWqoG6ir4.DGX75Kcp7XlgzIMWLES/5H6ou19qWZC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a85f272f-353e-4ff6-be2b-a15f1e7c0c47"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 23, 10, 9, 11, 357, DateTimeKind.Utc).AddTicks(9048), new DateTime(2025, 1, 23, 10, 9, 11, 357, DateTimeKind.Utc).AddTicks(9055), "$2a$11$6j8L1SKbYypgJq2mKS.oZOg9THIp.TaVmgpXQr4EnqszNlB4zevVm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 23, 10, 9, 11, 129, DateTimeKind.Utc).AddTicks(9191), new DateTime(2025, 1, 23, 10, 9, 11, 129, DateTimeKind.Utc).AddTicks(9194), "$2a$11$oOdfG20/cTfnEZug9Fh99eIVcUUYfAHo2OZjjMzon9NQd9ENeEY3i" });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Category", "Discount", "Name", "OrderId", "Photo", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("7408f5e9-8d11-4595-9073-a229cde8d9f3"), "Coffee", 5, "Phindi Hạt Dẻ Cười", 20250123000001L, "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2023/Phindi_Pitaschio.jpg", 65000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"), 2 },
                    { new Guid("81057874-55f2-4b21-9771-5b7aa889af71"), "Other", 3, "BÁNH TRUNG THU - BÒ XỐT VANG - HIGHLANDS COFFEE", 20250123000001L, "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2024/Mooncake/MOONCAKES_PRODUCTSBO-XOT-VANG.png", 109000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"), 1 },
                    { new Guid("a6fcff75-dcd9-4c7b-8bbd-7b9c512fd404"), "Coffee", 0, "PhinDi Cassia", 20250123000001L, "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2024/Phindi_Cassia/Phindi_Cassia_Highlands_products_Image1.jpg", 55000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CreatedById",
                table: "Payments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_LastModifiedById",
                table: "Payments",
                column: "LastModifiedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: new Guid("7408f5e9-8d11-4595-9073-a229cde8d9f3"));

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: new Guid("81057874-55f2-4b21-9771-5b7aa889af71"));

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: new Guid("a6fcff75-dcd9-4c7b-8bbd-7b9c512fd404"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 20250123000001L);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(7940), new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(7943) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(7955), new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(7955) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(7957), new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(7957) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(7958), new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(7958) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedById", "DiscountFee", "FullName", "LastModifiedAt", "LastModifiedById", "Note", "Phone", "ShippingFee", "Status", "TotalPrice", "VoucherCode", "VoucherName", "VoucherValue" },
                values: new object[] { 20250120000001L, "Cần Thơ", new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(8237), new Guid("d87b4b72-609b-4979-b758-7771481da883"), 0, "Huỳnh Hữu Nghĩa", new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(8238), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Giao hàng nhanh", "0832474699", 32000, 0, 289814, "NGHIAHH", "Voucher 28/08", 24 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(7996), new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(7997) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(8016), new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(8016) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f203"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(8020), new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(8020) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f204"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(8023), new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(8023) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f205"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(8026), new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(8026) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f206"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(8033), new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(8033) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f208"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(8036), new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(8037) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(8039), new DateTime(2025, 1, 20, 14, 6, 27, 7, DateTimeKind.Utc).AddTicks(8040) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4b7b0200-70f9-416a-9a3f-29ccab0deec4"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 20, 14, 6, 26, 771, DateTimeKind.Utc).AddTicks(8390), new DateTime(2025, 1, 20, 14, 6, 26, 771, DateTimeKind.Utc).AddTicks(8398), "$2a$11$e.y4ZcWO6lNnMuAiRKnsu.xO5ScxG//yN/yP2aCsRtPJIgWw.2K5C" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a85f272f-353e-4ff6-be2b-a15f1e7c0c47"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 20, 14, 6, 26, 889, DateTimeKind.Utc).AddTicks(2777), new DateTime(2025, 1, 20, 14, 6, 26, 889, DateTimeKind.Utc).AddTicks(2781), "$2a$11$ex5V1Lz91leCEqULZR/nbeiZqc/qhYIKdyrBVx6YEr5BXZ.ExEfpi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 20, 14, 6, 26, 655, DateTimeKind.Utc).AddTicks(2262), new DateTime(2025, 1, 20, 14, 6, 26, 655, DateTimeKind.Utc).AddTicks(2265), "$2a$11$OGk/fwV7gysB.L/QDSJWV.0rWSZvgHOCKRx5I5MIPh3jrIGr6lLLu" });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Category", "Discount", "Name", "OrderId", "Photo", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("224a59c1-d620-42ed-b9de-e2e426d4bcfa"), "Other", 3, "BÁNH TRUNG THU - BÒ XỐT VANG - HIGHLANDS COFFEE", 20250120000001L, "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2024/Mooncake/MOONCAKES_PRODUCTSBO-XOT-VANG.png", 109000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"), 1 },
                    { new Guid("9c2199de-7e23-4c27-b222-6a8840afd334"), "Coffee", 0, "PhinDi Cassia", 20250120000001L, "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2024/Phindi_Cassia/Phindi_Cassia_Highlands_products_Image1.jpg", 55000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"), 2 },
                    { new Guid("f17d969f-7bba-49ce-bc92-c0497ecb3313"), "Coffee", 5, "Phindi Hạt Dẻ Cười", 20250120000001L, "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2023/Phindi_Pitaschio.jpg", 65000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"), 2 }
                });
        }
    }
}
