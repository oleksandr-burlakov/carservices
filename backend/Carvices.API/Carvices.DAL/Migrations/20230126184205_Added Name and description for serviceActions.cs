using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carvices.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedNameanddescriptionforserviceActions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ServiceActions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ServiceActions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ServiceActions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ServiceActions");
        }
    }
}
