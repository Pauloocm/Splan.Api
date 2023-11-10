namespace Splan.Platform.Domain.Pdf
{
    public class Pdf
    {
        public Guid Id { get; set; }
        public byte[] PdfData { get; set; }

        public Pdf(byte[] data)
        {
            Id = Guid.NewGuid();
            PdfData = data;
        }

        public Pdf()
        {
            
        }
    }
}
