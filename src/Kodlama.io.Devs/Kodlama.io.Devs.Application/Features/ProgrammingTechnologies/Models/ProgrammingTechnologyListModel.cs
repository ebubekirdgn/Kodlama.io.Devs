﻿namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Models
{
    public class ProgrammingTechnologyListModel : BasePageableModel
    {
        public IList<ProgrammingTechnologyListDto> Items { get; set; }
    }
}