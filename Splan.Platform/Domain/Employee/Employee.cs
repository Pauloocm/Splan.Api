using Splan.Platform.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Splan.Platform.Domain.Employee
{
    public class Employee
    {
        [Key]
        public Guid Key { get; set; }
        public Guid ProjectId { get; set; }


        public string Name { get; set; }

        public string Function { get; set; }

        public string EducationDegree { get; set; }
        public HiringRegime Type { get; set; }

        public int HiringRegimeId { get; set; }

        public bool IsCoordinator { get; set; }

        public int HoursWorkedMonth { get; set; }

        public string Classification { get; set; }
        public DateTime ContractDate { get; set; }
        public decimal ValuePerHour { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }


        public Employee()
        {
            Key = Guid.NewGuid();
            Type = (HiringRegime)Enum.Parse(typeof(HiringRegime), ParseEnum.ParseIntToEnum(HiringRegimeId));
        }

        public void SetRhFinances(DateTime contractDate, decimal valuePerHour, int hoursWorkedMonth)
        {
            ContractDate = contractDate;
            ValuePerHour = valuePerHour;
            HoursWorkedMonth = hoursWorkedMonth;
        }

        public void Update(string name, string position, string educationBackground, int contractingRegime, bool coordinator, string rhClassification)
        {
            if (!String.IsNullOrEmpty(name))
            {
                Name = name;
            }

            if (!String.IsNullOrEmpty(position))
            {
                Function = position;
            }

            if (!String.IsNullOrEmpty(educationBackground))
            {
                EducationDegree = educationBackground;
            }

            if (contractingRegime >= 0 && contractingRegime <= 5)
            {
                HiringRegimeId = contractingRegime;
            }

            IsCoordinator = coordinator;


            if (!String.IsNullOrEmpty(rhClassification))
            {
                Classification = rhClassification;
            }
        }

        internal void UpdateRhFinance(decimal valuePerHour, int hoursWorkedMonth, DateTime contractDateMonth)
        {
            if(valuePerHour > 0)
            {
                ValuePerHour = valuePerHour;
            }
            if (hoursWorkedMonth > 0)
            {
                HoursWorkedMonth = hoursWorkedMonth;
            }
             
            ContractDate = contractDateMonth;
        }
    }
}
