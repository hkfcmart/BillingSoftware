using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameWork.Migrations
{
    public partial class AddedDailyAndMonthlyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "BillInventry");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BillInventry");

            migrationBuilder.CreateTable(
                name: "DailyTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HSNCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GST = table.Column<double>(type: "float", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categories = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShelfNo = table.Column<int>(type: "int", nullable: false),
                    MRP = table.Column<double>(type: "float", nullable: false),
                    PurchasePrice = table.Column<double>(type: "float", nullable: false),
                    SellingPrice = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BatchNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MontlyTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HSNCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GST = table.Column<double>(type: "float", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categories = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShelfNo = table.Column<int>(type: "int", nullable: false),
                    MRP = table.Column<double>(type: "float", nullable: false),
                    PurchasePrice = table.Column<double>(type: "float", nullable: false),
                    SellingPrice = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BatchNo = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MontlyTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyTable");

            migrationBuilder.DropTable(
                name: "MontlyTable");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "BillInventry",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BillInventry",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
