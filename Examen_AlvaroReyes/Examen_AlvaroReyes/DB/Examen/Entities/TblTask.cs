using System;
using System.Collections.Generic;

namespace Examen_AlvaroReyes.DB.Examen.Entities;

public partial class TblTask
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public string TaskDescription { get; set; } = null!;

    public bool TaskDelete { get; set; }

    public bool TaskActive { get; set; }

    public DateTime TaskCreatedAt { get; set; }

    public DateTime? TaskUpdatedAt { get; set; }
}
