using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShop.Products.Api.Migrations
{
    /// <inheritdoc />
    public partial class updateDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "products",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldMaxLength: 500)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "description",
                table: "products",
                type: "decimal(65,30)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500)
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
