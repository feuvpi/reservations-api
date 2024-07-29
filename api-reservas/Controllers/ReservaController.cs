using api_reservas.Core.Models;
using api_reservas.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_reservas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly ReservaService _reservaService;
        public ReservaController(ReservaService reservaService) => _reservaService = reservaService;

        [HttpGet]
        public async Task<List<Reserva>> Get() => await _reservaService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Reserva>> Get(string id)
        {
            var reserva = await _reservaService.GetAsync(id);

            if (reserva is null)
            {
                return NotFound();
            }

            return reserva;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Reserva local)
        {
            await _reservaService.CreateAsync(local);

            return NoContent();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Reserva updatedLocal)
        {
            var book = await _reservaService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedLocal.Id = book.Id;

            await _reservaService.UpdateAsync(id, updatedLocal);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var local = await _reservaService.GetAsync(id);

            if (local is null)
            {
                return NotFound();
            }

            await _reservaService.RemoveAsync(id);

            return NoContent();
        }

    }
}
