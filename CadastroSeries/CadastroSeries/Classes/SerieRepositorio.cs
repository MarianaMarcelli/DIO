using System.Collections.Generic;
using CadastroSeries.Interfaces;

namespace CadastroSeries.Classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();
        public void Atualizar(int id, Serie serie)
        {
            listaSeries[id] = serie;
        }
        public void Excluir(int id)
        {
           listaSeries[id].Excluir();
        }

        public void Inserir(Serie serie)
        {
            listaSeries.Add(serie);
        }

        public List<Serie> Listar()
        {
            return listaSeries;
        }

        public int ProximoId()
        {
            return listaSeries.Count;
        }

        public Serie RetornaId(int id)
        {
            return listaSeries[id];
        }
    }
}