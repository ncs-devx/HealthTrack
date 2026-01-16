using HealthTrack.Data;
using HealthTrack.Models;

namespace HealthTrack.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly HealthTrackContext _context;

        public PacienteService(HealthTrackContext context)
        {
            _context = context;
        }

        public IEnumerable<Paciente> ObterTodos()
        {
            return _context.Pacientes.ToList();
        }

        public Paciente? ObterPorId(int id)
        {
            return _context.Pacientes.FirstOrDefault(p => p.Id == id);
        }

        public void Criar(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
        }

        public void Atualizar(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            var paciente = ObterPorId(id);
            if (paciente == null)
                return;

            _context.Pacientes.Remove(paciente);
            _context.SaveChanges();
        }
    }
}