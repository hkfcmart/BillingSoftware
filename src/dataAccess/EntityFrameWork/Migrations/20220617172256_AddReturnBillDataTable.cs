using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameWork.Migrations
{
    public partial class AddReturnBillDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReturnBillData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    BillNo = table.Column<int>(type: "int", nullable: false),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    BatchNo = table.Column<int>(type: "int", nullable: false),
                    ManufacturingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchasingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnBillData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReturnBillData");
        }
    }
}
