using System;
using System.Collections.Generic;

namespace E_Learning.Server.Models;

public partial class Question
{
    public int QueId { get; set; }

    public string QueText { get; set; } = null!;

    public string Qa { get; set; } = null!;

    public string Qb { get; set; } = null!;

    public string Qc { get; set; } = null!;

    public string Qd { get; set; } = null!;

    public string QcorrectAns { get; set; } = null!;
}
