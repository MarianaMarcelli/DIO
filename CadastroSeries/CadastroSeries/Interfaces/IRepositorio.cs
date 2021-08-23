using System.Collections.Generic;

namespace CadastroSeries.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Listar();
        T RetornaId(int id);
        void Inserir(T entidade);
        void Excluir(int id);
        void Atualizar(int id, T entidade);
        int ProximoId();
        
    }
}