using CadastroSeries.Enum;
using System;

namespace CadastroSeries.Classes
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie()
        {}
         public Serie(Genero genero, string descricao, string titulo, int ano, int id)
        {
            this.Genero = genero;
            this.Descricao = descricao;
            this.Titulo = titulo;
            this.Ano = ano;
            this.Id = id;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero;
            retorno += "Título: " + this.Titulo;
            retorno += "Ano Lançamento: " + this.Ano;
            retorno += "Descrição: " + this.Genero;
            return retorno;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public bool FoiExcluido()
        {
            return this.Excluido;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
    }  
}