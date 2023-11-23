using Microsoft.AspNetCore.Mvc;
using Splan.Platform.Application.Pdf.Commands;
using System.ComponentModel.DataAnnotations;

namespace SplanApi.ViewModels;

public class AddPdfViewModel
{
    [FromForm]
    public IFormFile Pdf { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public Guid FinanceItemId { get; set; }

    public AddPdfViewModel()
    {

    }

    public AddPdfCommand ToCommand()
    {
        if (FinanceItemId == Guid.Empty)
            throw new ArgumentNullException(FinanceItemId.ToString());

        var command = new AddPdfCommand()
        {
            Pdf = Pdf.OpenReadStream(),
            Name = Name,
            FinanceItemId = FinanceItemId
        };

        return command;
    }
}