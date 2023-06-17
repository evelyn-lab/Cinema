namespace Cinema.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("movie")]
public class Movie
{
    [Key]
    [Column("name")]
    public string? Name { get; set; }
    [Column("genre")]
    public string? Genre { get; set; }
    [Column("duration")]
    public int? Duration { get; set; }
    [Column("rating")]
    public double? Rating { get; set; }
}