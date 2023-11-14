namespace Splan.Platform.Domain.Pdf
{
    public class Pdf
    {
        public Guid Id { get; set; }
        public Guid FinanceItemId { get; set; }
        public string Name { get; set; }
        public byte[] PdfData { get; set; }

        public Pdf(byte[] data, Guid financeItemId, string name)
        {
            Id = Guid.NewGuid();
            PdfData = data;
            Name = name;
            FinanceItemId = financeItemId;
        }

        public Pdf()
        {
            
        }
    }
}
