using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlfaStoreCoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class Update_AddUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TokenId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    ContactDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DevMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsrMessage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_contacts_ContactDetailsId",
                        column: x => x.ContactDetailsId,
                        principalTable: "contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_ContactDetailsId",
                table: "users",
                column: "ContactDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
