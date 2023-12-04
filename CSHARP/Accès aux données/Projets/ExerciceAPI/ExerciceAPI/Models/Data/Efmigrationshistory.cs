using System;
using System.Collections.Generic;

namespace ExerciceAPI.Models.Data;

public partial class Efmigrationshistory
{
    public string MigrationId { get; set; } = null!;

    public string ProductVersion { get; set; } = null!;
}
