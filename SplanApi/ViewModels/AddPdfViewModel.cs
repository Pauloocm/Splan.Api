using Microsoft.AspNetCore.Mvc;
using Splan.Platform.Application.Pdf.Commands;
using System.ComponentModel.DataAnnotations;

namespace SplanApi.ViewModels;

public class AddPdfViewModel
{
    [FromForm]
    public IFormFile Pdf { get; set; }

    [Required] public string Name { get; set; }

    public AddPdfViewModel()
    {

    }

    public AddPdfCommand ToCommand()
    {
        var command = new AddPdfCommand()
        {
            Pdf = Pdf.OpenReadStream(),
            Name = Name,
        };

        return command;
    }
}