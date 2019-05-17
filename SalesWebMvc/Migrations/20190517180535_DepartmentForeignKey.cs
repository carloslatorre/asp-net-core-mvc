using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMvc.Migrations
{
    public partial class DepartmentForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Department_DeptoId",
                table: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Seller_DeptoId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "DeptoId",
                table: "Seller");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Seller",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Seller_DepartmentId",
                table: "Seller",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Department_DepartmentId",
                table: "Seller",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Department_DepartmentId",
                table: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Seller_DepartmentId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Seller");

            migrationBuilder.AddColumn<int>(
                name: "DeptoId",
                table: "Seller",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seller_DeptoId",
                table: "Seller",
                column: "DeptoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Department_DeptoId",
                table: "Seller",
                column: "DeptoId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
