using System;
using System.Collections.Generic;

namespace Examen_AlvaroReyes.DB.Examen.Entities;

public partial class TblUser
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public bool UserDelete { get; set; }

    public bool UserActive { get; set; }

    public DateTime UserCreatedAt { get; set; }

    public DateTime? UserUpdatedAt { get; set; }
}
