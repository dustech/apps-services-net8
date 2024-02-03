using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Models;

[Table("customerdemographics")]
public partial class Customerdemographic
{
    [Key]
    [Column("CustomerTypeID", TypeName = "char")]
    public char CustomerTypeId { get; set; }

    public string? CustomerDesc { get; set; }
}
