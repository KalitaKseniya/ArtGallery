using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtGallery.Migrations
{
    public partial class InitMigrWithInitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtMovements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtMovements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Painters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FathersName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BirthPlace = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeathDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeathPlace = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Painters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paintings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Medium = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Size_x = table.Column<double>(type: "float", nullable: true),
                    Size_y = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PainterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paintings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paintings_Painters_PainterId",
                        column: x => x.PainterId,
                        principalTable: "Painters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtMovementPainting",
                columns: table => new
                {
                    PaintingsId = table.Column<int>(type: "int", nullable: false),
                    artMovementsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtMovementPainting", x => new { x.PaintingsId, x.artMovementsId });
                    table.ForeignKey(
                        name: "FK_ArtMovementPainting_ArtMovements_artMovementsId",
                        column: x => x.artMovementsId,
                        principalTable: "ArtMovements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtMovementPainting_Paintings_PaintingsId",
                        column: x => x.PaintingsId,
                        principalTable: "Paintings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ArtMovements",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Постимпрессионизм" },
                    { 2, "Модернизм в изобразительном искусстве" },
                    { 3, "Романтизм" },
                    { 4, "Модерн" },
                    { 5, "Символизм" }
                });

            migrationBuilder.InsertData(
                table: "Painters",
                columns: new[] { "Id", "Age", "BirthDate", "BirthPlace", "Country", "DeathDate", "DeathPlace", "FathersName", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 37, new DateTime(1853, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Грот-Зюндерт", "Нидерланды", new DateTime(1853, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Овер-сюр-Уаз", null, "Винсент", "Ван Гог" },
                    { 2, 55, new DateTime(1862, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Вена", "Австрийская империя", new DateTime(1918, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Вена", null, "Густав", "Климт" },
                    { 3, 82, new DateTime(1817, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Феодосия, Таврическая губерния, Российская империя", "Российская империя", new DateTime(1900, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "	Феодосия, Таврическая губерния, Российская империя", "Константинович", "Иван", "Айвазовский" }
                });

            migrationBuilder.InsertData(
                table: "Paintings",
                columns: new[] { "Id", "Description", "Medium", "Name", "PainterId", "Size_x", "Size_y", "Year" },
                values: new object[,]
                {
                    { 1, null, "Холст, масло", "Звездная ночь", 1, 73.700000000000003, 92.099999999999994, 1889 },
                    { 2, null, "Холст, масло", "Цветущие ветки миндаля", 1, 73.5, 92.0, 1890 },
                    { 4, null, "Холст, масло", "Поцелуй", 2, 180.0, 180.0, 1908 },
                    { 3, null, "Холст, масло", "Девятый вал", 3, 221.0, 332.0, 1850 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtMovementPainting_artMovementsId",
                table: "ArtMovementPainting",
                column: "artMovementsId");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_PainterId",
                table: "Paintings",
                column: "PainterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "ArtMovementPainting");

            migrationBuilder.DropTable(
                name: "ArtMovements");

            migrationBuilder.DropTable(
                name: "Paintings");

            migrationBuilder.DropTable(
                name: "Painters");
        }
    }
}
