using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kazalištelutaka.Migrations
{
    public partial class kazaliste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Predstave",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false),
                    Trajanje = table.Column<string>(nullable: true),
                    Uzrast = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predstave", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Raspored",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatPredstave = table.Column<DateTime>(nullable: false),
                    PredstaveId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raspored", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Raspored_Predstave_PredstaveId",
                        column: x => x.PredstaveId,
                        principalTable: "Predstave",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Raspored_PredstaveId",
                table: "Raspored",
                column: "PredstaveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Raspored");

            migrationBuilder.DropTable(
                name: "Predstave");
        }
    }
}
