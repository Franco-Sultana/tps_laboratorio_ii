using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Entidades
{
    public enum eTalle
    {
        XS, S, M, L, XL
    }
    public class IndumentariaDeportiva : Producto, IVenta
    {
        private eTalle talle;


        public IndumentariaDeportiva() { }

        public IndumentariaDeportiva(double precio, string marca, string nombreProducto, int cantidad,eTalle talle) : base(precio, marca, nombreProducto, cantidad)
        {
            this.talle = talle;
        }

        public eTalle Talle
        {
            get { return this.talle; }
            set { this.talle = value; }
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

        public static bool operator ==(IndumentariaDeportiva i1, IndumentariaDeportiva i2)
        {
            return i1 == (Producto)i2 && i1.talle == i2.talle;
        }

        public static bool operator !=(IndumentariaDeportiva i1, IndumentariaDeportiva i2)
        {
            return !(i1 == i2);
        }

        public override bool Equals(object obj)
        {
            return obj is IndumentariaDeportiva && this == (IndumentariaDeportiva)obj;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append(base.ToString());
            sb.AppendLine($" - TALLE: {this.talle}");
            return sb.ToString();
        }

        /// <summary>
        /// Método de IVenta
        /// Vende el producto, retornando el precio y reduciendo el stock. Si la cantidad vendida supera las 5 unidades, se hace un descuento del 5%
        /// </summary>
        /// <returns>Precio</returns>
        public double Vender()
        {
            double precioFinal = Cantidad * this.precio;
            if(this.Cantidad > this.cantidadStock)
            {
                throw new SinStockExcepcion("Producto sin stock");
            }
            ReducirStock(Cantidad);
            if (Cantidad > 5)
            {
                return (precioFinal) * 0.95;
            }
            return precioFinal;
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
            sb.AppendLine($"TOTAL RECAUDADO: {(precio * Cantidad)*0.95}");
            sb.AppendLine("================================");
            return sb.ToString();
        }

    }
}
