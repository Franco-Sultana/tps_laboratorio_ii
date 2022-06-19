using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using Entidades;
using System;
using System.Collections.Generic;

namespace TestsUnitariosGym
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArchivoExcepcion))]
        public void LeerJson_ArchivoNoExiste()
        {
            Producto datos = ClaseSerializadoraJson<Producto>.Leer("ArchivoNoExistenteEnPcDeFrancoSutana");
        }

        [TestMethod]
        [ExpectedException(typeof(SinStockExcepcion))]
        public void VenderProducto_ProductoSinStock()
        {
            AccesoriosDeportivos pTest = new(1000, "Pirulo", "Remera", 0);
            pTest.Cantidad = 1;
            ((IVenta)pTest).Vender();
        }

        [TestMethod]
        public void AgregarALista_PersonaRepetidaPorDNI()
        {
            Gym<Persona> listaP = new();
            Persona p1 = new("Elsa Lame", 34343434, 39, eSexo.Femenino, DateTime.Now, eServicio.ClaseCrossfit);
            listaP.Agregar(p1);
            Persona p2 = new("Elsa Pote", 34343434, 24, eSexo.Femenino, DateTime.Now, eServicio.ClaseCrossfit);

            bool valorEsperado = false;

            Assert.AreEqual(listaP.Agregar(p2), valorEsperado);
        }

    }
}
