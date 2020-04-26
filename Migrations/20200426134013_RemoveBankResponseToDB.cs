using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentGatewayAPI.Migrations
{
    public partial class RemoveBankResponseToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankResponses_Transactions_TransactionId",
                table: "BankResponses");

            migrationBuilder.DropIndex(
                name: "IX_BankResponses_TransactionId",
                table: "BankResponses");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "BankResponses");

            migrationBuilder.AddColumn<string>(
                name: "BankResponse",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BankResponseId",
                table: "Transactions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Transactions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankResponse",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BankResponseId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transactions");

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId",
                table: "BankResponses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BankResponses_TransactionId",
                table: "BankResponses",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankResponses_Transactions_TransactionId",
                table: "BankResponses",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
