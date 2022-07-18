using Locadora.Dados;
using Locadora.Services.Models;
using System;
using System.Collections.Generic;

namespace Locadora.Services
{
    public class ControllerClient
    {
        private ClientDados _client;

        private static readonly ControllerClient instance = new ControllerClient();

        static ControllerClient()
        {

        }

        public ControllerClient()
        {
            _client = ClientDados.Instance;
        }

        public static ControllerClient Instance
        {
            get { return instance; }
        }

        public Boolean Salvar(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _client.Salvar(client);
                return true;
            }
        }

        public Client Buscar(string cpf)
        {
            if (cpf == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return _client.Buscar(cpf);
            }
        }

        public Client Pesquisar(string cpf)
        {
            if (cpf == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return _client.Pesquisar(cpf);
            }
        }

        public List<Client> Listar()
        {
            return _client.Listar();
        }

        public Boolean Remover(Client client)
        {
            if (client == null)
            {
                return false;
            }
            else
            {
                _client.Remover(client);
                return true;
            }
        }

        public void Editar(Client client, string name, Address address, Boolean premium)
        {
            if (client == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _client.Editar(client, name, address, premium);
            }
        }
    }

}
