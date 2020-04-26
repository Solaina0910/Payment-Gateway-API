using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentGatewayAPI.Migrations
{
    public partial class AddPaymentGatewayAPIToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    MerchantId = table.Column<Guid>(nullable: false),
                    BankId = table.Column<int>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    CardType = table.Column<string>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    NameOnCard = table.Column<string>(nullable: true),
                    ExpiryMonth = table.Column<string>(nullable: true),
                    ExpiryYear = table.Column<int>(nullable: true),
                    CVV = table.Column<int>(nullable: true),
                    Amount = table.Column<float>(nullable: true),
                    BankResponse = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_MerchantId",
                table: "Transactions",
                column: "MerchantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Merchants");
        }
    }
}
