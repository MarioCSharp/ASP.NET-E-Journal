using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Journal.Data.Migrations
{
    public partial class citiTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Schools");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Schools");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
