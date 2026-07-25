using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApi.Migrations
{
    /// <inheritdoc />
    public partial class contractRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartyName",
                table: "Contracts");

            migrationBuilder.AddColumn<Guid>(
                name: "PartyID",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_PartyID",
                table: "Contracts",
                column: "PartyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Parties_PartyID",
                table: "Contracts",
                column: "PartyID",
                principalTable: "Parties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Parties_PartyID",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_PartyID",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "PartyID",
                table: "Contracts");

            migrationBuilder.AddColumn<string>(
                name: "PartyName",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
