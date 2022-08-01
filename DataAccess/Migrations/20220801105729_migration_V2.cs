using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class migration_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Sales_SaleId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Payments_SaleId",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "Payments",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EODDate",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservationDate",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CarId",
                table: "Payments",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Cars_CarId",
                table: "Payments",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_UserId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Cars_CarId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_CarId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "EODDate",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ReservationDate",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Payments",
                newName: "SaleId");

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    EODDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sales_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3079), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3082), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3083) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3085), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3086) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3087), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3088) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3090), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3092), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3093) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8324), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8325) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8327), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8327) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8329), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8330) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8332), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8332) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8334), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8335) });

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8336), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8337) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6410), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6411) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6414), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6415) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6418), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6418) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6421), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6421) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6423), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6424) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6432), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6433) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6435), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6436) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6438), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6438) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6441), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6441) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6444), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6444) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6446), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6447) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6450), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6450) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9178), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9179) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9180), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9181) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9183), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9183) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9185), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9186) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9187), new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9188) });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_SaleId",
                table: "Payments",
                column: "SaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CarId",
                table: "Sales",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId",
                table: "Sales",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Sales_SaleId",
                table: "Payments",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
