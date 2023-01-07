using System;
using System.Collections.Generic;

namespace taskmanagerAPI.Models;

public partial class BlTask
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Prority { get; set; }

    public string? UserId { get; set; }

    public DateTime? Date { get; set; }
}
