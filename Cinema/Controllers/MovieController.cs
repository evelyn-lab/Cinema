using Cinema.Context;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers;
// Атрибут указывает маршрут, по которому будет доступен контроллер.
[Route("api/[controller]")]
// Атрибут указывает, что данный контроллер является контроллером API
[ApiController]
public class MovieController : ControllerBase
{
    private readonly DataContext _context;
    public MovieController(DataContext context)
    {
        _context = context;
    }
    //  Атрибут, указывающий, что метод обрабатывает GET-запросы
    [HttpGet]
    public IActionResult GetMovies()
    {
        if (_context.Movie == null)
        {
            // Возвращается ошибка 404 и сообщение "DataBase empty"
            return NotFound("DataBase empty");
        }
        string text = "";
        foreach (var movie in _context.Movie)
        {
            text += "Name: " + movie.Name + "\n";
            text += "Genre: " + movie.Genre + "\n";
            text += "Duration: " + movie.Duration + "minutes\n";
            text += "Rating: " + movie.Rating + "\n\n";
        }
        // Возвращается ответ с успешным кодом 200 и текстом, содержащим информацию о фильмах
        return Ok(text);
    }
    
    [HttpPost]
    // Метод, создающий новый фильм на основе переданных данных
    public async Task<ActionResult<Movie>> PostMovie(MovieInput input)
    {
        Movie movie = new Movie
        {
            Name = input.Name,
            Genre = input.Genre,
            Duration = input.Duration,
            Rating = input.Rating
        };
        _context.Movie?.Add(movie);
        await _context.SaveChangesAsync();
        return Ok("Created");
    }
}