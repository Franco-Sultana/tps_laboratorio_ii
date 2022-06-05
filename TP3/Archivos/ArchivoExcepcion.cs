using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class ArchivoExcepcion : Exception
    {
        ArchivoExcepcion(string message) :base(message){ }

        public ArchivoExcepcion(string message, Exception innerException) : base(message, innerException) { }
    }
}
