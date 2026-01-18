using Microsoft.AspNetCore.Mvc;
using HealthTrack.Models;
using HealthTrack.Services;
using Microsoft.AspNetCore.Authorization;

namespace HealthTrack.Controllers
{
    [Authorize]
    public class MedicoController : Controller
    {
        private readonly IMedicoService _medicoService;

        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        // Listar médicos
        public IActionResult Index()
        {
            var medicos = _medicoService.ObterTodos();
            return View(medicos);
        }

        // Exibir formulário para criar um médico
        public IActionResult Create()
        {
            return View();
        }

        // Salvar novo médico
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                _medicoService.Criar(medico);
                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }

        // Exibir formulário para editar um médico
        public IActionResult Edit(int id)
        {
            var medico = _medicoService.ObterPorId(id);
            if (medico == null)
                return NotFound();

            return View(medico);
        }

        // Salvar alterações do médico
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Medico medico)
        {
            if (ModelState.IsValid)
            {
                _medicoService.Atualizar(medico);
                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }

        // Confirmar exclusão de médico
        public IActionResult Delete(int id)
        {
            var medico = _medicoService.ObterPorId(id);
            if (medico == null)
                return NotFound();

            return View(medico);
        }

        // Excluir médico
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _medicoService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
