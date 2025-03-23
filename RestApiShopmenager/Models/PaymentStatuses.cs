using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiShopmenager.Models;

public partial class PaymentStatuses
{
    [Key]
    [Column("PaymentStatusID")]
    public int PaymentStatusId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string StatusName { get; set; } = null!;

    [InverseProperty("PaymentStatus")]
    public virtual ICollection<Payments> Payments { get; set; } = new List<Payments>();
}
