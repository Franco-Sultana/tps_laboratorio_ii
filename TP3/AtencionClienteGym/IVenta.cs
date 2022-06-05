using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IVenta 
    {
        /// <summary>
        /// Propiedad para la cantidad de productos que se va a vender
        /// </summary>
        int Cantidad { get; set; }

        /// <summary>
        /// Vende el producto, retornando el precio y reduciendo el stock
        /// </summary>
        /// <returns>Precio</returns>
        double Vender();

        /// <summary>
        /// Detalla los datos de la venta
        /// </summary>
        /// <returns>string con datos de la venta</returns>
        string DetallarVenta();
    }
}
