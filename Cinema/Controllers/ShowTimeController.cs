using Cinema.Context;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers;

// Атрибут указывает маршрут, по которому будет доступен контроллер.
[Route("api/[controller]")]
// Атрибут указывает, что данный контроллер является контроллером API
[ApiController]
public class ShowTimeController : ControllerBase
{
    private readonly DataContext _context;
    public ShowTimeController(DataContext context)
    {
        _context = context;
    }
    //  Атрибут, указывающий, что метод обрабатывает GET-запросы
    [HttpGet]
    public IActionResult GetShowTimes()
    {
        if (_context.ShowTime == null)
        {
            // Возвращается ошибка 404 и сообщение "DataBase empty"
            return NotFound("DataBase empty");
        }
        string text = "";
        foreach (var st in _context.ShowTime)
        {
            text += "Movie name: " + st.MovieName + "\n";
            text += "Date: " + st.Date + "\n\n";
        }
        // Возвращается ответ с успешным кодом 200 и текстом, содержащим информацию о сеансах
        return Ok(text);
    }
    
    [HttpPost]
    // Метод, создающий новый сеанс на основе переданных данных
    public async Task<ActionResult<Movie>> PostShowTime(ShowTimeInput input)
    {
        if (_context.Movie != null)
        {
            var movie = _context.Movie.FirstOrDefault(m => m.Name == input.MovieName);
            if (movie == null)
            {
                return NotFound("Movie doesn't exist.");
            }
        }
        else
        {
            return BadRequest("Movie list is empty.");
        }

        ShowTime showTime = new ShowTime
        {
            MovieName = input.MovieName,
            Date = DateTime.Now
        };
        _context.ShowTime?.Add(showTime);
        await _context.SaveChangesAsync();
        return Ok("Created");
    }
}