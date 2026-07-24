using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApi.Migrations
{
    /// <inheritdoc />
    public partial class enhancePartyProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "partyGroupName",
                table: "Parties",
                newName: "PartyGroupName");

            migrationBuilder.RenameColumn(
                name: "partyCode",
                table: "Parties",
                newName: "PartyCode");

            migrationBuilder.RenameColumn(
                name: "nativeName",
                table: "Parties",
                newName: "NativeName");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Parties",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "internalCode",
                table: "Parties",
                newName: "InternalCode");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "Parties",
                newName: "Active");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Parties",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PartyGroupName",
                table: "Parties",
                newName: "partyGroupName");

            migrationBuilder.RenameColumn(
                name: "PartyCode",
                table: "Parties",
                newName: "partyCode");

            migrationBuilder.RenameColumn(
                name: "NativeName",
                table: "Parties",
                newName: "nativeName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Parties",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "InternalCode",
                table: "Parties",
                newName: "internalCode");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Parties",
                newName: "active");

            migrationBuilder.AlterColumn<string>(
                name: "active",
                table: "Parties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
