using Cinema.Context;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers;

// Атрибут указывает маршрут, по которому будет доступен контроллер.
[Route("api/[controller]")]
// Атрибут указывает, что данный контроллер является контроллером API
[ApiController]
public class TicketsController : Controller
{
    private readonly DataContext _context;
    public TicketsController(DataContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    // Метод, осуществляющий бронирование мест и покупку билетов на основе переданных данных
    public async Task<ActionResult<Tickets>> PostShowTime(TicketsInput input)
    {
        if (_context.ShowTime != null)
        {
            var showTime = _context.ShowTime.FirstOrDefault(m => m.Id == input.Id);
            if (showTime  == null)
            {
                return NotFound("ShowTime doesn't exist.");
            }
        }
        else
        {
            return BadRequest("ShowTime list is empty.");
        }
        Tickets ticket= new Tickets
        {
            Id = input.Id,
            Quantity = input.Quantity
        };
        _context.Tickets?.Add(ticket);
        await _context.SaveChangesAsync();
        return Ok("Created");
    }
}
