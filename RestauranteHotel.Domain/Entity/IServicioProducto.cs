using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteHotel.Domain.Entity
{
    public interface IServicioProducto
    {
        string Id { get; }
        string Nombre { get;}
        decimal Existencia { get; }
        decimal Precio { get;}
        decimal Costo { get; }

        public abstract string Entrada(decimal existencia);
        public abstract string Salida(decimal existencia);

    }
}
