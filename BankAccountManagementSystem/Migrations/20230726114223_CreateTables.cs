using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAccountManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypesDetails",
                columns: table => new
                {
                    AccountTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TypeOfAccount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypesDetails", x => x.AccountTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    NameOfPaymentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "BankAccountsDetails",
                columns: table => new
                {
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    AccountOpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountClosingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TotalAmountOfBalance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountsDetails", x => x.BankAccountId);
                    table.ForeignKey(
                        name: "FK_BankAccountsDetails_AccountTypesDetails_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypesDetails",
                        principalColumn: "AccountTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankTransactionDetails",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FirstNameOfTransactionPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleNameOfTransactionPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastNameOfTransactionPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfTransaction = table.Column<int>(type: "int", nullable: false),
                    CatagoryOptions = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    DateOfTransaction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransactionDetails", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_BankTransactionDetails_BankAccountsDetails_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccountsDetails",
                        principalColumn: "BankAccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankTransactionDetails_PaymentDetails_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "PaymentDetails",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccountPostingDetails",
                columns: table => new
                {
                    PostingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    PostingDetailsTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountPostingDetails", x => x.PostingId);
                    table.ForeignKey(
                        name: "FK_BankAccountPostingDetails_BankTransactionDetails_PostingDetailsTransactionId",
                        column: x => x.PostingDetailsTransactionId,
                        principalTable: "BankTransactionDetails",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountPostingDetails_PostingDetailsTransactionId",
                table: "BankAccountPostingDetails",
                column: "PostingDetailsTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountsDetails_AccountTypeId",
                table: "BankAccountsDetails",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactionDetails_BankAccountId",
                table: "BankTransactionDetails",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactionDetails_PaymentId",
                table: "BankTransactionDetails",
                column: "PaymentId");
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
