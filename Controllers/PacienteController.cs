using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HealthTrack.Services;
using HealthTrack.Models;

namespace HealthTrack.Controllers
{
    [Authorize]
    public class PacienteController : Controller
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        public IActionResult Index()
        {
            var pacientes = _pacienteService.ObterTodos();
            return View(pacientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _pacienteService.Criar(paciente);
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        public IActionResult Edit(int id)
        {
            var paciente = _pacienteService.ObterPorId(id);
            if (paciente == null) return NotFound();

            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _pacienteService.Atualizar(paciente);
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        public IActionResult Delete(int id)
        {
            _pacienteService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _pacienteService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}