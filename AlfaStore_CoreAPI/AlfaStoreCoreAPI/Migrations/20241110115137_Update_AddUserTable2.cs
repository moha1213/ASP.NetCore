using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlfaStoreCoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class Update_AddUserTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_contacts_ContactDetailsId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "ContactDetailsId",
                table: "users",
                newName: "ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_users_ContactDetailsId",
                table: "users",
                newName: "IX_users_ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_contacts_ContactId",
                table: "users",
                column: "ContactId",
                principalTable: "contacts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_contacts_ContactId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "users",
                newName: "ContactDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_users_ContactId",
                table: "users",
                newName: "IX_users_ContactDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_contacts_ContactDetailsId",
                table: "users",
                column: "ContactDetailsId",
                principalTable: "contacts",
                principalColumn: "Id");
        }
    }
}
