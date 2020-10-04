using System.Collections.Generic;
using VendaLanche.Models;

namespace Interfaces
{
    public interface ILanche
    {
        IEnumerable <Lanche> Lanches{get;}
        IEnumerable <Lanche> Preferidos{get;}
        Lanche GetLancheById (int LancheId);

    }
}