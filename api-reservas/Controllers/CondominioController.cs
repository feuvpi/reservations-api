using api_reservas.Core.Models;
using api_reservas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api_reservas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CondominioController : ControllerBase
    {
        private readonly CondominioService _condominioService;
        public CondominioController(CondominioService condominioService) => _condominioService = condominioService;

        [HttpGet]
        public async Task<List<Condominio>> Get() => await _condominioService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Condominio>> Get(string id)
        {
            var book = await _condominioService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Condominio condominio)
        {
            await _condominioService.CreateAsync(condominio);

            return NoContent();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Condominio updatedCondominio)
        {
            var book = await _condominioService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedCondominio.Id = book.Id;

            await _condominioService.UpdateAsync(id, updatedCondominio);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var condomino = await _condominioService.GetAsync(id);

            if (condomino is null)
            {
                return NotFound();
            }

            await _condominioService.RemoveAsync(id);

            return NoContent();
        }

    }
}
