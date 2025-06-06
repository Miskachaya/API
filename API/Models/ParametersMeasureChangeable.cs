﻿using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ParametersMeasureChangeable
{
    public int? Id { get; set; }

    public int? BlockId { get; set; }

    public double? VaoltageValue { get; set; }

    public double? CurrentValue { get; set; }

    public double? ActiveLoadPower { get; set; }

    public double? FullLoadPower { get; set; }

    public double? LoadPowerFactor { get; set; }

    public double? MicrogridFrequency { get; set; }

    public double? LoadActivePower { get; set; }

    public double? MicrogridLoadPower { get; set; }

    public double? Inductance { get; set; }

    public double? ActiveResistance { get; set; }

    public DateTime? Time { get; set; }
}
