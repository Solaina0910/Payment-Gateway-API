using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentGatewayAPI.Migrations
{
    public partial class AddBankResponseToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankResponses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    TransactionId = table.Column<Guid>(nullable: false),
                    Response = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankResponses_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankResponses_TransactionId",
                table: "BankResponses",
                column: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankResponses");
        }
    }
}
