using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMailService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangepropertynamefromCreatedOntoCreateDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Mails",
                newName: "CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Mails",
                newName: "CreatedOn");
        }
    }
}
