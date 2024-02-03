using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Models;

[Table("region")]
public partial class Region
{
    [Key]
    [Column("RegionID")]
    public short RegionId { get; set; }

    [Column(TypeName = "char")]
    public char RegionDescription { get; set; }
}
