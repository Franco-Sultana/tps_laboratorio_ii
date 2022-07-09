using System;
using System.Text;

namespace Entidades
{
    public class Producto
    {
        protected string nombreProducto;
        protected double precio;
        protected string marca;
        protected int cantidadStock;

        public Producto() { }

        public Producto(double precio, string marca, string nombreProducto, int cantidadStock)
        {
            this.precio = precio;
            this.marca = marca;
            this.nombreProducto = nombreProducto;
            this.cantidadStock = cantidadStock;
        }

        public double Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }

        public int CantidadStock
        {
            get { return this.cantidadStock; }
            set { this.cantidadStock = value; }

        }

        public string Marca
        {
            get { return this.marca; }
            set { this.marca = value; }

        }

        public string NombreProducto
        {
            get { return this.nombreProducto; }
            set { this.nombreProducto = value; }

        }

        public static bool operator ==(Producto p1, Producto p2)
        {
            return p1 is not null && p2 is not null && p1.marca == p2.marca && p1.precio == p2.precio && p1.nombreProducto == p2.nombreProducto;
        }

        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }


        public void ReducirStock(int cantidad)
        {
            this.cantidadStock = this.cantidadStock - cantidad;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"STOCK: {this.cantidadStock} - ");
            sb.AppendLine($"PRODUCTO: {this.nombreProducto} - ");
            sb.AppendLine($"PRECIO: {this.precio} - ");
            sb.AppendLine($"MARCA: {this.marca}");
            
            return sb.ToString();
        }
    }
}
