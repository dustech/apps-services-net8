using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Models;

[Table("categories")]
public partial class Category
{
    [Key]
    [Column("CategoryID")]
    public short CategoryId { get; set; }

    [StringLength(15)]
    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }
}
