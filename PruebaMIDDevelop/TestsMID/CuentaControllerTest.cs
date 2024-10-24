using Microsoft.AspNetCore.Mvc;
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
    public class CuentaControllerTest
    {
        [Fact]
        public async Task getCuentaExistente()
        {

            var mockCuentaServicio = new Mock<CuentaRepository>();
            var cuenta = new Cuenta { Id = 1, NumeroCuenta = 1234,  TipoCuenta= "Corriente", SaldoInicial = 3000f, Estado = true};

            mockCuentaServicio.Setup(servicio => servicio.GetById(1))
                .ReturnsAsync(cuenta);

            var controller = new CuentaController(mockCuentaServicio.Object);

            var result = await controller.getCuenta(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedCuenta = Assert.IsType<Cuenta>(okResult.Value);
            Assert.Equal(cuenta.Id, returnedCuenta.Id);
            Assert.Equal(cuenta.NumeroCuenta, returnedCuenta.NumeroCuenta);
            Assert.Equal(cuenta.TipoCuenta, returnedCuenta.TipoCuenta);
            Assert.Equal(cuenta.SaldoInicial, returnedCuenta.SaldoInicial);
            Assert.Equal(cuenta.Estado,returnedCuenta.Estado);
        }
    }
}
