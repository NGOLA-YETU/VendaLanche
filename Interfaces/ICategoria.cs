using System.Collections.Generic;
using VendaLanche.Models;

namespace Interfaces
{
    public interface ICategoria
    {
        IEnumerable <Categoria> Categorias{get;}
    }
}