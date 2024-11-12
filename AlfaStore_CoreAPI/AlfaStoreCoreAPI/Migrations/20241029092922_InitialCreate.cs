using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlfaStoreCoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DevMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsrMessage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTrialVersion = table.Column<bool>(type: "bit", nullable: false),
                    IsValidLicense = table.Column<bool>(type: "bit", nullable: false),
                    LicenseStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LicenseEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "districts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_districts_cities_CityId",
                        column: x => x.CityId,
                        principalTable: "cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_addresses_districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "districts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddressTwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddressThree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaceBookAccountLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contacts_addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "phones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MobileOne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileTwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileThree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileFour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandLineOne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandLineTwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandLineThree = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_phones_contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_DistrictId",
                table: "addresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_cities_CountryId",
                table: "cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_AddressId",
                table: "contacts",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_districts_CityId",
                table: "districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_phones_ContactId",
                table: "phones",
                column: "ContactId",
                unique: true,
                filter: "[ContactId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "branches");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "phones");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "districts");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
