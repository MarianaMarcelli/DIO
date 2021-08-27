using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.Repository;
using ApiCatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public Task AtualizarJogo(Guid id, JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarPrecoJogo(Guid id, double preco)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _jogoRepository?.Dispose();
        }

        public Task ExcluirJogo(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<JogoViewModel> Inserir(JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        public Task<List<JogoViewModel>> ListarJogos(int pagina, int quantidade)
        {
            throw new NotImplementedException();
        }

        public Task<JogoViewModel> SelecionarJogoId(Guid id)
        {
            throw new NotImplementedException();
        }
       
    }
}
