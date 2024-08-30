using System;
using System.Collections.Generic;

namespace E_Learning.Server.Models;

public partial class Student
{
    public int StdId { get; set; }

    public string StdName { get; set; } = null!;

    public string StdPass { get; set; } = null!;

    //public virtual ICollection<SetExam> SetExams { get; set; } = new List<SetExam>();
}
