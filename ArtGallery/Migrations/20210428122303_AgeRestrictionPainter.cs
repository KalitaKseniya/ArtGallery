using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtGallery.Migrations
{
    public partial class AgeRestrictionPainter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtMovementPainting_ArtMovements_artMovementsId",
                table: "ArtMovementPainting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtMovementPainting",
                table: "ArtMovementPainting");

            migrationBuilder.DropIndex(
                name: "IX_ArtMovementPainting_artMovementsId",
                table: "ArtMovementPainting");

            migrationBuilder.RenameColumn(
                name: "artMovementsId",
                table: "ArtMovementPainting",
                newName: "ArtMovementsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtMovementPainting",
                table: "ArtMovementPainting",
                columns: new[] { "ArtMovementsId", "PaintingsId" });

            migrationBuilder.CreateIndex(
                name: "IX_ArtMovementPainting_PaintingsId",
                table: "ArtMovementPainting",
                column: "PaintingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtMovementPainting_ArtMovements_ArtMovementsId",
                table: "ArtMovementPainting",
                column: "ArtMovementsId",
                principalTable: "ArtMovements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtMovementPainting_ArtMovements_ArtMovementsId",
                table: "ArtMovementPainting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtMovementPainting",
                table: "ArtMovementPainting");

            migrationBuilder.DropIndex(
                name: "IX_ArtMovementPainting_PaintingsId",
                table: "ArtMovementPainting");

            migrationBuilder.RenameColumn(
                name: "ArtMovementsId",
                table: "ArtMovementPainting",
                newName: "artMovementsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtMovementPainting",
                table: "ArtMovementPainting",
                columns: new[] { "PaintingsId", "artMovementsId" });

            migrationBuilder.CreateIndex(
                name: "IX_ArtMovementPainting_artMovementsId",
                table: "ArtMovementPainting",
                column: "artMovementsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtMovementPainting_ArtMovements_artMovementsId",
                table: "ArtMovementPainting",
                column: "artMovementsId",
                principalTable: "ArtMovements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
