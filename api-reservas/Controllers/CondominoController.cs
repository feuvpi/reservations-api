using api_reservas.Core.Dtos;
using api_reservas.Core.Models;
using api_reservas.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api_reservas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CondominoController : ControllerBase
    {
        private readonly CondominoService _condominoService;
        public CondominoController(CondominoService condominoService) => _condominoService = condominoService;

        [HttpGet]
        //public async Task<List<GetCondominoDTO>> Get() => await _condominoService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Condominio>> Get(string id)
        {
            var book = await _condominoService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Condomino condomino)
        {
            await _condominoService.CreateAsync(condomino);

            return NoContent();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Condomino updatedCondomino)
        {
            var book = await _condominoService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedCondomino.Id = book.Id;

            await _condominoService.UpdateAsync(id, updatedCondomino);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var condomino = await _condominoService.GetAsync(id);

            if (condomino is null)
            {
                return NotFound();
            }

            await _condominoService.RemoveAsync(id);

            return NoContent();
        }

    }
}
