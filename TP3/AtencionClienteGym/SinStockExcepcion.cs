﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SinStockExcepcion : Exception
    {
        public SinStockExcepcion(string message) : base(message) { }

        public SinStockExcepcion(string message, Exception innerException) : base(message, innerException) { }
    }
}
