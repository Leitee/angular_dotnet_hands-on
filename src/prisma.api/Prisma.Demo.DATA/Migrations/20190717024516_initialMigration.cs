using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prisma.Demo.DATA.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Prisma");

            migrationBuilder.CreateTable(
                name: "Marcas",
                schema: "Prisma",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZonasDePrecio",
                schema: "Prisma",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonasDePrecio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competidores",
                schema: "Prisma",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Calle = table.Column<string>(nullable: true),
                    Latitud = table.Column<decimal>(nullable: false),
                    Longitud = table.Column<decimal>(nullable: false),
                    Marcador = table.Column<bool>(nullable: false),
                    Observar = table.Column<bool>(nullable: false),
                    MarcaId = table.Column<int>(nullable: false),
                    ZonaDePrecioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competidores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competidores_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalSchema: "Prisma",
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competidores_ZonasDePrecio_ZonaDePrecioId",
                        column: x => x.ZonaDePrecioId,
                        principalSchema: "Prisma",
                        principalTable: "ZonasDePrecio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Prisma",
                table: "Marcas",
                columns: new[] { "Id", "Codigo", "Nombre" },
                values: new object[,]
                {
                    { 1, "marca_codigo1", "marca_nombre1" },
                    { 2, "marca_codigo2", "marca_nombre2" },
                    { 3, "marca_codigo3", "marca_nombre3" }
                });

            migrationBuilder.InsertData(
                schema: "Prisma",
                table: "ZonasDePrecio",
                columns: new[] { "Id", "Codigo", "Nombre" },
                values: new object[,]
                {
                    { 1, "zona_codigo1", "zona_nombre1" },
                    { 2, "zona_codigo2", "zona_nombre2" },
                    { 3, "zona_codigo3", "zona_nombre3" }
                });

            migrationBuilder.InsertData(
                schema: "Prisma",
                table: "Competidores",
                columns: new[] { "Id", "Calle", "Codigo", "Latitud", "Longitud", "MarcaId", "Marcador", "Nombre", "Observar", "ZonaDePrecioId" },
                values: new object[] { 1, "calle1", "codigo1", 0m, 0m, 1, false, "nombre1", false, 1 });

            migrationBuilder.InsertData(
                schema: "Prisma",
                table: "Competidores",
                columns: new[] { "Id", "Calle", "Codigo", "Latitud", "Longitud", "MarcaId", "Marcador", "Nombre", "Observar", "ZonaDePrecioId" },
                values: new object[] { 2, "calle2", "codigo2", 0m, 0m, 2, false, "nombre2", false, 2 });

            migrationBuilder.InsertData(
                schema: "Prisma",
                table: "Competidores",
                columns: new[] { "Id", "Calle", "Codigo", "Latitud", "Longitud", "MarcaId", "Marcador", "Nombre", "Observar", "ZonaDePrecioId" },
                values: new object[] { 3, "calle3", "codigo3", 0m, 0m, 3, false, "nombre3", false, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Competidores_MarcaId",
                schema: "Prisma",
                table: "Competidores",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Competidores_ZonaDePrecioId",
                schema: "Prisma",
                table: "Competidores",
                column: "ZonaDePrecioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competidores",
                schema: "Prisma");

            migrationBuilder.DropTable(
                name: "Marcas",
                schema: "Prisma");

            migrationBuilder.DropTable(
                name: "ZonasDePrecio",
                schema: "Prisma");
        }
    }
}
