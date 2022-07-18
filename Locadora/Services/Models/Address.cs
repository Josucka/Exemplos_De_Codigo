namespace Locadora.Services.Models
{
    public class Address
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string City { get; set; }

        public Address(string logradouro, int numero, string cep, string bairro, string city)
        {
            Logradouro = logradouro;
            Numero = numero;
            Cep = cep;
            Bairro = bairro;
            City = city;
        }

        public override string ToString()
        {
            string texto = $"{Logradouro} Nº{Numero}";
            texto += $"CEP: {Cep} - {Bairro}, {City}";
            return texto;
        }
    }
}
