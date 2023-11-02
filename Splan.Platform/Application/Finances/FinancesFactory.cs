using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splan.Platform.Application.Finances
{
    public static class FinancesFactory
    {
        public static Finances Create(string rubric, string supplier)
        {
            if (string.IsNullOrWhiteSpace(rubric))
                throw new ArgumentException(nameof(rubric));

            if (string.IsNullOrWhiteSpace(supplier))
                throw new ArgumentException(nameof(supplier));

            var finances = new Finances()
            {
                Rubric = rubric,
                Supplier = supplier
            };

            return finances;
        }
    }
}
