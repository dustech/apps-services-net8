using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Models;

[Keyless]
[Table("usstates")]
public partial class Usstate
{
    [Column("StateID")]
    public short StateId { get; set; }

    [StringLength(100)]
    public string? StateName { get; set; }

    [StringLength(2)]
    public string? StateAbbr { get; set; }

    [StringLength(50)]
    public string? StateRegion { get; set; }
}
