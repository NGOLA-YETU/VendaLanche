using System.Collections.Generic;
using DataBase;
using Interfaces;
using VendaLanche.Models;

namespace Repositories
{
    public class CategoriaRepo : ICategoria
    {
        private readonly LancheDbContext _context;

        public CategoriaRepo(LancheDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Categoria> Categorias =>_context.Tbl_Categoria ;
    }
}