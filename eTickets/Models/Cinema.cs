using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Models;

public partial class Cinema
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CinemaName { get; set; } = null!;

    [Unicode(false)]
    public string PictureUrl { get; set; } = null!;

    [Unicode(false)]
    public string? Description { get; set; }

    [InverseProperty("Cinema")]
    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
