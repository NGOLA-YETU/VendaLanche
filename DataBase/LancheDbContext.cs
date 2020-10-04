using Microsoft.EntityFrameworkCore;
using Models;
using VendaLanche.Models;

namespace DataBase
{
    public class LancheDbContext: DbContext
    {
        public LancheDbContext(DbContextOptions <LancheDbContext> options): base(options)
        { }
        public DbSet <Lanche> Tbl_Lanche{get; set;}
        public DbSet <Categoria> Tbl_Categoria{get; set;}
        public DbSet <CarrinhoCompraItem> CarrinhoCompraItems{get; set;} 
    }
}