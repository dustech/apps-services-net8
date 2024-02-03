using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Models;

[Table("employees")]
public partial class Employee
{
    [Key]
    [Column("EmployeeID")]
    public short EmployeeId { get; set; }

    [StringLength(20)]
    public string LastName { get; set; } = null!;

    [StringLength(10)]
    public string FirstName { get; set; } = null!;

    [StringLength(30)]
    public string? Title { get; set; }

    [StringLength(25)]
    public string? TitleOfCourtesy { get; set; }

    public DateOnly? BirthDate { get; set; }

    public DateOnly? HireDate { get; set; }

    [StringLength(60)]
    public string? Address { get; set; }

    [StringLength(15)]
    public string? City { get; set; }

    [StringLength(15)]
    public string? Region { get; set; }

    [StringLength(10)]
    public string? PostalCode { get; set; }

    [StringLength(15)]
    public string? Country { get; set; }

    [StringLength(24)]
    public string? HomePhone { get; set; }

    [StringLength(4)]
    public string? Extension { get; set; }

    public byte[]? Photo { get; set; }

    public string? Notes { get; set; }

    public short? ReportsTo { get; set; }

    [StringLength(255)]
    public string? PhotoPath { get; set; }
}
