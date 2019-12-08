using Microsoft.EntityFrameworkCore.Migrations;

namespace Ganache.API.Migrations
{
    public partial class transactionMigrationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sender_privateKey",
                table: "Transactions",
                newName: "Sender_publicKey");

            migrationBuilder.RenameColumn(
                name: "EtherAmount",
                table: "Transactions",
                newName: "Ether_Amount");

            migrationBuilder.RenameColumn(
                name: "CreditAmount",
                table: "Transactions",
                newName: "Credit_Amount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sender_publicKey",
                table: "Transactions",
                newName: "Sender_privateKey");

            migrationBuilder.RenameColumn(
                name: "Ether_Amount",
                table: "Transactions",
                newName: "EtherAmount");

            migrationBuilder.RenameColumn(
                name: "Credit_Amount",
                table: "Transactions",
                newName: "CreditAmount");
        }
    }
}
