using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankAccountManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypesDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypesDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccountsDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    AccountOpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountClosingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountType_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalAmountOfBalance = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccountsDetails_AccountTypesDetails_AccountType_Id",
                        column: x => x.AccountType_Id,
                        principalTable: "AccountTypesDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankTransactionDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeOfTransaction = table.Column<int>(type: "int", nullable: false),
                    CatagoryOptions = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", maxLength: 6, nullable: false),
                    DateOfTransaction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Payment_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankAccount_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransactionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankTransactionDetails_BankAccountsDetails_BankAccount_Id",
                        column: x => x.BankAccount_Id,
                        principalTable: "BankAccountsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankTransactionDetails_PaymentDetails_Payment_Id",
                        column: x => x.Payment_Id,
                        principalTable: "PaymentDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccountPostingDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankTransaction_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountPostingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccountPostingDetails_BankTransactionDetails_BankTransaction_Id",
                        column: x => x.BankTransaction_Id,
                        principalTable: "BankTransactionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccountTypesDetails",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("026ec876-4526-4122-a00d-afb6cbfeea73"), "Liability" },
                    { new Guid("1b47d3b2-9b44-4ea9-b5e0-d4921499070c"), "Asset" }
                });

            migrationBuilder.InsertData(
                table: "PaymentDetails",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("264ecbe9-2c49-40ca-9a7e-630e7999b296"), "NEFT" },
                    { new Guid("85e2e054-5a65-425d-ab26-c34b69b26be6"), "RTGS" },
                    { new Guid("963a6c8b-4a7f-4e75-bdeb-3bc9d8be9cef"), "Cheque" },
                    { new Guid("c96abbe3-9cf1-4ec6-ac2d-250bb69ac651"), "Other" },
                    { new Guid("e5eed49b-e788-4174-82aa-9dba83138a8d"), "Cash" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountPostingDetails_BankTransaction_Id",
                table: "BankAccountPostingDetails",
                column: "BankTransaction_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountsDetails_AccountType_Id",
                table: "BankAccountsDetails",
                column: "AccountType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactionDetails_BankAccount_Id",
                table: "BankTransactionDetails",
                column: "BankAccount_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactionDetails_Payment_Id",
                table: "BankTransactionDetails",
                column: "Payment_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccountPostingDetails");

            migrationBuilder.DropTable(
                name: "BankTransactionDetails");

            migrationBuilder.DropTable(
                name: "BankAccountsDetails");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "AccountTypesDetails");
        }
    }
}
