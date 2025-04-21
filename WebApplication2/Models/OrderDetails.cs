using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class OrderDetails
{
    [Column("OrderID")]
    public int OrderId { get; set; }

    [Column("ProductID")]
    public int ProductId { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal UnitPrice { get; set; }

    [Key]
    public int OrderDetailsId { get; set; }

    [Column("DiscountID")]
    public int? DiscountId { get; set; }

    [ForeignKey("DiscountId")]
    [InverseProperty("OrderDetails")]
    public virtual Discounts? Discount { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderDetails")]
    public virtual Orders Order { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("OrderDetails")]
    public virtual Products Product { get; set; } = null!;
}
