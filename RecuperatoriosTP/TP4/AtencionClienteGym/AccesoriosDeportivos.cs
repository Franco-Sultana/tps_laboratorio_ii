using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Entidades
{
    public class AccesoriosDeportivos : Producto, IVenta
    {

        public AccesoriosDeportivos() { }
        public AccesoriosDeportivos(double precio, string marca, string nombreProducto, int cantidad) :base(precio, marca, nombreProducto, cantidad) { }

        public override bool Equals(object obj)
        {
            return obj is AccesoriosDeportivos && this == (Producto)obj;
        }

        [JsonIgnore]
        /// <summary>
        /// Propiedad de IVenta
        /// Propiedad para la cantidad de productos que se va a vender
        /// </summary>
        public int Cantidad
        {
            get;
            set;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append(base.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Método de IVenta
        /// Vende el producto, retornando el precio y reduciendo el stock
        /// </summary>
        /// <returns>Precio</returns>
        public double Vender()
        {
            if(Cantidad > cantidadStock)
            {
                throw new SinStockExcepcion("Producto sin stock");
            }
            ReducirStock(Cantidad);
            return precio * Cantidad;
        }

        /// <summary>
        /// Método de IVenta
        /// Detalla los datos de la venta
        /// </summary>
        /// <returns>string con datos de la venta</returns>
        public string DetallarVenta()
        {
            StringBuilder sb = new();
            sb.AppendLine($"PRODUCTO: {this.nombreProducto}");
            sb.AppendLine($"CANTIDAD VENDIDA: {this.Cantidad}");
            sb.AppendLine($"TOTAL RECAUDADO: {precio * Cantidad}");
            sb.AppendLine("================================");

            return sb.ToString();
        }
    }
}
