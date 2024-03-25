using Microsoft.AspNetCore.Mvc;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/v2/telefone")]
    public class TelefoneController : ControllerBase
    {
        private readonly ITelefoneRepository _telefoneRepository;

        public TelefoneController(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }

        [HttpGet]
        public IActionResult GetTelefones()
        {
            var telefone = _telefoneRepository.Get();
            return Ok(telefone);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Telefone telefone)
        {
            var consultaTelefone = _telefoneRepository.GetById(id);
            if (consultaTelefone == null)
            {
                return NotFound();
            }
            else
            {
                _telefoneRepository.Update(telefone);
                return Ok();
            }
            

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _telefoneRepository.Delete(id);
            return Ok();

        }

    }
}
