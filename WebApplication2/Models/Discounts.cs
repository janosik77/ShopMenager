using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class Discounts
{
    [Key]
    [Column("DiscountID")]
    public int DiscountId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string DiscountName { get; set; } = null!;

    [Column(TypeName = "decimal(5, 2)")]
    public decimal DiscountRate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [InverseProperty("Discount")]
    public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
}
