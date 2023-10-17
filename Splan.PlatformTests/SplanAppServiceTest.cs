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
                HiringRegimeId = 1,
                IsCoordinator = false,
                EducationDegree = "Técnico",   
                Name = "Test",
                Function = "junior developer",
                Classification = "tsdds"
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
                Function = "position",
                EducationDegree = "sds",
                //ContractingRegime = (ContractingRegime)2,
                IsCoordinator = false,
                Classification = "indireto"
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
                Key = Guid.NewGuid()
            };

            Assert.ThrowsAsync<EmployeeNotFoundException>(async () => await splanAppService.Delete(command, CancellationToken.None));
        }

        [Test]
        public async Task Delete()
        {
            var expectedEmployee = new Employee()
            {
                Name = "test",
                Function = "position",
                IsCoordinator = false,
                Key = Guid.NewGuid()
            };

            var command = new DeleteEmployeeCommand()
            {
                Key = expectedEmployee.Key
            };

            employeeRepositoryMock.GetById(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(expectedEmployee);

            await splanAppService.Delete(command);


            var result = await splanAppService.GetEmployeeById(expectedEmployee.Key);

            Assert.That(result, Is.Not.Null);

            await employeeRepositoryMock.Received(1).Delete(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
        }

        [Test]
        public async Task Update()
        {
            var expectedEmployee = new Employee()
            {
                Name = "test",
                Function = "position",
                IsCoordinator = false,
                Key = Guid.NewGuid()
            };

            employeeRepositoryMock.GetSingleOrDefaultAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(expectedEmployee);

            var command = new UpdateEmployeeCommand()
            {
                Name = "Anthony",
                Function = "Estagiário",
                Key = expectedEmployee.Key
            };

            await splanAppService.Update(command);

            employeeRepositoryMock.GetById(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(expectedEmployee);

            var result = await splanAppService.GetEmployeeById(command.Key);

            Assert.That(result.Name, Is.EqualTo(command.Name));

            await employeeRepositoryMock.Received(1).UpdateDatabase(Arg.Any<CancellationToken>());
        }
    }
}
