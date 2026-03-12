using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartProduction.API.Migrations
{
    /// <inheritdoc />
    public partial class RenameOrderDateInProductionOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Order",
                table: "ProductionOrders",
                newName: "OrderDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "ProductionOrders",
                newName: "Order");
        }
    }
}
