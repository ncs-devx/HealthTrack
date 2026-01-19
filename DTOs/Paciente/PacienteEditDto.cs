namespace HealthTrack.DTOs.Paciente
{
    public class PacienteEditDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
    }
}
