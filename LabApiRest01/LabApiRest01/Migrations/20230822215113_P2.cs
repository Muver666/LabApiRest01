using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabApiRest01.Migrations
{
    /// <inheritdoc />
    public partial class P2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompayId",
                table: "Companies",
                newName: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Companies",
                newName: "CompayId");
        }
    }
}
