using NSubstitute;
using NUnit.Framework;
using Splan.Platform.Application;
using Splan.Platform.Application.Employee.Commands;
using Splan.Platform.Application.Employee.Dtos;
using Splan.Platform.Domain.Employee;
using Splan.Platform.Domain.Employee.Exceptions;
using Splan.Platform.Domain.Enums;
using Splan.Platform.Domain.GlobalServices;

namespace Splan.Platform.Tests
{
    [TestFixture]
    public class SplanAppServiceTest
    {
        private IEmployeeRepository employeeRepositoryMock;
        private ISplanAppService splanAppService;
        private IGlobalRepository globalRepository;

        [SetUp]
        public void Setup()
        {
            globalRepository = Substitute.For<IGlobalRepository>();
            employeeRepositoryMock = Substitute.For<IEmployeeRepository>();
            splanAppService = new SplanAppService(employeeRepositoryMock, globalRepository);
        }


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
                ContractingRegime = 1,
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
            Assert.ThrowsAsync<ArgumentNullException>(async () => await splanAppService.GetEmployeeById(Guid.Empty));
        }

        [Test]
        public void GetById_Should_Throw_EmployeeNotFound_When_Employee_Is_Nul()
        {
            employeeRepositoryMock.GetById(Arg.Any<Guid>()).Returns(default(Employee));

            Assert.ThrowsAsync<EmployeeNotFoundException>(async () => await splanAppService.GetEmployeeById(Guid.NewGuid()));
        }

        [Test]
        public async Task GetById()
        {
            var expectedEmployee = new Employee()
            {
                Name = "Test",
                Position = "position",
                EducationalBackground = "sds",
                //ContractingRegime = (ContractingRegime)2,
                Coordinator = false,
                RhClassification = "indireto"
            };

            employeeRepositoryMock.GetById(Arg.Any<Guid>()).Returns(expectedEmployee);

            var result = await splanAppService.GetEmployeeById(Guid.NewGuid());

            Assert.That(result, Is.TypeOf<EmployeeDto>());
            Assert.That(result.Name, Is.EqualTo(expectedEmployee.Name));
        }

        [Test]
        public async Task Get_Should_Return_A_EmptyList_If_Repository_Is_Empty()
        {
            var result = await splanAppService.Get(CancellationToken.None);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task Delete_Should_Throw_When_Command_Is_Null()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await splanAppService.Delete(null, CancellationToken.None));
        }

        [Test]
        public void Delete_Should_Throw_EmployeeNotFound_When_Employee_Is_Nul()
        {
            employeeRepositoryMock.GetById(Arg.Any<Guid>()).Returns(default(Employee));

            var command = new DeleteEmployeeCommand()
            {
                EmployeeId = Guid.NewGuid()
            };

            Assert.ThrowsAsync<EmployeeNotFoundException>(async () => await splanAppService.Delete(command, CancellationToken.None));
        }

        [Test]
        public async Task Delete()
        {
            var expectedEmployee = new Employee()
            {
                Name = "test",
                Position = "position",
                Coordinator = false,
                Id = Guid.NewGuid()
            };

            var command = new DeleteEmployeeCommand()
            {
                EmployeeId = expectedEmployee.Id
            };

            employeeRepositoryMock.GetById(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(expectedEmployee);

            await splanAppService.Delete(command);


            var result = await splanAppService.GetEmployeeById(expectedEmployee.Id);

            Assert.That(result, Is.Not.Null);

            await employeeRepositoryMock.Received(1).Delete(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
        }

        [Test]
        public async Task Update()
        {
            var expectedEmployee = new Employee()
            {
                Name = "test",
                Position = "position",
                Coordinator = false,
                Id = Guid.NewGuid()
            };

            employeeRepositoryMock.GetSingleOrDefaultAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(expectedEmployee);

            var command = new UpdateEmployeeCommand()
            {
                Name = "Anthony",
                Position = "Estagiário",
                EmployeeId = expectedEmployee.Id
            };

            await splanAppService.Update(command);

            employeeRepositoryMock.GetById(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(expectedEmployee);

            var result = await splanAppService.GetEmployeeById(command.EmployeeId);

            Assert.That(result.Name, Is.EqualTo(command.Name));

            await employeeRepositoryMock.Received(1).UpdateDatabase(Arg.Any<CancellationToken>());
        }
    }
}
