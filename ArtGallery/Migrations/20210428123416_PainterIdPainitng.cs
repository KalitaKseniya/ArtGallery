using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtGallery.Migrations
{
    public partial class PainterIdPainitng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paintings_Painters_PainterId",
                table: "Paintings");

            migrationBuilder.AlterColumn<int>(
                name: "PainterId",
                table: "Paintings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Paintings_Painters_PainterId",
                table: "Paintings",
                column: "PainterId",
                principalTable: "Painters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paintings_Painters_PainterId",
                table: "Paintings");

            migrationBuilder.AlterColumn<int>(
                name: "PainterId",
                table: "Paintings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Paintings_Painters_PainterId",
                table: "Paintings",
                column: "PainterId",
                principalTable: "Painters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
