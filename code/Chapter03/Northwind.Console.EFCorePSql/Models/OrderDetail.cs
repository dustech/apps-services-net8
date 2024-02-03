using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Models;

[PrimaryKey("OrderId", "ProductId")]
[Table("order_details")]
public partial class OrderDetail
{
    [Key]
    [Column("OrderID")]
    public short OrderId { get; set; }

    [Key]
    [Column("ProductID")]
    public short ProductId { get; set; }

    public float UnitPrice { get; set; }

    public short Quantity { get; set; }

    public float Discount { get; set; }
}
