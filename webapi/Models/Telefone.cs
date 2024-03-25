namespace webapi.Models
{
    public class Telefone
    {
        public int TelefoneId {  get; set; }
        public string? NumeroTelefone { get; set; }
        public string? Tipo {  get; set; }

        public Telefone()
        {

        }
        public Telefone(string numeroTelefone, string tipo)
        {
           
            NumeroTelefone = numeroTelefone;
            Tipo = tipo;
        }

    }
}