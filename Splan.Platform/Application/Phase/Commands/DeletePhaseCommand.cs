﻿using System.ComponentModel.DataAnnotations;

namespace Splan.Platform.Application.Phase.Commands
{
    public class DeletePhaseCommand
    {
        [Required]
        public Guid PhaseId { get; set; }
    }
}
