using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Repository;
using webapi.ViewModel;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/v1/pessoa")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository ?? throw new ArgumentNullException(nameof(pessoaRepository));
        }

        [HttpPost]
        public IActionResult Add(PessoaViewModel pessoaView)
        {
            var pessoa = new Pessoa(pessoaView.Nome, pessoaView.Cpf, pessoaView.DataNascimento);
            _pessoaRepository.Add(pessoa);

            return Ok();
        }


        [HttpGet]
        public IActionResult Get()
        {
            var pessoa = _pessoaRepository.Get();
            return Ok(pessoa);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var consultaPessoa = _pessoaRepository.GetById(id);
            return Ok(consultaPessoa);  
        }


        
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pessoa pessoa)
        {
            var consultaPessoa = _pessoaRepository.GetById(id);

            _pessoaRepository.Update(pessoa);
            return Ok();

        }
        



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pessoaRepository.Delete(id);
            return Ok();
        }
    }

}
