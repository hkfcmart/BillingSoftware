using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameWork.Migrations
{
    public partial class AddedDateToBillInventry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExpiryDate",
                table: "BillInventry",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManufacturingDate",
                table: "BillInventry",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchasingDate",
                table: "BillInventry",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "BillInventry");

            migrationBuilder.DropColumn(
                name: "ManufacturingDate",
                table: "BillInventry");

            migrationBuilder.DropColumn(
                name: "PurchasingDate",
                table: "BillInventry");
        }
    }
}
