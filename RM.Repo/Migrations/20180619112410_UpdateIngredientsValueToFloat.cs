using Microsoft.EntityFrameworkCore.Migrations;

namespace RM.Repo.Migrations
{
    public partial class UpdateIngredientsValueToFloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Value",
                table: "Ingredients",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Ingredients",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
