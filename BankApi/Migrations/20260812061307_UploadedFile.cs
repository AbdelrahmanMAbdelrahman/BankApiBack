using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApi.Migrations
{
    /// <inheritdoc />
    public partial class UploadedFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UploadedImageID",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UploadedImage",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    StoredFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedImage", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UploadedImageID",
                table: "Employees",
                column: "UploadedImageID",
                unique: true,
                filter: "[UploadedImageID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_UploadedImage_UploadedImageID",
                table: "Employees",
                column: "UploadedImageID",
                principalTable: "UploadedImage",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_UploadedImage_UploadedImageID",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "UploadedImage");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UploadedImageID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UploadedImageID",
                table: "Employees");
        }
    }
}
