using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gym<T> 
    {
        private List<T> lista;

        public Gym()
        {
            this.lista = new List<T>();
        }

        public List<T> Lista
        {
            get { return this.lista; }
        }
        public static bool operator +(Gym<T> dp, T atributo)
        {
            if(dp != atributo)
            {
                dp.lista.Add(atributo);
                return true;
            }
            return false;
        }

        public static bool operator -(Gym<T> dp, T atributo)
        {
            if(dp == atributo)
            {
                dp.lista.Remove(atributo);
                return true;
            }
            return false;
        }

        public bool Agregar(T atributo)
        {
            return this + atributo;
        }

        public bool Remover(T atributo)
        {
            return this - atributo;
        }

        public static bool operator ==(Gym<T> dp, T atributo)
        {
            foreach (T item in dp.lista)
            {
                if (item.Equals(atributo))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Gym<T> dp, T atributo)
        {
            return !(dp == atributo);
        }

        

        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (T item in this.lista)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
