using Microsoft.EntityFrameworkCore.Migrations;

namespace VendaLanche.Migrations
{
    public partial class Lanch_Insert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
            {
                //Inserir categorias
                migrationBuilder.Sql("INSERT INTO Tbl_Categoria(CategoriaNome, CategoriaDescricao)values('Fast-Food','comida rapida')");
                migrationBuilder.Sql("INSERT INTO Tbl_Categoria(CategoriaNome, CategoriaDescricao)values('Kakes','Bolos para todos os gostos')");

                //Lanches
                migrationBuilder.Sql("INSERT INTO Tbl_Lanche(LancheNome, DescCurta, DescLonga, Preco, ImagemUrl, ImagemThumbnailUrl, Preferido, EmEstoque, CategoriaId)values('Tomato-Burguer','feiro com pão integral e Carne','',950.99,'https://www.generalpepper.com.br/wp-content/uploads/2018/03/lanche-general-pepper-560x442.png','https://www.generalpepper.com.br/wp-content/uploads/2018/03/lanche-general-pepper-560x442.png',0,1,1)");
                migrationBuilder.Sql("INSERT INTO Tbl_Lanche(LancheNome, DescCurta, DescLonga, Preco, ImagemUrl, ImagemThumbnailUrl, Preferido, EmEstoque, CategoriaId)values('Sandes Nt','Sandes de frango natural','',450.95,'http://1.bp.blogspot.com/-NavT_yhJsuY/U9qzIj2ZIyI/AAAAAAAABPc/1coTHdhdhJY/s1600/Sandu%C3%ADche-de-frango-natural-500x371.png','http://1.bp.blogspot.com/-NavT_yhJsuY/U9qzIj2ZIyI/AAAAAAAABPc/1coTHdhdhJY/s1600/Sandu%C3%ADche-de-frango-natural-500x371.png',0,1,1)");
                migrationBuilder.Sql("INSERT INTO Tbl_Lanche(LancheNome, DescCurta, DescLonga, Preco, ImagemUrl, ImagemThumbnailUrl, Preferido, EmEstoque, CategoriaId)values('Burguer-Tower','Hamburguer goloso com 3 camadas de pão','',4999.99,'https://static.takeaway.com/images/restaurants/be/N010NN5/products/menu_towerburger-min.png','https://static.takeaway.com/images/restaurants/be/N010NN5/products/menu_towerburger-min.png',1,1,1)");

                migrationBuilder.Sql("INSERT INTO Tbl_Lanche(LancheNome, DescCurta, DescLonga, Preco, ImagemUrl, ImagemThumbnailUrl, Preferido, EmEstoque, CategoriaId)values('Bolo Rei','recheado com cobertura de chocolate coroada','',2995.70,'http://3.bp.blogspot.com/-nKnEOmcJ1f4/UfBO1VzmjeI/AAAAAAAAV1c/FgT5iAEhWUA/s1600/10.jpg','http://3.bp.blogspot.com/-nKnEOmcJ1f4/UfBO1VzmjeI/AAAAAAAAV1c/FgT5iAEhWUA/s1600/10.jpg',0,1,2)");
                migrationBuilder.Sql("INSERT INTO Tbl_Lanche(LancheNome, DescCurta, DescLonga, Preco, ImagemUrl, ImagemThumbnailUrl, Preferido, EmEstoque, CategoriaId)values('Cremado a Uva','recheado com cobertura de uva','',5995.70,'http://1.bp.blogspot.com/-169JY06IGCM/UYJ3piWJHvI/AAAAAAAABpw/WCg9pNhyFZY/s1600/3.png','http://1.bp.blogspot.com/-169JY06IGCM/UYJ3piWJHvI/AAAAAAAABpw/WCg9pNhyFZY/s1600/3.png',1,1,2)");
                migrationBuilder.Sql("INSERT INTO Tbl_Lanche(LancheNome, DescCurta, DescLonga, Preco, ImagemUrl, ImagemThumbnailUrl, Preferido, EmEstoque, CategoriaId)values('Choco-Uva','recheado com cobertura de chocolate coroada e uvas vermelhas','',7995.70,'http://www.deliciasdonarosa.com.br/images/bolo-3.png','http://www.deliciasdonarosa.com.br/images/bolo-3.png',1,1,2)");

            }

            protected override void Down(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.Sql("Delete from Tbl_Categoria");
                migrationBuilder.Sql("Delete from Tbl_Lanche");
            }
        
    }
}
