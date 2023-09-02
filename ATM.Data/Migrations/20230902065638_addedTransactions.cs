using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATM.Data.Migrations;

/// <inheritdoc />
public partial class addedTransactions : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Transactions",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CardHolerId = table.Column<int>(type: "int", nullable: true),
                Amount = table.Column<double>(type: "float", nullable: false),
                TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                Balance = table.Column<double>(type: "float", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Transactions", x => x.Id);
                table.ForeignKey(
                    name: "FK_Transactions_CardHolders_CardHolerId",
                    column: x => x.CardHolerId,
                    principalTable: "CardHolders",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Transactions_CardHolerId",
            table: "Transactions",
            column: "CardHolerId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Transactions");
    }
}
