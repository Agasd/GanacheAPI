using Microsoft.EntityFrameworkCore.Migrations;

namespace Ganache.API.Migrations
{
    public partial class transactionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sender",
                table: "Transactions",
                newName: "Sender_username");

            migrationBuilder.RenameColumn(
                name: "Recepient",
                table: "Transactions",
                newName: "Sender_privateKey");

            migrationBuilder.AddColumn<string>(
                name: "Recepient_publicKey",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Recepient_username",
                table: "Transactions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recepient_publicKey",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Recepient_username",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "Sender_username",
                table: "Transactions",
                newName: "Sender");

            migrationBuilder.RenameColumn(
                name: "Sender_privateKey",
                table: "Transactions",
                newName: "Recepient");
        }
    }
}
