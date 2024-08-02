using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardIdBr.Migrations
{
    /// <inheritdoc />
    public partial class AddUseCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UseCode",
                table: "Students",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseCode",
                table: "Students");
        }
    }
}
