using Microsoft.EntityFrameworkCore.Migrations;

namespace USSD.Data.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_category_CategoryId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_operator_OperatorId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_subcategory_operator_OperatorId",
                table: "subcategory");

            migrationBuilder.DropIndex(
                name: "IX_subcategory_OperatorId",
                table: "subcategory");

            migrationBuilder.DropIndex(
                name: "IX_product_CategoryId",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_OperatorId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "subcategory");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "product");

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionUz",
                table: "product",
                type: "varchar(5000)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionRu",
                table: "product",
                type: "varchar(5000)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "subcategory",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionUz",
                table: "product",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldMaxLength: 5000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionRu",
                table: "product",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldMaxLength: 5000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_subcategory_OperatorId",
                table: "subcategory",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_product_CategoryId",
                table: "product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_product_OperatorId",
                table: "product",
                column: "OperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_category_CategoryId",
                table: "product",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_product_operator_OperatorId",
                table: "product",
                column: "OperatorId",
                principalTable: "operator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_subcategory_operator_OperatorId",
                table: "subcategory",
                column: "OperatorId",
                principalTable: "operator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
