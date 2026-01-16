using HealthTrack.Models;

namespace HealthTrack.Services
{
    public interface IPacienteService
    {
        IEnumerable<Paciente> ObterTodos();
        Paciente? ObterPorId(int id);
        void Criar(Paciente paciente);
        void Atualizar(Paciente paciente);
        void Excluir(int id);
    }
}