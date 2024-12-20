using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppHarbuz.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddExpiredDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpireDate",
                table: "Tasks",
                newName: "ExpiredDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpiredDate",
                table: "Tasks",
                newName: "ExpireDate");
        }
    }
}
