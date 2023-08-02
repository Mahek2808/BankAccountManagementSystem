using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAccountManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class TableChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "BankTransactionDetails",
                type: "decimal(18,2)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "BankTransactionDetails",
                type: "int",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 6);
        }
    }
}
