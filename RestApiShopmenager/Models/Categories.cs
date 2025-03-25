using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiShopmenager.Models;

public partial class Categories
{
    [Key]
    [Column("CategoryID")]
    public int CategoryID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string CategoryName { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? CategoryDescription { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Products> Products { get; set; } = new List<Products>();
}
