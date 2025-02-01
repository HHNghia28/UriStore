using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UriStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Photo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8907), new Guid("d87b4b72-609b-4979-b758-7771481da883"), false, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8910), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Coffee" },
                    { 2, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8916), new Guid("d87b4b72-609b-4979-b758-7771481da883"), false, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8917), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Tea" },
                    { 3, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8918), new Guid("d87b4b72-609b-4979-b758-7771481da883"), false, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8918), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Banh Mi" },
                    { 4, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8920), new Guid("d87b4b72-609b-4979-b758-7771481da883"), false, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8920), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Other" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4b7b0200-70f9-416a-9a3f-29ccab0deec4"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 33, 52, 78, DateTimeKind.Utc).AddTicks(5191), new DateTime(2025, 1, 19, 15, 33, 52, 78, DateTimeKind.Utc).AddTicks(5197), "$2a$11$nGXfdOOS3Kvbq5hp4l9FwuXszJ02zibFZxjQcTW1b8J.gda3e5Q2u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a85f272f-353e-4ff6-be2b-a15f1e7c0c47"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 33, 52, 191, DateTimeKind.Utc).AddTicks(9436), new DateTime(2025, 1, 19, 15, 33, 52, 191, DateTimeKind.Utc).AddTicks(9439), "$2a$11$.xXM9StIcn1PRrjml6LwrumW5YO/y1QVlyLXBEGsul0zQI.BweAAq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 33, 51, 967, DateTimeKind.Utc).AddTicks(130), new DateTime(2025, 1, 19, 15, 33, 51, 967, DateTimeKind.Utc).AddTicks(133), "$2a$11$Hb3o1tiCx4Lv35w8vim/Qumsg4Z5XxuuDp7qArm.SvwSWssuQOqbm" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "Description", "Discount", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "Name", "Photo", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"), 1, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8954), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Với chất phin êm ái, hương vị cà phê Việt Nam hiện đại kết hợp cùng hương quế nhẹ nhàng và thạch cà phê hấp dẫn.", 0, false, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8955), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "PhinDi Cassia", "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2024/Phindi_Cassia/Phindi_Cassia_Highlands_products_Image1.jpg", 55000, 325 },
                    { new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"), 1, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8970), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "PhinDi Hạt Dẻ Cười - Cà phê Phin thế hệ mới với chất Phin êm hơn, kết hợp sốt phistiachio mang đến hương vị mới lạ, không thể hấp dẫn hơn!", 5, false, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8971), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Phindi Hạt Dẻ Cười", "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2023/Phindi_Pitaschio.jpg", 65000, 0 },
                    { new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f203"), 1, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8974), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Cà phê Phin thế hệ mới với chất Phin êm hơn, kết hợp cùng Choco ngọt tan mang đến hương vị mới lạ, không thể hấp dẫn hơn!", 0, false, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8974), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "PhinDi Choco", "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__PHINDI_CHOCO.jpg", 45000, 5 },
                    { new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f204"), 2, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8977), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Golden Lotus Tea (Only Lotus seed)", 0, false, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8978), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Golden Lotus Tea (Only Lotus seed)", "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__TSV.jpg", 45000, 214 },
                    { new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f205"), 2, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8980), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "A bold tea base with juicy peaches and chewy peach jelly. Top it with milk if you prefer!", 10, false, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8981), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Peach Jelly Tea", "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__TRA_THANH_DAO-09.jpg", 45000, 45 },
                    { new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f206"), 3, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8983), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Bánh mì que gà tại Highlands Coffee mang đến hương vị đậm đà kết hợp với phô mai beo béo, không chỉ ngon miệng mà còn bổ dưỡng, phù hợp cho bữa ăn nhanh gọn.", 0, false, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8984), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Bánh Mì Que (Gà Phô Mai)", "https://www.highlandscoffee.com.vn/vnt_upload/product/11_2024/2024_Food/BMQ_Ga_Pho_Mai.png", 19000, 34 },
                    { new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f208"), 3, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8987), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Thưởng thức hương vị truyền thống với bánh mì que pate tại Highlands Coffee. Bánh mì giòn tan, kết hợp với pate thơm ngon, tạo nên một món ăn sáng hoàn hảo cho mọi người.", 0, false, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8987), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Bánh Mì Que (Pate)", "https://www.highlandscoffee.com.vn/vnt_upload/product/11_2024/2024_Food/BMQ_Pate.png", 19000, 146 },
                    { new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"), 4, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8990), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "Bò xốt vang - Một sự kết hợp mới lạ giữa hương vị thơm ngon của bò xốt vang và bánh trung thu truyền thống, mang đến một vị ngon đầy đặc sắc và độc đáo..\r\n\r\nĐẶT GIAO NGAY HOẶC GỌI 1900 1755\r\n\r\nLƯU Ý:\r\n\r\nBánh chỉ bán ở 6 tỉnh thành: Hồ Chí Minh, Hà Nội, Đà Nẵng, Đồng Nai, Bình Dương và Vũng Tàu (trừ các cửa hàng kiosk và sân bay quốc tế)", 3, false, new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8990), new Guid("d87b4b72-609b-4979-b758-7771481da883"), "BÁNH TRUNG THU - BÒ XỐT VANG - HIGHLANDS COFFEE", "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2024/Mooncake/MOONCAKES_PRODUCTSBO-XOT-VANG.png", 109000, 214 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4b7b0200-70f9-416a-9a3f-29ccab0deec4"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 19, 10, 20, 35, 94, DateTimeKind.Utc).AddTicks(6689), new DateTime(2025, 1, 19, 10, 20, 35, 94, DateTimeKind.Utc).AddTicks(6694), "$2a$11$K2ljjW0KLTPTuBc/Y8XkKOWogqiRNwbhrIZ60rD8zA9F9fRJ6QauK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a85f272f-353e-4ff6-be2b-a15f1e7c0c47"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 19, 10, 20, 35, 225, DateTimeKind.Utc).AddTicks(1997), new DateTime(2025, 1, 19, 10, 20, 35, 225, DateTimeKind.Utc).AddTicks(2009), "$2a$11$gp.29SS.au.nX8aFps57NeALwFWUlk0/beqIrLRAX0vjRNG9VvF3y" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                columns: new[] { "CreatedAt", "LastModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 19, 10, 20, 34, 972, DateTimeKind.Utc).AddTicks(3318), new DateTime(2025, 1, 19, 10, 20, 34, 972, DateTimeKind.Utc).AddTicks(3323), "$2a$11$Nha6sbTXuTwuVQTPWeioOuenNFlydhqvdvUuG0JIHUpJOjo3ksPRO" });
        }
    }
}
