using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiShopmenager.Models;

public partial class Reviews
{
    [Key]
    [Column("ReviewID")]
    public int ReviewId { get; set; }

    [Column("EmployeeID")]
    public int EmployeeID { get; set; }

    [Column("ProductID")]
    public int ProductId { get; set; }

    public int Rating { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Comments { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ReviewDate { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Reviews")]
    public virtual Employees Employee { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("Reviews")]
    public virtual Products Product { get; set; } = null!;
}
