using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HealthTrack.Services;
using HealthTrack.Models;
using HealthTrack.DTOs.Paciente;

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
        public IActionResult Create(PacienteCreateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            // 🔁 MAPEAMENTO DTO → MODEL (AQUI)
            var paciente = new Paciente
            {
                Nome = dto.Nome,
                CPF = dto.CPF
            };

            _pacienteService.Criar(paciente);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var paciente = _pacienteService.ObterPorId(id);
            if (paciente == null)
                return NotFound();

            // 🔁 MODEL → DTO (para preencher a View)
            var dto = new PacienteEditDto
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                CPF = paciente.CPF
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PacienteEditDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            // 🔁 DTO → MODEL (AQUI)
            var paciente = new Paciente
            {
                Id = dto.Id,
                Nome = dto.Nome,
                CPF = dto.CPF
            };

            _pacienteService.Atualizar(paciente);
            return RedirectToAction(nameof(Index));
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
