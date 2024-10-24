using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using PruebaMIDDevelop.Controllers;
using PruebaMIDDevelop.Data;
using PruebaMIDDevelop.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsMID.Tests
{
    public class ClienteControllerTests
    {
        [Fact]
        public async Task getClienteExistente()
        {
            Persona personExample = new Persona();

            personExample.Id = 1;
            personExample.Nombre = "prueba";
            personExample.Identificacion = "190599";
            personExample.Telefono = "8717842321";
            personExample.Genero = "Masculino";
            personExample.Direccion = "Calle 123"; 


            var mockClienteServicio = new Mock<ClienteRepository>();
            var cliente = new Cliente { Id = 1, Password = "1234", Estado = true, PersonaID = 1};

            mockClienteServicio.Setup(servicio => servicio.GetById(1))
                .ReturnsAsync(cliente);

            var controller = new ClienteController(mockClienteServicio.Object);

            var result = await controller.getCliente(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedCliente = Assert.IsType<Cliente>(okResult.Value);
            Assert.Equal(cliente.Id, returnedCliente.Id);
            Assert.Equal(cliente.Password, returnedCliente.Password);
            Assert.Equal(cliente.Estado, returnedCliente.Estado);
            Assert.Equal(cliente.PersonaID, returnedCliente.PersonaID);
        }

    }
}
