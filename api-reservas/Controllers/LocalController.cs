using api_reservas.Core.Models;
using api_reservas.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_reservas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalController : ControllerBase
    {
        private readonly LocalService _localService;
        public LocalController(LocalService localService) => _localService = localService;

        [HttpGet]
        public async Task<List<Local>> Get() => await _localService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Local>> Get(string id)
        {
            var local = await _localService.GetAsync(id);

            if (local is null)
            {
                return NotFound();
            }

            return local;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Local local)
        {
            await _localService.CreateAsync(local);

            return NoContent();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Local updatedLocal)
        {
            var book = await _localService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedLocal.Id = book.Id;

            await _localService.UpdateAsync(id, updatedLocal);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var local = await _localService.GetAsync(id);

            if (local is null)
            {
                return NotFound();
            }

            await _localService.RemoveAsync(id);

            return NoContent();
        }

    }
}
