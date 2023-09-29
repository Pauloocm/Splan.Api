using NSubstitute;
using NUnit.Framework;
using Splan.Platform.Application;
using Splan.Platform.Application.Employee.Commands;
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
            Assert.ThrowsAsync<ArgumentNullException>(async () => await splanAppService.Add(null, CancellationToken.None));
        }

        [Test]
        public async Task Add()
        {
            var employee = new AddEmployeeCommand()
            {
                ContractingRegime = 0,
                Coordinator = false,
                EducationalBackground = "Técnico",
                Name = "Test",
                Position = "junior developer",
                RhClassification = "tsdds"
            };

            var result = await splanAppService.Add(employee, CancellationToken.None);

            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.TypeOf<Guid>());
        }

        [Test]
        public void GetById_Should_Throw_When_Id_Is_Empty()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await splanAppService.GetById(Guid.Empty));
        }

        public async Task 
    }
}
