using HealthTrack.Data;
using HealthTrack.Models;

namespace HealthTrack.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly HealthTrackContext _context;

        public MedicoService(HealthTrackContext context)
        {
            _context = context;
        }

        public IEnumerable<Medico> ObterTodos()
        {
            return _context.Medicos.ToList();
        }

        public Medico? ObterPorId(int id)
        {
            return _context.Medicos.FirstOrDefault(m => m.Id == id);
        }

        public void Criar(Medico medico)
        {
            ValidarMedico(medico);

            bool crmExiste = _context.Medicos.Any(m => m.CRM == medico.CRM);
            if (crmExiste)
                throw new Exception("Já existe um médico cadastrado com este CRM.");

            _context.Medicos.Add(medico);
            _context.SaveChanges();
        }

        public void Atualizar(Medico medico)
        {
            ValidarMedico(medico);

            bool crmDuplicado = _context.Medicos.Any(m =>
                m.CRM == medico.CRM && m.Id != medico.Id);

            if (crmDuplicado)
                throw new Exception("Já existe outro médico cadastrado com este CRM.");

            _context.Medicos.Update(medico);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            var medico = ObterPorId(id);
            if (medico == null)
                return;

            _context.Medicos.Remove(medico);
            _context.SaveChanges();
        }

        private void ValidarMedico(Medico medico)
        {
            if (string.IsNullOrWhiteSpace(medico.Nome))
                throw new Exception("O nome do médico é obrigatório.");

            if (string.IsNullOrWhiteSpace(medico.CRM))
                throw new Exception("O CRM é obrigatório.");
        }
    }
}