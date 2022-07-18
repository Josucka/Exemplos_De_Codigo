using Locadora.Services.Models;
using System;
using System.Collections.Generic;

namespace Locadora.Services
{
    public class Fachada
    {
        private readonly ControllerClient controlladorClient;
        private readonly ControllerMovie controlladorFilme;
        private readonly ControllerInvoice controlladorNota;
        private static readonly Fachada instance = new Fachada();

        static Fachada() { }
        public static Fachada Instance { get { return instance; } }
        public Fachada()
        {
            controlladorClient = ControllerClient.Instance;
            controlladorFilme = ControllerMovie.Instance;
            controlladorNota = ControllerInvoice.Instance;
        }

        //Cliente
        public Boolean SalvarClient(Client client)
        {
            return controlladorClient.Salvar(client);
        }

        public List<Client> ListarClient()
        {
            return controlladorClient.Listar();
        }

        public Client BuscarClient(string cpf)
        {
            return controlladorClient.Buscar(cpf);
        }

        public Client PesquisarClient(string cpf)
        {
            return controlladorClient.Pesquisar(cpf);
        }

        public Boolean RemoverClient(Client client)
        {
            return controlladorClient.Remover(client);
        }

        public void EditarClient(Client client, string name, Address address, Boolean premium)
        {
            controlladorClient.Editar(client, name, address, premium);
        }

        //Filme
        public Boolean SalvarFilme(Movies movie)
        {
            return controlladorFilme.Salvar(movie);
        }

        public string ListarFilme()
        {
            return controlladorFilme.Listar();
        }

        public Movies BuscarFilme(string titulo)
        {
            return controlladorFilme.Buscar(titulo);
        }

        public void RemoverFilme(Movies filme)
        {
            controlladorFilme.Remover(filme);
        }

        public void EditarFilme(Movies filme, string name, string director, DateTime lancamento, double preco, string genero, string sinopse)
        {
            controlladorFilme.Editar(filme, name, director, lancamento, genero, preco, sinopse);
        }

        //NF
        public Boolean SalvarNota(Invoice nota)
        {
            return controlladorNota.Salvar(nota);
        }

        public List<Invoice> ListarNotaFilcal()
        {
            return controlladorNota.Listar();
        }

        public Invoice BuscarNotaFiscal(int id)
        {
            return controlladorNota.Buscar(id);
        }

        public void RemoverNotaFiscal(Invoice nota)
        {
            controlladorNota.Remove(nota);
        }

        public void EditarNotaFiscal(Invoice notaFiscal, int nDias, string formPagamento)
        {
            controlladorNota.Editar(notaFiscal, nDias, formPagamento);
        }
    }
}
