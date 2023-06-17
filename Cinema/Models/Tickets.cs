namespace Cinema.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("tickets")]
public class Tickets
{
    [Key]
    [Column("movie_id")]
    public int Id { get; set; }
    [Column("quantity")]
    public int Quantity { get; set; }
}