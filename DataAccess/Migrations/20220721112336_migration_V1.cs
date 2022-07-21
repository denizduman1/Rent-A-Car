using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class migration_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Star = table.Column<short>(type: "smallint", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CarModels_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransmissionType = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    DailyPrice = table.Column<int>(type: "int", nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CurrentCount = table.Column<int>(type: "int", nullable: false),
                    TotalCount = table.Column<int>(type: "int", nullable: false),
                    CarModelId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cars_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    EODDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayCount = table.Column<short>(type: "smallint", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payments_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "ID", "CreatedDate", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3079), false, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3080), "Hyundai" },
                    { 2, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3082), false, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3083), "Bmw" },
                    { 3, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3085), false, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3086), "Volvo" },
                    { 4, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3087), false, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3088), "Renault" },
                    { 5, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3090), false, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3090), "Opel" },
                    { 6, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3092), false, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(3093), "Fiat" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ID", "CreatedDate", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9178), false, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9179), "Beyaz" },
                    { 2, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9180), false, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9181), "Gri" },
                    { 3, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9183), false, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9183), "Siyah" },
                    { 4, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9185), false, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9186), "Kırmızı" },
                    { 5, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9187), false, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(9188), "Mavi" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "ID", "BrandId", "CreatedDate", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8324), false, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8325), "i20" },
                    { 2, 4, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8327), false, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8327), "Clio" },
                    { 3, 4, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8329), false, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8330), "Megane" },
                    { 4, 6, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8332), false, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8332), "Egea" },
                    { 5, 5, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8334), false, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8335), "Astra" },
                    { 6, 2, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8336), false, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(8337), "i8" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "ID", "CarModelId", "ColorId", "CreatedDate", "CurrentCount", "DailyPrice", "Description", "FuelType", "Image", "IsDeleted", "ModelYear", "ModifiedDate", "TotalCount", "TransmissionType", "VehicleType" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6410), 3, 800, "Temiz aile arabası", 0, "https://s.yauto.cz/m/obrazky/hih/0019/hyundai-i20-306110-M-789242797-1.jpg", false, 2015, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6411), 3, 1, 1 },
                    { 2, 1, 3, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6414), 1, 800, "Temiz aile arabası", 0, "https://i0.shbdn.com/photos/73/43/28/x5_103173432829h.jpg", false, 2014, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6415), 1, 1, 1 },
                    { 3, 2, 2, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6418), 6, 950, "Yeni aile arabası", 0, "https://file.ikinciyeni.com/carphotos/34re2824/DetailImage/ikinci-el-satilik-renault-clio-48-045dfa.jpg?v1", false, 2016, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6418), 6, 1, 1 },
                    { 4, 2, 1, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6421), 6, 980, "Yeni beyaz clio", 0, "https://www.yildirayrentacar.com/dosya/2080/sinif/13-56-17-renault-clio-benzin.jpg", false, 2015, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6421), 6, 1, 1 },
                    { 5, 3, 3, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6423), 2, 1050, "Yeni siyah megane", 0, "https://bufilo.com/storage/aylik-kiralik-megane-renault-bufilo-arac-kiralama-istanbul-600-250.png", false, 2020, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6424), 2, 1, 0 },
                    { 6, 3, 1, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6432), 2, 1050, "Yeni beyaz megane", 0, "https://zugo2.mncdn.com/mnresize/800/-/Images/Arac/b/410/283507/2175813.jpg", false, 2021, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6433), 2, 1, 0 },
                    { 7, 4, 1, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6435), 4, 1100, "Ucuz yakıt egea", 1, "https://ersanrentacar.com/yuklemeler/2015/10/fiat-egea-bulut-beyazi-2.jpg", false, 2019, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6436), 4, 0, 0 },
                    { 8, 4, 2, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6438), 3, 1100, "Ucuz yakıt egea", 1, "https://zugo2.mncdn.com/mnresize/800/-/Images/Arac/b/410/251987/1913579.jpg", false, 2018, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6438), 3, 0, 0 },
                    { 9, 5, 4, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6441), 1, 1090, "hızlı opel astra", 0, "https://i0.shbdn.com/photos/20/05/44/1032200544t8b.jpg", false, 2022, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6441), 1, 1, 0 },
                    { 10, 5, 5, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6444), 1, 1150, "opel özel renk mavi", 0, "https://www.arackaplama.com/wp-content/uploads/2017/12/IMAG2542.jpg", false, 2017, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6444), 1, 0, 0 },
                    { 11, 6, 2, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6446), 4, 1500, "spor yarış arabası", 0, "https://upload.wikimedia.org/wikipedia/commons/e/e9/2016_BMW_i8.jpg", false, 2018, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6447), 4, 1, 5 },
                    { 12, 6, 5, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6450), 7, 1250, "spor yarış arabası", 1, "https://upload.wikimedia.org/wikipedia/commons/9/93/2015_BMW_i8_%2820039281571%29_%282%29.jpg", false, 2019, new DateTime(2022, 7, 21, 14, 23, 35, 904, DateTimeKind.Local).AddTicks(6450), 7, 1, 5 }
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
                name: "IX_CarModels_BrandId",
                table: "CarModels",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId",
                table: "Cars",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ColorId",
                table: "Cars",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
