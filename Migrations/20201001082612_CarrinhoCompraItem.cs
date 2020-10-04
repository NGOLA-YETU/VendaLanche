using Microsoft.EntityFrameworkCore.Migrations;

namespace VendaLanche.Migrations
{
    public partial class CarrinhoCompraItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarrinhoCompraItems",
                columns: table => new
                {
                    CarrinhoCompraItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LancheId = table.Column<int>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    CarrinhoCompraId = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoCompraItems", x => x.CarrinhoCompraItemId);
                    table.ForeignKey(
                        name: "FK_CarrinhoCompraItems_Tbl_Lanche_LancheId",
                        column: x => x.LancheId,
                        principalTable: "Tbl_Lanche",
                        principalColumn: "LancheId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoCompraItems_LancheId",
                table: "CarrinhoCompraItems",
                column: "LancheId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoCompraItems");
        }
    }
}
