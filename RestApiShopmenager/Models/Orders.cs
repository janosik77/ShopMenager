using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiShopmenager.Models;

public partial class Orders
{
    [Key]
    [Column("OrderID")]
    public int OrderId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OrderDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [ForeignKey("CustomerId")]
    [InverseProperty("Orders")]
    public virtual Customers Customer { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("Orders")]
    public virtual Employees Employee { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

    [InverseProperty("Order")]
    public virtual ICollection<Payments> Payments { get; set; } = new List<Payments>();
}
