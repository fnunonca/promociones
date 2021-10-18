using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Promociones.Application.Interface;

namespace Promociones.Test
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IPromocionApplication _promocionApplication;
        public UnitTest1(IPromocionApplication promocionApplication)
        {
            _promocionApplication = promocionApplication;
        }

        [TestMethod]
        public async void TestMethod1()
        {
            //Act
            var respuesta = await _promocionApplication.GetAllAsync();
            //Assert
            Assert.AreEqual(true, respuesta.IsSuccess);

        }
    }
}
