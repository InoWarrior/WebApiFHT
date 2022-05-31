using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiFHT.Migrations
{
    public partial class UserbyIdUpadate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_CreatedById",
                table: "Company",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Users_CreatedById",
                table: "Company",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Users_CreatedById",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_CreatedById",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Company");
        }
    }
}
