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
    public class MovimientoControllerTest
    {

        [Fact]
        public async Task getMovimientoExistente()
        {

            var mockMovimientoServicio = new Mock<MovimientoRepository>();
            var mockPersonaServicio = new Mock<PersonaRepository>();
            var mockCuentaServicio = new Mock<CuentaRepository>();
            var movimiento = new Movimiento { Id = 1, Fecha = new DateTime(2024,11,01) , Tipo = "Corriente", Valor = 3000f, SaldoDisponible = 6000f };

            mockMovimientoServicio.Setup(servicio => servicio.GetById(1))
                .ReturnsAsync(movimiento);

            var controller = new MovimientosController(mockMovimientoServicio.Object, mockPersonaServicio.Object, mockCuentaServicio.Object);

            var result = await controller.getMovimiento(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedMovimiento = Assert.IsType<Movimiento>(okResult.Value);
            Assert.Equal(movimiento.Id, returnedMovimiento.Id);
            Assert.Equal(movimiento.Fecha, returnedMovimiento.Fecha);
            Assert.Equal(movimiento.Tipo, returnedMovimiento.Tipo);
            Assert.Equal(movimiento.Valor, returnedMovimiento.Valor);
            Assert.Equal(movimiento.SaldoDisponible, returnedMovimiento.SaldoDisponible);
        }

    }
}
