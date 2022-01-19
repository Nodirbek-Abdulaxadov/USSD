using Microsoft.EntityFrameworkCore.Migrations;

namespace USSD.Data.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "subcategory",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "product",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "product",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OpeatorName",
                table: "operator",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(37)",
                oldMaxLength: 37);

            migrationBuilder.CreateIndex(
                name: "IX_subcategory_CategoryId",
                table: "subcategory",
                column: "CategoryId");

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

            migrationBuilder.CreateIndex(
                name: "IX_product_SubCategoryId",
                table: "product",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_category_OperatorId",
                table: "category",
                column: "OperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_category_operator_OperatorId",
                table: "category",
                column: "OperatorId",
                principalTable: "operator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_product_subcategory_SubCategoryId",
                table: "product",
                column: "SubCategoryId",
                principalTable: "subcategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subcategory_category_CategoryId",
                table: "subcategory",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subcategory_operator_OperatorId",
                table: "subcategory",
                column: "OperatorId",
                principalTable: "operator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_operator_OperatorId",
                table: "category");

            migrationBuilder.DropForeignKey(
                name: "FK_product_category_CategoryId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_operator_OperatorId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_subcategory_SubCategoryId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_subcategory_category_CategoryId",
                table: "subcategory");

            migrationBuilder.DropForeignKey(
                name: "FK_subcategory_operator_OperatorId",
                table: "subcategory");

            migrationBuilder.DropIndex(
                name: "IX_subcategory_CategoryId",
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

            migrationBuilder.DropIndex(
                name: "IX_product_SubCategoryId",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_category_OperatorId",
                table: "category");

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
                name: "OpeatorName",
                table: "operator",
                type: "character varying(37)",
                maxLength: 37,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);
        }
    }
}
