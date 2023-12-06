using Splan.Platform.Domain.Finances;

namespace Splan.Platform.Application.Finances.Dtos
{
    public class FinanceItemDto
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public decimal Value { get; set; }

        public string Supplier { get; set; }


        public static FinanceItemDto ToDto(FinanceItem financeItem)
        {
            if (financeItem is null)
                throw new ArgumentNullException(nameof(financeItem));

            var dto = new FinanceItemDto()
            {
                Name = financeItem.Name,
                Date = financeItem.Date,
                Supplier = financeItem.Supplier,
                Value = financeItem.Value
            };

            return dto;
        }

        public static IList<FinanceItemDto> ToDto(IList<FinanceItem> itensList)
        {
            if (itensList is null)
                return Enumerable.Empty<FinanceItemDto>().ToList();

            var dtoList = new List<FinanceItemDto>();

            foreach (var item in itensList)
            {
                dtoList.Add(FinanceItemDto.ToDto(item));
            }

            return dtoList;
        }
    }
}
