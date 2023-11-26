using Splan.Platform.Domain.BaseSpecification;
using System.Linq.Expressions;

namespace Splan.Platform.Domain.Employee.Specifications
{
    public class WhoWorkedMostSpecification : ExpressionSpecification<Employee>
    {
        public WhoWorkedMostSpecification(int workedMonth) : base(e => e.HoursWorkedMonth > workedMonth)
        {
        }
    }
}
