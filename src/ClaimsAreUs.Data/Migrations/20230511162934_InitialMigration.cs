using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClaimsAreUs.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClaimTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    InsuranceEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    UCR = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ClaimDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LossDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssuredName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IncurredLoss = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    Closed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.UCR);
                    table.ForeignKey(
                        name: "FK_Claims_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClaimTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Legal Expense" },
                    { 2, "Liability" },
                    { 3, "Property" },
                    { 4, "Tax" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Active", "Address1", "Address2", "Address3", "Country", "InsuranceEndDate", "Name", "PostCode" },
                values: new object[,]
                {
                    { 1, true, "1 Car Dealer Avenue", "Bradford", null, "United Kingdom", new DateTime(2025, 5, 11, 16, 29, 34, 331, DateTimeKind.Utc).AddTicks(6713), "Dave's Dodgy Dealer", "BD1 1AA" },
                    { 2, false, "2 Car Dealer Avenue", "Bradford", null, "United Kingdom", new DateTime(2022, 5, 11, 16, 29, 34, 331, DateTimeKind.Utc).AddTicks(6713), "Brian's Bodged Bangers", "BD1 1AA" },
                    { 3, true, "3-100 Car Dealer Avenue", "Bradford", null, "United Kingdom", new DateTime(2033, 5, 11, 16, 29, 34, 331, DateTimeKind.Utc).AddTicks(6713), "Honest Chris' Cozy Cars", "BD1 1AA" }
                });

            migrationBuilder.InsertData(
                table: "Claims",
                columns: new[] { "UCR", "AssuredName", "ClaimDate", "Closed", "CompanyId", "IncurredLoss", "LossDate" },
                values: new object[,]
                {
                    { "UCR_0d2f71d2", "Brian Bodger", new DateTime(2016, 5, 11, 16, 29, 34, 331, DateTimeKind.Utc).AddTicks(6713), true, 2, 400m, new DateTime(2016, 5, 8, 16, 29, 34, 331, DateTimeKind.Utc).AddTicks(6713) },
                    { "UCR_1deca533", "Dave Dealer", new DateTime(2018, 5, 11, 16, 29, 34, 331, DateTimeKind.Utc).AddTicks(6713), true, 1, 10000m, new DateTime(2018, 5, 6, 16, 29, 34, 331, DateTimeKind.Utc).AddTicks(6713) },
                    { "UCR_4a0e5e71", "Dave Dealer", new DateTime(2014, 5, 11, 16, 29, 34, 331, DateTimeKind.Utc).AddTicks(6713), true, 1, 4000m, new DateTime(2014, 5, 10, 16, 29, 34, 331, DateTimeKind.Utc).AddTicks(6713) },
                    { "UCR_5f079de3", "Dave Dealer", new DateTime(2023, 5, 11, 16, 29, 34, 331, DateTimeKind.Utc).AddTicks(6713), false, 1, 40000m, new DateTime(2023, 5, 10, 16, 29, 34, 331, DateTimeKind.Utc).AddTicks(6713) },
                    { "UCR_8619246c", "Brian Bodger", new DateTime(2021, 5, 11, 16, 29, 34, 331, DateTimeKind.Utc).AddTicks(6713), true, 2, 1000m, new DateTime(2021, 5, 10, 16, 29, 34, 331, DateTimeKind.Utc).AddTicks(6713) },
                    { "UCR_921ab7c6", "Brian Bodger", new DateTime(2023, 5, 11, 16, 29, 34, 331, DateTimeKind.Utc).AddTicks(6713), false, 2, 4000m, new DateTime(2023, 5, 6, 16, 29, 34, 331, DateTimeKind.Utc).AddTicks(6713) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_CompanyId",
                table: "Claims",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "ClaimTypes");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
