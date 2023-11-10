namespace Splan.Platform.Domain.Pdf
{
    public class Pdf
    {
        public Guid PdfId { get; set; }
        public byte[] PdfData { get; set; }

        public Pdf(byte[] data)
        {
            PdfId = Guid.NewGuid();
            PdfData = data;
        }

        public Pdf()
        {
            
        }
    }
}
