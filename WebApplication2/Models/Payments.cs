using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class Payments
{
    [Key]
    [Column("PaymentID")]
    public int PaymentId { get; set; }

    [Column("OrderID")]
    public int OrderId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime PaymentDate { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Amount { get; set; }

    [Column("PaymentMethodID")]
    public int PaymentMethodId { get; set; }

    [Column("PaymentStatusID")]
    public int PaymentStatusId { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("Payments")]
    public virtual Orders Order { get; set; } = null!;

    [ForeignKey("PaymentMethodId")]
    [InverseProperty("Payments")]
    public virtual PaymentMethods PaymentMethod { get; set; } = null!;

    [ForeignKey("PaymentStatusId")]
    [InverseProperty("Payments")]
    public virtual PaymentStatuses PaymentStatus { get; set; } = null!;
}
