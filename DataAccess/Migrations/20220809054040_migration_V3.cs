using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class migration_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 580, DateTimeKind.Local).AddTicks(9094), new DateTime(2022, 8, 9, 8, 40, 39, 580, DateTimeKind.Local).AddTicks(9095) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 580, DateTimeKind.Local).AddTicks(9099), new DateTime(2022, 8, 9, 8, 40, 39, 580, DateTimeKind.Local).AddTicks(9100) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 580, DateTimeKind.Local).AddTicks(9103), new DateTime(2022, 8, 9, 8, 40, 39, 580, DateTimeKind.Local).AddTicks(9104) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 580, DateTimeKind.Local).AddTicks(9106), new DateTime(2022, 8, 9, 8, 40, 39, 580, DateTimeKind.Local).AddTicks(9107) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 580, DateTimeKind.Local).AddTicks(9110), new DateTime(2022, 8, 9, 8, 40, 39, 580, DateTimeKind.Local).AddTicks(9111) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 580, DateTimeKind.Local).AddTicks(9114), new DateTime(2022, 8, 9, 8, 40, 39, 580, DateTimeKind.Local).AddTicks(9114) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(8203), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(8204) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(8208), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(8209) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(8213), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(8214) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(8217), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(8217) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(8229), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(8232), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(8233) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4793), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4794) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4800), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4801) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4805), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4806) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4810), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4811) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4814), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4815) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4820), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4821) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4824), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4825) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4829), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4830) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4833), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4834) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4838), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4838) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4842), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4843) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4846), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(4847) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(9600), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(9601) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(9604), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(9605) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(9608), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(9609) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(9612), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(9613) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(9616), new DateTime(2022, 8, 9, 8, 40, 39, 581, DateTimeKind.Local).AddTicks(9617) });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "ID", "CreatedDate", "IsDeleted", "IsRead", "Message", "ModifiedDate" },
                values: new object[] { 1, new DateTime(2022, 8, 9, 5, 40, 39, 586, DateTimeKind.Utc).AddTicks(457), false, false, "ilk bilidirim mesajı :)", new DateTime(2022, 8, 9, 5, 40, 39, 586, DateTimeKind.Utc).AddTicks(458) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 751, DateTimeKind.Local).AddTicks(9204), new DateTime(2022, 8, 1, 13, 57, 28, 751, DateTimeKind.Local).AddTicks(9205) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 751, DateTimeKind.Local).AddTicks(9210), new DateTime(2022, 8, 1, 13, 57, 28, 751, DateTimeKind.Local).AddTicks(9211) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 751, DateTimeKind.Local).AddTicks(9214), new DateTime(2022, 8, 1, 13, 57, 28, 751, DateTimeKind.Local).AddTicks(9215) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 751, DateTimeKind.Local).AddTicks(9218), new DateTime(2022, 8, 1, 13, 57, 28, 751, DateTimeKind.Local).AddTicks(9218) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 751, DateTimeKind.Local).AddTicks(9221), new DateTime(2022, 8, 1, 13, 57, 28, 751, DateTimeKind.Local).AddTicks(9222) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 751, DateTimeKind.Local).AddTicks(9225), new DateTime(2022, 8, 1, 13, 57, 28, 751, DateTimeKind.Local).AddTicks(9225) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(8041), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(8042) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(8046), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(8047) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(8050), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(8051) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(8054), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(8055) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(8057), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(8058) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(8061), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(8062) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5132), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5133) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5141), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5142) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5148), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5149) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5157), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5161) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5165), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5166) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5169), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5170) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5173), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5174) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5178), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5178) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5182), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5182) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5186), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5187) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5190), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5191) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5194), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(5195) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(9163), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(9164) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(9168), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(9169) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(9172), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(9173) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(9176), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(9177) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(9179), new DateTime(2022, 8, 1, 13, 57, 28, 752, DateTimeKind.Local).AddTicks(9180) });
        }
    }
}
