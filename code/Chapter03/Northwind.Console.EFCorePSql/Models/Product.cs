using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Models;

[Table("products")]
public partial class Product
{
    [Key]
    [Column("ProductID")]
    public short ProductId { get; set; }

    [StringLength(40)]
    public string ProductName { get; set; } = null!;

    [Column("SupplierID")]
    public short? SupplierId { get; set; }

    [Column("CategoryID")]
    public short? CategoryId { get; set; }

    [StringLength(20)]
    public string? QuantityPerUnit { get; set; }

    public float? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public short? UnitsOnOrder { get; set; }

    public short? ReorderLevel { get; set; }

    public int Discontinued { get; set; }
}
