using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Rhino.Mocks;

namespace Rhino.Mock
{
    [TestClass]
    public class UnitTest1
    {
        const string JugoMora = "Jugo de Mora";
        const string JugoGuanabana = "Jugo de Guanabana";

        [TestMethod]
        public void LaOrdenSeLlenaSiHaySuficienteEnLaBodega()
        {
            var bodega = MockRepository.GenerateStub<IBodega>();
            int cantidadInicial = 50;
            bodega.Stub(b => b.Existencia(JugoMora)).Return(cantidadInicial);

            int cantidadPedida = 50;
            Pedido pedido = new Pedido(JugoMora, cantidadPedida);
            pedido.Llenar(bodega);

            Assert.IsTrue(pedido.SeLleno);
            bodega.AssertWasCalled(b => b.ActualizarExistencia(JugoMora, cantidadInicial - cantidadPedida));
        }
    }
}
