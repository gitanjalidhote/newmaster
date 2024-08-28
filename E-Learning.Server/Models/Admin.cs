using System;
using System.Collections.Generic;

namespace E_Learning.Server.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string AdminName { get; set; } = null!;

    public string AdminPass { get; set; } = null!;
}
