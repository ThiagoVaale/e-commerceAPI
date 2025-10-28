using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Change_the_phone_attribute_to_Client : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Clients",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
