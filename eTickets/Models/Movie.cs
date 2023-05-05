using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eTickets.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Models;

public partial class Movie
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string TitleMovies { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public double Price { get; set; }

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public MoviesCategory MoviesCategory { get; set; }

    public int CinemaId { get; set; }

    public int ProducerId { get; set; }

    [ForeignKey("CinemaId")]
    [InverseProperty("Movies")]
    public virtual Cinema Cinema { get; set; } = null!;

    [ForeignKey("ProducerId")]
    [InverseProperty("Movies")]
    public virtual Producer Producer { get; set; } = null!;
}
