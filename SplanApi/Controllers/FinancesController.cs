using Microsoft.AspNetCore.Mvc;
using Splan.Platform.Application;
using Splan.Platform.Application.Finances.Commands;
using SplanApi.ViewModels;

namespace SplanApi.Controllers
{
    [ApiController]
    [Route("[controller]/{projectId:guid}")]
    public class FinancesController : ControllerBase
    {
        private readonly ISplanAppService SplanAppService;

        public FinancesController(ISplanAppService splanAppService)
        {
            SplanAppService = splanAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromRoute] Guid projectId, [FromBody] AddFinanceItemCommand command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var employeeKey = await SplanAppService.AddFinanceItem(command, projectId, cancellationToken);

            return Ok(employeeKey);
        }

        [HttpGet]
        public async Task<IActionResult> GetFinanceItens([FromRoute] Guid projectId, CancellationToken cancellationToken = default)
        {
            var itensDto = await SplanAppService.ListFinanceItens(projectId, cancellationToken);

            return Ok(itensDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFinanceItem([FromRoute] Guid projectId, UpdateFinanceItemCommand command, CancellationToken cancellationToken = default)
        {
            await SplanAppService.UpdateFinanceItem(projectId, command, cancellationToken);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFinanceItem([FromRoute] Guid projectId, DeleteFinanceItemCommand command, CancellationToken cancellationToken = default)
        {
            await SplanAppService.DeleteFinanceItem(projectId, command, cancellationToken);

            return Ok();
        }

        [HttpPost("/UploadPdf")]
        public async Task<IActionResult> UploadPdf([FromForm] AddPdfViewModel pdfViewModel, CancellationToken cancellationToken = default)
        {
            if (pdfViewModel is null)
                return BadRequest("No file uploaded.");

            var pdfId = await SplanAppService.AddPdf(pdfViewModel.Pdf, pdfViewModel.ToCommand(), cancellationToken);

            return Ok($"File uploaded successfully. PDF ID: {pdfId}");
        }

        [HttpGet("/DownloadPdf")]
        public async Task<IActionResult> DownloadPdf(Guid ItemId, CancellationToken cancellationToken = default)
        {
            var pdf = await SplanAppService.DownloadPdf(ItemId, cancellationToken);

            return File(pdf.PdfData, "application/pdf", $"{pdf.Name}.pdf");
        }
    }
}
