using Locadora.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Dados
{
    public class ClientDados
    {
        public List<Client> clients;

        private static readonly ClientDados instance = new ClientDados();

        static ClientDados()
        {

        }
        public ClientDados()
        {
            clients = new List<Client>();
        }

        public static ClientDados Instance
        {
            get { return instance; }
        }

        //Methodo salvar
        public Boolean Salvar(Client client)
        {
            if (!clients.Contains(client))
                clients.Add(client);
            return true;

            //return false;
        }

        //Methodo buscar
        public Client Buscar(string cpf)
        {
            foreach (Client client in clients)
                if (client.Cpf.Equals(cpf))
                    return client;

            return null;
        }

        //Methodo listar
        public List<Client> Listar()
        {
            return clients;
        }

        //Methodo remover
        public Boolean Remover(Client client)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients.Contains(client))
                {
                    if (clients.ElementAt(i).Filmes.Count == 0)
                    {
                        clients.RemoveAt(i);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        //Methodo editar
        public void Editar(Client client, string name, Address endereco, Boolean premium)
        {
            foreach (Client c in clients)
                if (c.Cpf.Equals(client.Cpf))
                {
                    c.Name = name;
                    c.Endereco = endereco;
                    c.Premium = premium;
                }
        }

        //Pesquisar usando LINQ
        public Client Pesquisar(string cpf)
        {

            IEnumerable<Client> query = from Client client in clients
                                        where client.Cpf == cpf
                                        select client;

            foreach (Client client in query)
            {
                return client;
            }

            return null;
        }
    }
}
