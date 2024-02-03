using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Models;

[Table("territories")]
public partial class Territory
{
    [Key]
    [Column("TerritoryID")]
    [StringLength(20)]
    public string TerritoryId { get; set; } = null!;

    [Column(TypeName = "char")]
    public char TerritoryDescription { get; set; }

    [Column("RegionID")]
    public short RegionId { get; set; }
}
