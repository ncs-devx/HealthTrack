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
            _context.Medicos.Add(medico);
            _context.SaveChanges();
        }

        public void Atualizar(Medico medico)
        {
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
    }
}
