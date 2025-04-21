using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class Employees
{
    [Key]
    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Phone { get; set; }

    public DateOnly? HireDate { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Salary { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? PhotoPath { get; set; }

    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    [InverseProperty("Employee")]
    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();

    [InverseProperty("Employee")]
    public virtual ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
}
