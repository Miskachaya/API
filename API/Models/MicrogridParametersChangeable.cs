using System;
using System.Collections.Generic;
using API.Configurations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class MicrogridParametersChangeable
{
    public int? BlockId { get; set; }

    public string? BlockType { get; set; }

    public int? StandId { get; set; }

    public virtual ICollection<ParametersChangeable>? ParametersChangeables { get; set; } = new List<ParametersChangeable>();

    public virtual StandPart? Stand { get; set; }
}

