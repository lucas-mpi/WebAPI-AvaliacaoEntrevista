using Microsoft.AspNetCore.Mvc;
using webapi.Interfaces;
using webapi.Models;
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
            _pessoaRepository = pessoaRepository;
            
        }

        [HttpPost]
        public IActionResult Add(PessoaTelefoneViewModel pessoaTelefoneViewModel)
        {

            var pessoa = new Pessoa(
                pessoaTelefoneViewModel.Pessoa.Nome,
                pessoaTelefoneViewModel.Pessoa.Cpf,
                pessoaTelefoneViewModel.Pessoa.DataNascimento
                
             );
           
           var telefones = new List<Telefone>();

            foreach (var telefoneViewModel in pessoaTelefoneViewModel.Telefones)
            {
                var telefone = new Telefone
                {
                    NumeroTelefone = telefoneViewModel.NumeroTelefone,
                    Tipo = telefoneViewModel.Tipo
                };
                telefones.Add(telefone);
            }

            pessoa.Telefones = telefones;

            _pessoaRepository.Add(pessoa);
           

            return Created();
        }

        
        [HttpGet]
        public IActionResult GetPessoaTelefone()
        {
            var pessoa = _pessoaRepository.GetPessoasWithTelefone();
            if (pessoa == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(pessoa);
            }
            

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var consultaPessoa = _pessoaRepository.GetById(id);
            if (consultaPessoa == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(consultaPessoa);
            }
             
        }


        
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pessoa pessoa)
        {

            var consultaPessoa = _pessoaRepository.GetById(id);

            if (consultaPessoa == null)
            {
                return NotFound();
            }
            else
            {
                _pessoaRepository.Update(pessoa);
                return Ok();
            }
            

        }
        




        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var consultaPessoa = _pessoaRepository.GetById(id);
            if (consultaPessoa == null)
            {
                return NotFound();
            }
            else
            {
                _pessoaRepository.Delete(id);
                return Ok();
            }
           
            
            
        }
    }

}
