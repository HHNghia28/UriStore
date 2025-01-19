using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UriStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateAuditableBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModifiedBy",
                table: "Products",
                newName: "LastModifiedById");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Products",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "LastModifiedBy",
                table: "Categories",
                newName: "LastModifiedById");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Categories",
                newName: "CreatedById");

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedById",
                table: "Products",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LastModifiedById",
                table: "Products",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedById",
                table: "Categories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LastModifiedById",
                table: "Categories",
                column: "LastModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_CreatedById",
                table: "Categories",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_LastModifiedById",
                table: "Categories",
                column: "LastModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_CreatedById",
                table: "Products",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_LastModifiedById",
                table: "Products",
                column: "LastModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_CreatedById",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_LastModifiedById",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_CreatedById",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_LastModifiedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreatedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_LastModifiedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CreatedById",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_LastModifiedById",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "LastModifiedById",
                table: "Products",
                newName: "LastModifiedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Products",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "LastModifiedById",
                table: "Categories",
                newName: "LastModifiedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Categories",
                newName: "CreatedBy");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8907), new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8910) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8916), new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8917) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8918), new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8918) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8920), new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8920) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8954), new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8955) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8970), new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8971) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f203"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8974), new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8974) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f204"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8977), new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8978) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f205"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8980), new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8981) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f206"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8983), new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8984) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f208"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8987), new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8987) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"),
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8990), new DateTime(2025, 1, 19, 15, 33, 52, 304, DateTimeKind.Utc).AddTicks(8990) });

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
        }
    }
}
