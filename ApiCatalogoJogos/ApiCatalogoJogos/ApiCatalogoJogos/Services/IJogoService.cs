using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Services
{
    public interface IJogoService : IDisposable
    {
        Task<List<JogoViewModel>> ListarJogos(int pagina, int quantidade);
        Task<JogoViewModel> SelecionarJogoId (Guid id);
        Task <JogoViewModel> Inserir(JogoInputModel jogo);
        Task AtualizarJogo(Guid id, JogoInputModel jogo);
        Task AtualizarPrecoJogo(Guid id, double preco);
        Task ExcluirJogo(Guid id);
    }
}
