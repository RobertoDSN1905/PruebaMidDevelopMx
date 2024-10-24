using Microsoft.IdentityModel.Tokens;
using Moq;
using PruebaMIDDevelop.Controllers;
using PruebaMIDDevelop.Data;
using PruebaMIDDevelop.entities;

namespace PruebasMID
{
    [TestFixture]
    public class ClientesTest
    {
        private ClienteRepository clienteRepository;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void getCliente_Test()
        {
            var clientemock = new Cliente { Id = 1, Estado = true, Password = "1234", Persona}


            Assert.Pass();
        }
    }
}