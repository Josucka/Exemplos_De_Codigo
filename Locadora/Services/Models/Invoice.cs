using System;

namespace Locadora.Services.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Movies Filme { get; set; }
        public double NumeroDias { get; set; }
        public string FormaPagamento { get; set; }
        public double ValorFinal { get; set; }

        public Invoice(Client client, Movies filme, double nDias, string formPagamento)
        {
            Random rand = new Random();
            Id = rand.Next(1000, 1000000);
            Client = client;
            Filme = filme;
            NumeroDias = nDias;
            FormaPagamento = formPagamento;

            if (Client.Premium)
                ValorFinal = (nDias * filme.Preco - (filme.Preco * 0.2));
            else
                ValorFinal = (nDias * filme.Preco);
        }

        public override string ToString()
        {
            string texto = $"ID: {Id}";
            texto += $"Filme: {Filme.Name}";
            texto += $"Cliente: {Client.Name}";
            texto += $"CPF: {Client.Cpf}";
            texto += $"Quant Dias: {NumeroDias}";
            texto += $"Valor a Pagar: {ValorFinal}";
            return texto;
        }
    }
}
