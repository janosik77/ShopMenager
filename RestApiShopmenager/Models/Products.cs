using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiShopmenager.Models;

public partial class Products
{
    [Key]
    [Column("ProductID")]
    public int ProductID { get; set; }

    [Column("CategoryID")]
    public int CategoryID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string ProductName { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    public int Stock { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Description { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? PhotoPath { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Categories Category { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

    [InverseProperty("Product")]
    public virtual ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
}
