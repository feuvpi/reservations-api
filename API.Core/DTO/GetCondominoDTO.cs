using api_reservas.Core.Models.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api_reservas.Core.Dtos
{


    public class GetCondominoDTO : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }

    }
}

