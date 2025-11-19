using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Client_Retail_Wholesale_Membership_Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_RetailClients_RetailClientID",
                table: "Memberships");

            migrationBuilder.RenameColumn(
                name: "RetailClientID",
                table: "Memberships",
                newName: "RetailClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Memberships_RetailClientID",
                table: "Memberships",
                newName: "IX_Memberships_RetailClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_RetailClients_RetailClientId",
                table: "Memberships",
                column: "RetailClientId",
                principalTable: "RetailClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_RetailClients_RetailClientId",
                table: "Memberships");

            migrationBuilder.RenameColumn(
                name: "RetailClientId",
                table: "Memberships",
                newName: "RetailClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Memberships_RetailClientId",
                table: "Memberships",
                newName: "IX_Memberships_RetailClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_RetailClients_RetailClientID",
                table: "Memberships",
                column: "RetailClientID",
                principalTable: "RetailClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
