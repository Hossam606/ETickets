using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Models;

public partial class Actor
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ActorName { get; set; } = null!;

    [Unicode(false)]
    public string PictureUrl { get; set; } = null!;

    [Unicode(false)]
    public string? Bio { get; set; }

    [ForeignKey("ActorId")]
    [InverseProperty("Actors")]
    public virtual ICollection<Producer> Producers { get; set; } = new List<Producer>();
}
