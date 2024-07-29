using api_reservas.Core.Models.BaseModels;

namespace api_reservas.Core.Models
{
    public class Reserva : BaseEntity
    {
        public string CondominioId { get; set; }
        public string CondominoId { get; set; }
        public DateTime DataHorario { get; set; }
    }
}
