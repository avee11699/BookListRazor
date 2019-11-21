using Microsoft.EntityFrameworkCore.Migrations;

namespace BookListrazor.Migrations
{
    public partial class AddISPNToBookModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ISPN",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISPN",
                table: "Books");
        }
    }
}
