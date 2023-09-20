using NSubstitute;
using NUnit.Framework;
using Splan.Platform.Application;
using Splan.Platform.Domain.Employee;

namespace Splan.Platform.Tests
{
    [TestFixture]
    public class SplanAppServiceTest
    {
        private IEmployeeRepository employeeRepositoryMock;
        private ISplanAppService splanAppService;


        [SetUp]
        public void Setup()
        {
            employeeRepositoryMock = Substitute.For<IEmployeeRepository>();
            splanAppService = new SplanAppService(employeeRepositoryMock);
        }

        //TODO faça o teste para verificar o comportamento da linha 17 da classe SplanAppService,
        //repare que a classe já está sendo injetada, você só precisa verificar se será gerado o throw que foi setado lá na linha 17

        [Test]
        public void Add_Should_Throw_When_Command_Is_Null()
        {
            
        }

    }
}
