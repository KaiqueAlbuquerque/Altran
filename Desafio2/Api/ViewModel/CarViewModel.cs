using System;
using System.ComponentModel.DataAnnotations;

namespace Api.ViewModel
{
    public class CarViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo Placa é obrigatório")]
        [StringLength(8, ErrorMessage = "O campo precisa ter 8 caracteres", MinimumLength = 8)]
        public string placa { get; set; }

        [Required(ErrorMessage = "O campo Proprietário é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo precisa ter no máximo 100 caracteres", MinimumLength = 5)]
        public string proprietario { get; set; }

        [Required(ErrorMessage = "O campo Furto é obrigatório")]
        public bool veiculo_roubado { get; set; }

        [Required(ErrorMessage = "O campo Ano Fabricação é obrigatório")]
        [StringLength(4, ErrorMessage = "O campo precisa ter no máximo 4 caracteres", MinimumLength = 4)]
        public string ano_fabricacao { get; set; }

        [Required(ErrorMessage = "O campo Ano Modelo é obrigatório")]
        [StringLength(4, ErrorMessage = "O campo precisa ter no máximo 4 caracteres", MinimumLength = 4)]
        public string ano_modelo { get; set; }
    }
}
