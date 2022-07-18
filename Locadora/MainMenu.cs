using Locadora.Services;
using Locadora.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora
{
    public class MainMenu
    {
        public void Menu()
        {
            Console.Clear();

            Console.WriteLine("---Locadora---");
            Console.WriteLine(
                "1 - Adicionar cliente\n" +
                "2 - Buscar cliente\n" +
                "3 - Editar cliente\n" +
                "4 - Remover cliente\n" +
                "5 - Adicionar cliente\n" +
                "6 - Buscar filme\n" +
                "7 - Editar filme\n" +
                "8 - Remover filme\n" +
                "9 - Registrar aluguel\n" +
                "10 - Registrar devoluçao\n" +
                "11 - Sair"
                );

            Console.WriteLine("Escolha uma opçao: ");
            int operacao = int.Parse(Console.ReadLine());
            do
            {
                switch (operacao)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Insira o nome: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Insira o CPF: ");
                        string cpf = Console.ReadLine();
                        Console.WriteLine("Dados do Endereço: ");
                        Console.WriteLine("Logradouro: ");
                        string logradouro = Console.ReadLine();
                        Console.WriteLine("Numero: ");
                        int numero = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("CEP: ");
                        string cep = Console.ReadLine();
                        Console.WriteLine("Bairro: ");
                        string bairro = Console.ReadLine();
                        Console.WriteLine("Cidade: ");
                        string city = Console.ReadLine();

                        Address endereco = new Address(logradouro, numero, cep, bairro, city);
                        int status = 0;
                        while (status != 1 && status != 2)
                        {
                            Console.WriteLine("Cliente PREMIUM 1 - sim | 2 - não: ");
                            status = Convert.ToInt32(Console.ReadLine());
                            Boolean premium;
                            if (status == 1)
                            {
                                premium = true;
                                Client clien = new Client(nome, cpf, endereco, premium);
                                Fachada.Instance.SalvarClient(clien);

                                Console.Clear();
                                Console.WriteLine("Cliente Adicionado com sucesso!");
                                Console.WriteLine(clien.ToString());

                                Console.ReadLine();
                            }
                            else if (status == 2)
                            {
                                premium = false;
                                Client clien = new Client(nome, cpf, endereco, premium);
                                Fachada.Instance.SalvarClient(clien);

                                Console.Clear();
                                Console.WriteLine("Cliente Adicionado com sucesso!");
                                Console.WriteLine(clien.ToString());

                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Opçao invalida!");
                            }
                        }
                        Menu();
                        break;

                    case 2:
                        Console.Clear();

                        Console.WriteLine("Insira o cpf no cliente: ");
                        string busca = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine(Fachada.Instance.BuscarClient(busca));

                        Console.ReadLine();
                        Menu();
                        break;

                    case 3:
                        Console.Clear();

                        Console.WriteLine("Insira o cepf do client: ");
                        string pesquisa = Console.ReadLine();

                        Console.Clear();
                        Client cli = Fachada.Instance.BuscarClient(pesquisa);
                        Console.WriteLine(cli.ToString());

                        Console.WriteLine("Insira o novo cliente: ");
                        string novoNome = Console.ReadLine();

                        Console.WriteLine("Insira os novos dados: ");
                        Console.WriteLine("Logradouro: ");
                        string novoLogradouro = Console.ReadLine();

                        Console.WriteLine("Numero: ");
                        int novoNumero = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("CEP: ");
                        string novoCep = Console.ReadLine();

                        Console.WriteLine("Bairro: ");
                        string novoBairro = Console.ReadLine();

                        Console.WriteLine("Cidade: ");
                        string novaCity = Console.ReadLine();

                        Address novoEndereco = new Address(novoLogradouro, novoNumero, novoCep, novoBairro, novaCity);

                        int novoStatus = 0;
                        while (novoStatus != 1 && novoStatus != 2)
                        {
                            Console.WriteLine("O cliente sera PREMIUM? 1 - sim | 2 - não");
                            novoStatus = Convert.ToInt32(Console.ReadLine());

                            Boolean premium;
                            if (novoStatus == 1)
                            {
                                premium = true;

                                Fachada.Instance.EditarClient(cli, novoNome, novoEndereco, premium);

                                Console.Clear();
                                Console.WriteLine("Cliente alterado com sucesso!!!");
                                Console.WriteLine(cli.ToString());

                                Console.ReadLine();
                            }
                            else if (novoStatus == 2)
                            {
                                premium = false;

                                Fachada.Instance.EditarClient(cli, novoNome, novoEndereco, premium);
                                Console.WriteLine("Cliente alterado com sucesso!");
                                Console.WriteLine(cli.ToString());

                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Opçao invalida");
                            }
                        }
                        Menu();
                        break;

                    case 4:
                        Console.ReadLine();

                        Console.WriteLine("Insira o cpf do cliente: ");
                        string search = Console.ReadLine();

                        Console.Clear();
                        Client client = Fachada.Instance.BuscarClient(search);
                        Console.WriteLine(client.ToString());

                        int confirmaçao = 0;

                        while (confirmaçao != 1 && confirmaçao != 2)
                        {
                            Console.WriteLine("Deseja remover Cliente? 1 - sim | 2 - não");
                            confirmaçao = Convert.ToInt32(Console.ReadLine());

                            if (confirmaçao == 1)
                            {
                                if (Fachada.Instance.RemoverClient(client))
                                {
                                    Console.WriteLine("Cliente removido com sucesso!!");
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("Nao foi possivel remover o cliente!!");
                                    Console.Clear();
                                }
                            }
                            else if (confirmaçao == 2)
                            {
                                Console.WriteLine("operaçao cancelada!!");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Opçao Invalida!");
                            }
                        }
                        Menu();
                        break;

                    case 5:
                        Console.Clear();

                        Console.WriteLine("Insira o titulo do filme: ");
                        string titulo = Console.ReadLine();

                        Console.WriteLine("Insira o diretor do filme: ");
                        string director = Console.ReadLine();

                        Console.WriteLine("Dia de lançamento do filme: ");
                        int dia = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Mes de lançamento do filme: ");
                        int mes = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Ano de lançamento do filme: ");
                        int ano = Convert.ToInt32(Console.ReadLine());

                        DateTime dataLancamento = new DateTime(ano, mes, dia);

                        Console.WriteLine("Preço: ");
                        double preco = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Genero: ");
                        string genero = Console.ReadLine();

                        Console.WriteLine("Sinopse: ");
                        string sinopse = Console.ReadLine();

                        Movies filme = new Movies(titulo, director, dataLancamento, preco, sinopse, genero);
                        Fachada.Instance.SalvarFilme(filme);

                        Console.Clear();
                        Console.WriteLine("Filme adicionado com sucesso!!!");
                        Console.WriteLine(filme.ToString());

                        Console.ReadLine();
                        Menu();
                        break;

                    case 6:
                        Console.Clear();

                        Console.WriteLine("Insira o titulo do filme: ");
                        string buscarFilme = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine(Fachada.Instance.BuscarFilme(buscarFilme));

                        Console.ReadLine();
                        Menu();
                        break;

                    case 7:
                        Console.Clear();

                        Console.WriteLine("Insira o titulo do filme: ");
                        string filmSearch = Console.ReadLine();

                        Console.Clear();
                        Movies f = Fachada.Instance.BuscarFilme(filmSearch);
                        Console.WriteLine(f.ToString());

                        Console.WriteLine("Insira o novo titulo do filme: ");
                        string novoTitulo = Console.ReadLine();

                        Console.WriteLine("Insira o novo diretor do filme: ");
                        string novoDirector = Console.ReadLine();

                        Console.WriteLine("Novo dia de lançamento: ");
                        int novoDia = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Novo mes de lançamento: ");
                        int novoMes = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Novo Ano de lançamento: ");
                        int novoAno = Convert.ToInt32(Console.ReadLine());

                        DateTime novaDataLancamento = new DateTime(novoAno, novoMes, novoDia);

                        Console.WriteLine("Novo Preço: ");
                        double novoPreco = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Novo genero: ");
                        string novoGenero = Console.ReadLine();

                        Console.WriteLine("Nova sinopse: ");
                        string novaSinopse = Console.ReadLine();

                        Fachada.Instance.EditarFilme(f, novoTitulo, novoDirector, novaDataLancamento, novoPreco, novaSinopse, novoGenero);

                        Console.Clear();

                        Console.WriteLine("Filme atualizado com sucesso!!");
                        Console.WriteLine(f.ToString());
                        Console.ReadLine();
                        Menu();
                        break;

                    case 8:
                        Console.Clear();

                        Console.WriteLine("Insira o titulo do filme");
                        string movieSearch = Console.ReadLine();

                        Console.Clear();
                        Movies movie = Fachada.Instance.BuscarFilme(movieSearch);
                        Console.WriteLine(movie.ToString());

                        int confirm = 0;

                        while (confirm != 1 && confirm != 2)
                        {
                            Console.WriteLine("Desseja remover filme? 1 - sim | 2 - nao");
                            confirm = Convert.ToInt32(Console.ReadLine());

                            if (confirm == 1)
                            {
                                Fachada.Instance.RemoverFilme(movie);
                                Console.WriteLine("Filme removido com sucesso!!");
                                Console.ReadLine();
                            }
                            else if (confirm == 2)
                            {
                                Console.WriteLine("Operaçao cancelada!");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Opçao invalida!");
                            }
                        }

                        Menu();
                        break;

                    case 9:
                        Console.Clear();

                        Console.WriteLine("Insira o titulo do filme: ");
                        string buscarFilmeAlugar = Console.ReadLine();

                        Movies film = Fachada.Instance.BuscarFilme(buscarFilmeAlugar);
                        Console.WriteLine(film.ToString());

                        Console.WriteLine("--- Insira o cpf do client: ");
                        string clienteCpf = Console.ReadLine();

                        Client fregues = Fachada.Instance.BuscarClient(clienteCpf);
                        Console.WriteLine(fregues.ToString());

                        Console.WriteLine("Alugar por quantos dias? ");
                        int dias = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Qual forma de pagamento? ");
                        string formPagamento = Console.ReadLine();

                        fregues.Alugar(fregues, film);
                        Invoice nf = new Invoice(fregues, film, dias, formPagamento);

                        Console.Clear();
                        Console.WriteLine("Alugado!");
                        Console.WriteLine(nf.ToString());

                        Console.ReadLine();

                        Menu();
                        break;

                    case 10:
                        Console.Clear();

                        Console.WriteLine("Insira o cpf do client: ");
                        string clientCpf = Console.ReadLine();

                        Client c = Fachada.Instance.BuscarClient(clientCpf);
                        Console.WriteLine(c.ToString());

                        Console.WriteLine("Insira o filme a devolver: ");
                        string devolve = Console.ReadLine();

                        Movies fi = Fachada.Instance.BuscarFilme(devolve);
                        Console.WriteLine(fi.ToString());

                        c.Devolver(c, fi);

                        Console.WriteLine("Devolvido!");

                        Console.ReadLine();

                        Menu();
                        break;

                    default:
                        Console.Clear();
                        Console.Write("Obrigado por usar esse sistema");

                        break;
                }
            } while (operacao != 11);
        }
    }
}
