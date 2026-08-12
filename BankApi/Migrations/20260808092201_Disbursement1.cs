using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApi.Migrations
{
    /// <inheritdoc />
    public partial class Disbursement1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disbursement_Contracts_contractID",
                table: "Disbursement");

            migrationBuilder.DropForeignKey(
                name: "FK_Disbursement_Facilities_facilityID",
                table: "Disbursement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disbursement",
                table: "Disbursement");

            migrationBuilder.RenameTable(
                name: "Disbursement",
                newName: "Disbursements");

            migrationBuilder.RenameColumn(
                name: "reviewed",
                table: "Disbursements",
                newName: "Reviewed");

            migrationBuilder.RenameColumn(
                name: "posted",
                table: "Disbursements",
                newName: "Posted");

            migrationBuilder.RenameColumn(
                name: "facilityID",
                table: "Disbursements",
                newName: "FacilityID");

            migrationBuilder.RenameColumn(
                name: "disbursementMethod",
                table: "Disbursements",
                newName: "DisbursementMethod");

            migrationBuilder.RenameColumn(
                name: "disbursementDate",
                table: "Disbursements",
                newName: "DisbursementDate");

            migrationBuilder.RenameColumn(
                name: "contractID",
                table: "Disbursements",
                newName: "ContractID");

            migrationBuilder.RenameColumn(
                name: "comments",
                table: "Disbursements",
                newName: "Comments");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Disbursements",
                newName: "Amount");

            migrationBuilder.RenameIndex(
                name: "IX_Disbursement_facilityID",
                table: "Disbursements",
                newName: "IX_Disbursements_FacilityID");

            migrationBuilder.RenameIndex(
                name: "IX_Disbursement_contractID",
                table: "Disbursements",
                newName: "IX_Disbursements_ContractID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disbursements",
                table: "Disbursements",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Disbursements_Contracts_ContractID",
                table: "Disbursements",
                column: "ContractID",
                principalTable: "Contracts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Disbursements_Facilities_FacilityID",
                table: "Disbursements",
                column: "FacilityID",
                principalTable: "Facilities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disbursements_Contracts_ContractID",
                table: "Disbursements");

            migrationBuilder.DropForeignKey(
                name: "FK_Disbursements_Facilities_FacilityID",
                table: "Disbursements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disbursements",
                table: "Disbursements");

            migrationBuilder.RenameTable(
                name: "Disbursements",
                newName: "Disbursement");

            migrationBuilder.RenameColumn(
                name: "Reviewed",
                table: "Disbursement",
                newName: "reviewed");

            migrationBuilder.RenameColumn(
                name: "Posted",
                table: "Disbursement",
                newName: "posted");

            migrationBuilder.RenameColumn(
                name: "FacilityID",
                table: "Disbursement",
                newName: "facilityID");

            migrationBuilder.RenameColumn(
                name: "DisbursementMethod",
                table: "Disbursement",
                newName: "disbursementMethod");

            migrationBuilder.RenameColumn(
                name: "DisbursementDate",
                table: "Disbursement",
                newName: "disbursementDate");

            migrationBuilder.RenameColumn(
                name: "ContractID",
                table: "Disbursement",
                newName: "contractID");

            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "Disbursement",
                newName: "comments");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Disbursement",
                newName: "amount");

            migrationBuilder.RenameIndex(
                name: "IX_Disbursements_FacilityID",
                table: "Disbursement",
                newName: "IX_Disbursement_facilityID");

            migrationBuilder.RenameIndex(
                name: "IX_Disbursements_ContractID",
                table: "Disbursement",
                newName: "IX_Disbursement_contractID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disbursement",
                table: "Disbursement",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Disbursement_Contracts_contractID",
                table: "Disbursement",
                column: "contractID",
                principalTable: "Contracts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Disbursement_Facilities_facilityID",
                table: "Disbursement",
                column: "facilityID",
                principalTable: "Facilities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
