using Microsoft.AspNetCore.Mvc;
using Splan.Platform.Application;
using Splan.Platform.Application.Finances.Commands;
using SplanApi.ViewModels;

namespace SplanApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinancesController : ControllerBase
    {
        private readonly ISplanAppService SplanAppService;

        public FinancesController(ISplanAppService splanAppService)
        {
            SplanAppService = splanAppService;
        }

        [HttpPost("/AddFinanceItem")]
        public async Task<IActionResult> Add([FromRoute] Guid projectId, [FromBody] AddFinanceItemCommand command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var employeeKey = await SplanAppService.AddFinanceItem(command, projectId, cancellationToken);

            return Ok(employeeKey);
        }

        [HttpPost("/UploadPdf")]
        public async Task<IActionResult> UploadPdf([FromForm] AddPdfViewModel pdfViewModel, CancellationToken cancellationToken = default)
        {
            if (pdfViewModel is null)
                return BadRequest("No file uploaded.");

            var pdfId = await SplanAppService.AddPdf(pdfViewModel.Pdf, pdfViewModel.ToCommand());

            return Ok($"File uploaded successfully. PDF ID: {pdfId}");
        }

        [HttpGet("/DownloadPdf")]
        public async Task<IActionResult> DownloadPdf(Guid pdfId, CancellationToken cancellationToken = default)
        {
            var pdf = await SplanAppService.DownloadPdf(pdfId, cancellationToken);

            return File(pdf.PdfData, "application/pdf", $"{pdf.Name}.pdf");
        }

        [HttpGet("/ListFinanceItens")]
        public async Task<IActionResult> GetRhFinance(CancellationToken cancellationToken = default)
        {
            var itensDto = await SplanAppService.ListFinanceItens(cancellationToken);
            return Ok(itensDto);
        }
    }
}
