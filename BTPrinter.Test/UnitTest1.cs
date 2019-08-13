using System;
using System.IO;
using BTPrinter.BE.Negocio.Reglas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BTPrinter.Test
{
    [TestClass]
    public class GestionDispositivosTest
    {
        [TestMethod]
        public void IniciarRecepcionImagenBT()
        {
            GestionDispositivos gestion = new GestionDispositivos();
            MemoryStream archivo = gestion.IniciarRecepcionImagenBT();
            Assert.IsNotNull(archivo);
        }
    }
}
