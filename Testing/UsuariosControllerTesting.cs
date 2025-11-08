using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SIGU.API.Controllers;
using SIGU.API.Data;
using SIGU.API.Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SIGU.Tests
{
    public class UsuariosControllerTests
    {
        private List<Usuario> GetFakeUsuario()
        {
            return new List<Usuario>
            {
                new Usuario { id = 1, nombre = "Carlos", correo = "carlos@uni.com", rol = "Admin" },
                new Usuario { id = 2, nombre = "Ana" , correo = "ana@uni.com", rol = "Estudiante" }
            };
        }

        private SiguContext GetMockContext()
        {
            var usuarios = GetFakeUsuario().AsQueryable();

            var mockSet = new Mock<SiguContext<Usuario>>();
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(usuarios.Provider);
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(usuarios.Expression);
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(usuarios.ElementType);
            mockSet.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(usuarios.GetEnumerator());

            var mockContext = new Mock<SiguContext>();
            mockContext.Setup(c => c.usuarios).Returns(mockSet.Object);

            return mockContext.Object;
        }

        [Fact]
        public async Task GetUsuarios_RetornarAll_Usuarios()
        {
            // Arrange
            var context = GetMockContext();
            var controller = new UsuariosController(context);

            // Act
            var result = await controller.GetUsuarios();

            // Assert
            var okResult = Assert.IsType<ActionResult<IEnumerable<Usuario>>>(result);
            var usuarios = Assert.IsAssignableFrom<IEnumerable<Usuario>>(okResult.Value);
            Assert.Equal(2, usuarios.Count());
        }


    }

    internal class SiguContext<T>
    {
    }
}
