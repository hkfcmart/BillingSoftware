using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameWork.Migrations
{
    public partial class AddGSTDisountInInventryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "BillInventry",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "GST",
                table: "BillInventry",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "BillInventry");

            migrationBuilder.DropColumn(
                name: "GST",
                table: "BillInventry");
        }
    }
}
