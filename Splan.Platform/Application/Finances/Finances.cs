using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splan.Platform.Application.Finances
{
    public class Finances
    {
        public int Id {  get; set; }

        public string Rubric { get; set; }

        public DateTime Month { get; set; }

        public float Price { get; set; }

        public int DocumentNumber { get; set; }

        public string Supplier { get; set; }

        public void Update(string? rubric, string? supplier, DateTime? month, int? documentNumber, float? price)
        {
            if (!String.IsNullOrEmpty(rubric))
            {
                Rubric = rubric;
            }
            if (!String.IsNullOrEmpty(supplier))
            {
                Supplier = supplier;
            }
            if (month is not null)
            {
                Month = (DateTime)month;
            }
            if(documentNumber is not null)
            {
                DocumentNumber = (int)documentNumber;
            }
            if(price is not null)
            {
                Price = (float)price;
            }
            
        }

    }
}
