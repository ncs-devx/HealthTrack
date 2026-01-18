using HealthTrack.Models;

namespace HealthTrack.Services
{
    public interface IMedicoService
    {
        IEnumerable<Medico> ObterTodos();
        Medico? ObterPorId(int id);
        void Criar(Medico medico);
        void Atualizar(Medico medico);
        void Excluir(int id);
    }
}
