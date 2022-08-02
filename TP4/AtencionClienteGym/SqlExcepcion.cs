using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SqlExcepcion : Exception
    {
        public SqlExcepcion(string message) : base(message) { }

        public SqlExcepcion(string message, Exception innerException) : base(message, innerException) { }

    }
}
