using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repository
{
    public interface IJogoRepository : IDisposable
    {
        Task<List<Jogo>> ListarJogos(int pagina, int quantidade);
        Task<Jogo> SelecionarJogoId(Guid id);
        Task<List<Jogo>> ListarJogoNome(string nome, string produtora);
        Task Inserir(Jogo jogo);
        Task Atualizar(Jogo jogo);
        Task Remover(Guid id);
    }
}
