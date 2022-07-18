using Locadora.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Dados
{
    public class MoviesDados
    {
        public List<Movies> movies;

        private static readonly MoviesDados instance = new MoviesDados();

        static MoviesDados()
        {

        }
        public MoviesDados()
        {
            movies = new List<Movies>();
        }

        public static MoviesDados Instance
        {
            get { return instance; }
        }

        //Methodo salvar
        public Boolean Salvar(Movies movie)
        {
            if (!movies.Contains(movie))
                movies.Add(movie);
            return true;

            //return false;
        }

        //Methodo buscar
        public Movies Buscar(string titulo)
        {
            foreach (Movies movie in movies)
                if (movie.Name == titulo)
                    return movie;

            return null;
        }
        //Methodo listar
        public string Listar()
        {
            foreach (Movies movie in movies)
                movie.ToString();
            return null;
        }

        //Methodo remover
        public void Remover(Movies movie)
        {
            for (int i = 0; i < movies.Count; i++)
                if (movies.ElementAt(i).Name.Equals(movie.Name))
                {
                    movies.RemoveAt(i);
                }
        }

        //Methodo editar
        public void Editar(Movies movie, string name, string director, DateTime lancamento, double preco, string genero, string sinopse)
        {
            foreach (Movies m in movies)
                if (m.Id == movie.Id)
                {
                    m.Name = name;
                    m.Director = director;
                    m.Lancamento = lancamento;
                    m.Preco = preco;
                    m.Genero = genero;
                    m.Sinopse = sinopse;
                }
        }
    }
}
