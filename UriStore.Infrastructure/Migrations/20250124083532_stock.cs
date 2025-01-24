using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UriStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class stock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Products",
                newName: "Stock");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6407), new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6411) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6420), new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6421) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6423), new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6423) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6424), new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6424) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedById", "DiscountFee", "FullName", "LastModifiedAt", "LastModifiedById", "Note", "Phone", "ShippingFee", "Status", "TotalPrice", "VoucherCode", "VoucherName", "VoucherValue" },
                values: new object[] { 20250124000001L, "Cần Thơ", new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6744), new Guid("d87b4b72-609b-4979-b758-7771481da883"), 0, "Huỳnh Hữu Nghĩa", new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6744), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Giao hàng nhanh", "0832474699", 32000, 0, 289814, "NGHIAHH", "Voucher 28/08", 24 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6460), new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6478), new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6478) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f203"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6482), new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6482) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f204"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6486), new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6486) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f205"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6488), new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6488) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f206"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6491), new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6491) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f208"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6495), new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6495) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6497), new DateTime(2025, 1, 24, 8, 35, 30, 279, DateTimeKind.Utc).AddTicks(6498) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4b7b0200-70f9-416a-9a3f-29ccab0deec4"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 24, 8, 35, 30, 53, DateTimeKind.Utc).AddTicks(9542), new DateTime(2025, 1, 24, 8, 35, 30, 53, DateTimeKind.Utc).AddTicks(9546), "$2a$11$DBL71p8DfCbRd5vAz9hFzeyrss4WhRNJi9e2Gjs7QDwSGgtBf4.iy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a85f272f-353e-4ff6-be2b-a15f1e7c0c47"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 24, 8, 35, 30, 166, DateTimeKind.Utc).AddTicks(5882), new DateTime(2025, 1, 24, 8, 35, 30, 166, DateTimeKind.Utc).AddTicks(5884), "$2a$11$ZftnQc3AEyCgoddt6dAh3eDWHSYPUZZep4dSlJFWbamflTSLKzXqi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 24, 8, 35, 29, 939, DateTimeKind.Utc).AddTicks(9358), new DateTime(2025, 1, 24, 8, 35, 29, 939, DateTimeKind.Utc).AddTicks(9359), "$2a$11$TaAHRinaGYgaEHwVgMi.5.gKzeT2ennne0a2EHyoQymIKBx0Sl.im" });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Category", "Discount", "Name", "OrderId", "Photo", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("47e95b51-1302-43c7-9604-cd5f6419b5bf"), "Coffee", 0, "PhinDi Cassia", 20250124000001L, "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2024/Phindi_Cassia/Phindi_Cassia_Highlands_products_Image1.jpg", 55000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"), 2 },
                    { new Guid("55e397cd-3191-43ae-a084-4cb8097de880"), "Coffee", 5, "Phindi Hạt Dẻ Cười", 20250124000001L, "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2023/Phindi_Pitaschio.jpg", 65000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"), 2 },
                    { new Guid("8e41a126-c936-45e3-941e-505bdc1346b5"), "Other", 3, "BÁNH TRUNG THU - BÒ XỐT VANG - HIGHLANDS COFFEE", 20250124000001L, "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2024/Mooncake/MOONCAKES_PRODUCTSBO-XOT-VANG.png", 109000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: new Guid("47e95b51-1302-43c7-9604-cd5f6419b5bf"));

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: new Guid("55e397cd-3191-43ae-a084-4cb8097de880"));

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: new Guid("8e41a126-c936-45e3-941e-505bdc1346b5"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 20250124000001L);

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Products",
                newName: "Quantity");

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
        }
    }
}
