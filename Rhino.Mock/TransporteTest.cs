using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rhino.Mock
{
    [TestClass]
    public class TransporteTest
    {


        [TestMethod]
        public void SiElTransporteEstaLlenoLaMitadOMasPuedePartir()
        {
            var transporte = new Transporte();
            transporte.Capacidad = 1000;
            transporte.Cargar(400);

            var mercancia = new Mercancia();
            mercancia.Peso = 15;
            mercancia.Enviar(transporte);

            Assert.IsFalse(mercancia.SeEnvio);
        }

        [TestMethod]
        public void SiElPesoDelEnvioExcedeLaCapacidadNoSeEnviaLaCarga()
        {
            var transporte = new Transporte();
            transporte.Capacidad = 400;
            transporte.Cargar(484);

            var mercancia = new Mercancia();
            mercancia.Peso = 15;
            mercancia.Enviar(transporte);

            Assert.IsFalse(mercancia.SeEnvio);
        }

        [TestMethod]
        public void SiLaCargaInicialMasElPesoNoEnvia()
        {
            var transporte = new Transporte();
            transporte.Capacidad = 400;
            transporte.Cargar(484);

            var mercancia = new Mercancia();
            mercancia.Peso = 15;
            mercancia.Enviar(transporte);

            Assert.IsFalse(mercancia.SeEnvio);
        }


        [TestMethod]
        public void SiLaCargaInicialMasElPesoSeEnviaMock()
        {
            var transporte = new Transporte();
            transporte.Capacidad = 700;
            transporte.Cargar(486);

            var mercancia = new Mercancia();
            mercancia.Peso = 15;
            mercancia.Enviar(transporte);

            Assert.IsFalse(mercancia.SeEnvio);
        }
    }
}
