using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class PaymentMethods
{
    [Key]
    [Column("PaymentMethodID")]
    public int PaymentMethodId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string MethodName { get; set; } = null!;

    [InverseProperty("PaymentMethod")]
    public virtual ICollection<Payments> Payments { get; set; } = new List<Payments>();
}
