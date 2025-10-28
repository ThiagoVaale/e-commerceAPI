using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Removed_circular_dependency_between_client_and_membership_and_possible_null_attributes_in_membership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Memberships_MembershipId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Memberships_ClientId",
                table: "Memberships");

            migrationBuilder.DropIndex(
                name: "IX_Clients_MembershipId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "MembershipId",
                table: "Clients");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_ClientId",
                table: "Memberships",
                column: "ClientId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Memberships_ClientId",
                table: "Memberships");

            migrationBuilder.AddColumn<Guid>(
                name: "MembershipId",
                table: "Clients",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_ClientId",
                table: "Memberships",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_MembershipId",
                table: "Clients",
                column: "MembershipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Memberships_MembershipId",
                table: "Clients",
                column: "MembershipId",
                principalTable: "Memberships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
