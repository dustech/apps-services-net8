using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Models;

[PrimaryKey("CustomerId", "CustomerTypeId")]
[Table("customercustomerdemo")]
public partial class Customercustomerdemo
{
    [Key]
    [Column("CustomerID", TypeName = "char")]
    public char CustomerId { get; set; }

    [Key]
    [Column("CustomerTypeID", TypeName = "char")]
    public char CustomerTypeId { get; set; }
}
