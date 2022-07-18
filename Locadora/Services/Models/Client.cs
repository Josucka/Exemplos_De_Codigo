using Locadora.Dados;
using System;
using System.Collections.Generic;

namespace Locadora.Services.Models
{
    public class Client
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public Address Endereco { get; set; }
        public Boolean Premium { get; set; }
        public List<Movies> Filmes { get; set; }

        public Client(string nome, string cpf, Address endereco, Boolean premium)
        {
            Name = nome;
            Cpf = cpf;
            Endereco = endereco;
            Premium = premium;
            Filmes = new List<Movies>();
        }

        public override string ToString()
        {
            string texto = $"Nome: {Name}";
            texto += $"CPF: {Cpf}";
            texto += $"Endereço: {Endereco.ToString()}";
            texto += $"Premium: {Premium}";
            texto += $"Filmes alugados: {Filmes.Count}";
            return texto;
        }

        public void Alugar(Client client, Movies filme)
        {
            if (!Filmes.Contains(filme))
            {
                Invoice nota = new Invoice(client, filme, 3, "Dinheiro");
                InvoiceDados.Instance.Salvar(nota);
                Filmes.Add(filme);
            }
            else
            {
                Console.WriteLine("Filme indisponivel");
            }
        }

        public void Devolver(Client client, Movies filme)
        {
            if (Filmes.Contains(filme))
            {
                Filmes.Remove(filme);
            }
            else
            {
                Console.WriteLine("Filme nao consta!");
            }
        }
    }
}
