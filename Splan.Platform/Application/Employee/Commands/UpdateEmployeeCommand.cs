using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Splan.Platform.Application.Employee.Commands
{
    public class UpdateEmployeeCommand
    {
        [Required]
        public Guid Key { get; set; }

        [AllowNull]
        [DefaultValue("")]
        public string Name { get; set; }

        [AllowNull]
        [DefaultValue("")]
        public string Function { get; set; }

        [AllowNull]
        [DefaultValue("")]
        public string EducationDegree { get; set; }

        [AllowNull]
        [DefaultValue(-1)]
        public int HiringRegimeId { get; set; }

        [AllowNull]
        [DefaultValue(false)]
        public bool IsCoordinator { get; set; } = false;

        [AllowNull]
        [DefaultValue("")]
        public string Classification { get; set; }
    }
}
