using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Journal.Data.Migrations
{
    public partial class haveclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HaveClass",
                table: "Teacher",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HaveClass",
                table: "Teacher");
        }
    }
}
