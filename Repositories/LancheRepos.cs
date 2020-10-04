using System.Collections.Generic;
using System.Linq;
using DataBase;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using VendaLanche.Models;

namespace Repositories
{
    public class LancheRepos : ILanche
    {
        private readonly LancheDbContext _context;

        public LancheRepos(LancheDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Lanche> Lanches => _context.Tbl_Lanche.Include(c => c.Categoria);

        public IEnumerable<Lanche> Preferidos => _context.Tbl_Lanche.Where(p => p.Preferido).Include(c => c.Categoria);

        public Lanche GetLancheById(int LancheId)
        {
            return _context.Tbl_Lanche.FirstOrDefault(l => l.LancheId == LancheId);
        }
    }
}