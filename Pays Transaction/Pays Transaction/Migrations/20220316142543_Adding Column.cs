using Microsoft.EntityFrameworkCore.Migrations;

namespace Pays_Transaction.Migrations
{
    public partial class AddingColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "TransactionDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "TransactionDetails");
        }
    }
}
