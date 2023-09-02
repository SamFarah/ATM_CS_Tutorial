using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable



namespace ATM.Data.Migrations;

/// <inheritdoc />
public partial class firstMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "CardHolders",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CardNum = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                Pin = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                LastName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                Balance = table.Column<double>(type: "float", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CardHolders", x => x.Id);
            });

        migrationBuilder.InsertData(
            table: "CardHolders",
            columns: new[] { "Id", "Balance", "CardNum", "FirstName", "LastName", "Pin" },
            values: new object[,]
            {
                { 1, 150.31, "4532772818527395", "John", "Griffith", "1234" },
                { 2, 321.13, "4532761841325802", "Ashley", "Jones", "4321" },
                { 3, 105.59, "5128381368581872", "Frida", "Dickerson", "9999" },
                { 4, 851.84000000000003, "6011188364697109", "Muneeb", "Harding", "2468" },
                { 5, 54.270000000000003, "3490693153147110", "Dawn", "Smith", "4826" }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "CardHolders");
    }
}
