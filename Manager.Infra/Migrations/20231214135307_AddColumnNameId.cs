using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manager.Infra.Migrations
{
    public partial class AddColumnNameId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "User",
                newName: "Id");
        }
    }
}
