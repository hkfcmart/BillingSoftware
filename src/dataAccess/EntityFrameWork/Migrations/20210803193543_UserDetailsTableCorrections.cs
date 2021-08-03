using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameWork.Migrations
{
    public partial class UserDetailsTableCorrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userDetails",
                table: "userDetails");

            migrationBuilder.RenameTable(
                name: "userDetails",
                newName: "UserDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails");

            migrationBuilder.RenameTable(
                name: "UserDetails",
                newName: "userDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userDetails",
                table: "userDetails",
                column: "Id");
        }
    }
}
