using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class migration_V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StarCount",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StarRate",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 162, DateTimeKind.Local).AddTicks(5676), new DateTime(2022, 8, 13, 14, 14, 9, 162, DateTimeKind.Local).AddTicks(5676) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 162, DateTimeKind.Local).AddTicks(5679), new DateTime(2022, 8, 13, 14, 14, 9, 162, DateTimeKind.Local).AddTicks(5680) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 162, DateTimeKind.Local).AddTicks(5682), new DateTime(2022, 8, 13, 14, 14, 9, 162, DateTimeKind.Local).AddTicks(5682) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 162, DateTimeKind.Local).AddTicks(5684), new DateTime(2022, 8, 13, 14, 14, 9, 162, DateTimeKind.Local).AddTicks(5685) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 162, DateTimeKind.Local).AddTicks(5687), new DateTime(2022, 8, 13, 14, 14, 9, 162, DateTimeKind.Local).AddTicks(5687) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 162, DateTimeKind.Local).AddTicks(5689), new DateTime(2022, 8, 13, 14, 14, 9, 162, DateTimeKind.Local).AddTicks(5690) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2020), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2021) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2024), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2024) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2026), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2027) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2029), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2030) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2032), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2032) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2035), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2035) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(90), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(91) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(96), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(96) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(100), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(100) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(103), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(104) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(107), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(107) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(116), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(117) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(119), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(120) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(122), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(123) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(125), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(126) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(128), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(129) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(131), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(132) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(134), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(135) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2990), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2993), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2993) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2996), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2996) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2999), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(2999) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(3001), new DateTime(2022, 8, 13, 14, 14, 9, 163, DateTimeKind.Local).AddTicks(3002) });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 11, 14, 9, 165, DateTimeKind.Utc).AddTicks(8000), new DateTime(2022, 8, 13, 11, 14, 9, 165, DateTimeKind.Utc).AddTicks(8001) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StarCount",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "StarRate",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Brands");

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

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 5, 40, 39, 586, DateTimeKind.Utc).AddTicks(457), new DateTime(2022, 8, 9, 5, 40, 39, 586, DateTimeKind.Utc).AddTicks(458) });
        }
    }
}
