using System;

namespace Locadora.Services.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public DateTime Lancamento { get; set; }
        public double Preco { get; set; }
        public string Genero { get; set; }
        public string Sinopse { get; set; }

        public Movies(string name, string director, DateTime lancamento, double preco, string genero, string sinopse)
        {
            Random rand = new Random();
            Id = rand.Next(1000, 100000);
            Name = name;
            Director = director;
            Lancamento = lancamento;
            Preco = preco;
            Genero = genero;
            Sinopse = sinopse;
        }

        public override string ToString()
        {
            string texto = "--------";
            texto += $"Id: {Id}";
            texto += $"Nome: {Name}";
            texto += $"Director: {Director}";
            texto += $"Lançamento: {Lancamento}";
            texto += $"Preço: {Preco}";
            texto += $"Genero: {Genero}";
            texto += $"Sinopse: {Sinopse}";
            return texto;
        }
    }
}
