using Consesionaria.Controllers;
using Consesionaria.Entity;
using Consesionaria.UOWork;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;

namespace TestConsesionaria
{
    public class UnitTest1
    {

        [Fact]
        public void Test1()
        {
            var dbfake = A.Fake<IUnitOfWork>();
            A.CallTo(() => dbfake.ClienteRepo.GetAll());
            var controller = new ClienteController(dbfake);

            var test = controller.Get();
            Assert.NotNull(test);
            
        }
        [Fact]
        public void Test2()
        {
            var dbfake = A.Fake<IUnitOfWork>();
            A.CallTo(() => dbfake.ClienteRepo.GetAll());
            var controller = new ClienteController(dbfake);
            Cliente cliente = new Cliente()
            {
                Id = 1,
                Nombre = "rafa",
                Apellido = "Moragues",
                Dni= "55555000",
                Direccion = "jujuy 3333"
            };
            var test = controller.Post(cliente);
            //Assert.IsType<OkObjectResult>();

        }
    }
}