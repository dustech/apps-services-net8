using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Models;

[PrimaryKey("EmployeeId", "TerritoryId")]
[Table("employeeterritories")]
public partial class Employeeterritory
{
    [Key]
    [Column("EmployeeID")]
    public short EmployeeId { get; set; }

    [Key]
    [Column("TerritoryID")]
    [StringLength(20)]
    public string TerritoryId { get; set; } = null!;
}
