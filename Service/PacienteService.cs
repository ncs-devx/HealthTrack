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

            if (string.IsNullOrWhiteSpace(paciente.Nome))
                throw new Exception("O nome do paciente é obrigatório.");

            if (string.IsNullOrWhiteSpace(paciente.CPF))
                throw new Exception("O CPF é obrigatório.");

            if (paciente.CPF.Length != 11)
                throw new Exception("CPF inválido.");

            var cpfExiste = _context.Pacientes
                .Any(p => p.CPF == paciente.CPF && p.Id != paciente.Id);

            if (cpfExiste)
                throw new Exception("Já existe um paciente cadastrado com este CPF.");

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