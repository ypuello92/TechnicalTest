using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalTest.Migrations
{
    /// <inheritdoc />
    public partial class fixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecordId",
                table: "Region",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "Region");
        }
    }
}
