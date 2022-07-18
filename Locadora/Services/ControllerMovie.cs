using Locadora.Dados;
using Locadora.Services.Models;
using System;

namespace Locadora.Services
{
    public class ControllerMovie
    {
        private MoviesDados _movie;

        private static readonly ControllerMovie instance = new ControllerMovie();

        static ControllerMovie()
        {

        }
        public ControllerMovie()
        {
            _movie = MoviesDados.Instance;
        }

        public static ControllerMovie Instance
        {
            get { return instance; }
        }

        public Boolean Salvar(Movies movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _movie.Salvar(movie);
                return true;
            }
        }

        public Movies Buscar(string titulo)
        {
            if (titulo.Equals(""))
            {
                throw new ArgumentNullException();
            }
            else
            {
                return _movie.Buscar(titulo);
            }
        }

        public string Listar()
        {
            return _movie.Listar();
        }

        public void Remover(Movies movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _movie.Remover(movie);
            }
        }

        public void Editar(Movies movie, string name, string director, DateTime lancamento, string genero, double preco, string sinopse)
        {
            if (movie == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _movie.Editar(movie, name, director, lancamento, preco, genero, sinopse);
            }
        }
    }
}
