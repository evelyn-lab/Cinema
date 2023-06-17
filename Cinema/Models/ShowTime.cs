namespace Cinema.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("show_time")]
public class ShowTime
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("movie_name")]
    public string MovieName { get; set; }
    [Column("date")]
    public DateTime Date { get; set; }
}   