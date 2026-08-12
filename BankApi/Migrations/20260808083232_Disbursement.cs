using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApi.Migrations
{
    /// <inheritdoc />
    public partial class Disbursement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disbursement",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    facilityID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    contractID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    disbursementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    posted = table.Column<bool>(type: "bit", nullable: false),
                    reviewed = table.Column<bool>(type: "bit", nullable: false),
                    disbursementMethod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disbursement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Disbursement_Contracts_contractID",
                        column: x => x.contractID,
                        principalTable: "Contracts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disbursement_Facilities_facilityID",
                        column: x => x.facilityID,
                        principalTable: "Facilities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disbursement_contractID",
                table: "Disbursement",
                column: "contractID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disbursement_facilityID",
                table: "Disbursement",
                column: "facilityID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disbursement");
        }
    }
}
