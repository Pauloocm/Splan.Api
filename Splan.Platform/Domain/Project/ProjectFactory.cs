using Splan.Platform.Application.Phase;
using Splan.Platform.Domain.Enums;

namespace Splan.Platform.Domain.Project
{
    public static class ProjectFactory
    {
        public static Project Create(string name, string company, DateTime startDate, DateTime expirationDate, ProjectStatus status)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name));

            if (string.IsNullOrWhiteSpace(company))
                throw new ArgumentException(nameof(company));

            var project = new Project()
            {
                Name = name,
                Company = company,
                StartDate = startDate,
                ExpirationDate = expirationDate,
                Status = status
            };

            return project;
        }
    }
}
