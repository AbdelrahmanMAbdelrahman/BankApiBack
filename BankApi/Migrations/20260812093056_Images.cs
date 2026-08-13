using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApi.Migrations
{
    /// <inheritdoc />
    public partial class Images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_UploadedImage_UploadedImageID",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UploadedImage",
                table: "UploadedImage");

            migrationBuilder.RenameTable(
                name: "UploadedImage",
                newName: "Images");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Images_UploadedImageID",
                table: "Employees",
                column: "UploadedImageID",
                principalTable: "Images",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Images_UploadedImageID",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "UploadedImage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UploadedImage",
                table: "UploadedImage",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_UploadedImage_UploadedImageID",
                table: "Employees",
                column: "UploadedImageID",
                principalTable: "UploadedImage",
                principalColumn: "ID");
        }
    }
}
