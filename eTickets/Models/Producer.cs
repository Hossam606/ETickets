using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Models;

public partial class Producer
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string ProducerName { get; set; } = null!;

    public string PictureUrl { get; set; } = null!;

    public string? Bio { get; set; }

    [InverseProperty("Producer")]
    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();

    [ForeignKey("ProducerId")]
    [InverseProperty("Producers")]
    public virtual ICollection<Actor> Actors { get; set; } = new List<Actor>();
}
