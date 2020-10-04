using Microsoft.EntityFrameworkCore.Migrations;

namespace VendaLanche.Migrations
{
    public partial class Lanche_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaNome = table.Column<string>(maxLength: 100, nullable: false),
                    CategoriaDescricao = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Lanche",
                columns: table => new
                {
                    LancheId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LancheNome = table.Column<string>(maxLength: 100, nullable: false),
                    DescCurta = table.Column<string>(maxLength: 100, nullable: false),
                    DescLonga = table.Column<string>(maxLength: 200, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    ImagemUrl = table.Column<string>(maxLength: 200, nullable: false),
                    ImagemThumbnailUrl = table.Column<string>(maxLength: 200, nullable: false),
                    Preferido = table.Column<bool>(nullable: false),
                    EmEstoque = table.Column<bool>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Lanche", x => x.LancheId);
                    table.ForeignKey(
                        name: "FK_Tbl_Lanche_Tbl_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Tbl_Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Lanche_CategoriaId",
                table: "Tbl_Lanche",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Lanche");

            migrationBuilder.DropTable(
                name: "Tbl_Categoria");
        }
    }
}
