using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Rhino.Mock
{
    [TestClass]
    public class TransporteMocksTest
    {
        [TestMethod]
        public void SiElTransporteEstaLlenoLaMitadOMasPuedePartirMock()
        {
            var transporte = MockRepository.GenerateStub<ITransporte>();
            transporte.Stub(t => t.PorcentajeCarga()).Return(0.5);

            var mercancia = new Mercancia();
            mercancia.Peso = 15;
            mercancia.Enviar(transporte);

            Assert.IsTrue(mercancia.SeEnvio);
            transporte.AssertWasCalled(t => t.PorcentajeCarga());
            transporte.AssertWasCalled(t => t.Cargar(mercancia.Peso));
        }

        [TestMethod]
        public void SiElPesoDelEnvioExcedeLaCapacidadNoSeEnviaLaCargaMock()
        {
            var transporte = MockRepository.GenerateStub<ITransporte>();
            transporte.Stub(t => t.PorcentajeCarga()).Return(0.5);

            transporte.Capacidad = 400;
            transporte.Cargar(484);

            var mercancia = new Mercancia();
            mercancia.Peso = 15;
            mercancia.Enviar(transporte);

            Assert.IsTrue(mercancia.SeEnvio);
            transporte.AssertWasCalled(t => t.PorcentajeCarga());
            transporte.AssertWasCalled(t => t.Cargar(mercancia.Peso));
        }

        [TestMethod]
        public void SiLaCargaInicialMasElPesoNoEnviaMock()
        {
            var transporte = MockRepository.GenerateStub<ITransporte>();
            transporte.Stub(t => t.PorcentajeCarga()).Return(0.5);

            transporte.Capacidad = 400;
            transporte.Cargar(484);

            var mercancia = new Mercancia();
            mercancia.Peso = 15;
            mercancia.Enviar(transporte);

            Assert.IsTrue(mercancia.SeEnvio);
            transporte.AssertWasCalled(t => t.PorcentajeCarga());
            transporte.AssertWasCalled(t => t.Cargar(mercancia.Peso));
        }


        [TestMethod]
        public void SiLaCargaInicialMasElPesoSeEnviaMock()
        {
            var transporte = MockRepository.GenerateStub<ITransporte>();
            transporte.Stub(t => t.PorcentajeCarga()).Return(0.5);

            transporte.Capacidad = 700;
            transporte.Cargar(486);

            var mercancia = new Mercancia();
            mercancia.Peso = 15;
            mercancia.Enviar(transporte);

            Assert.IsTrue(mercancia.SeEnvio);
            transporte.AssertWasCalled(t => t.PorcentajeCarga());
            transporte.AssertWasCalled(t => t.Cargar(mercancia.Peso));
        }
    }
}
