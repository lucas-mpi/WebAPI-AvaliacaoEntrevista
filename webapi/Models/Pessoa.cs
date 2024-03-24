namespace webapi.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public bool Situacao { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? DataNascimento{ get; set; }

        public Pessoa()
        {

        }
        public Pessoa(string nome, string cpf, string dataNascimento)
        {
            this.Nome = nome ?? throw new ArgumentException(nameof(nome));
            this.Cpf = cpf ?? throw new ArgumentException(nameof(cpf));
            this.DataNascimento = dataNascimento ?? throw new ArgumentException(nameof(dataNascimento));

        }
    }
}
