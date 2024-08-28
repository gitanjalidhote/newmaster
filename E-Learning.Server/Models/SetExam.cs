using System;
using System.Collections.Generic;

namespace E_Learning.Server.Models;

public partial class SetExam
{
    public int ExamId { get; set; }

    public DateTime? ExamDate { get; set; }

    public int? ExamFkStd { get; set; }

    public string ExamName { get; set; } = null!;

    public int? StdScore { get; set; }

    public virtual Student? ExamFkStdNavigation { get; set; }
}
