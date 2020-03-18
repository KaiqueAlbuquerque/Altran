using FluentValidation;

namespace Business.Models.Validations
{
    public class CarValidation : AbstractValidator<Car>
    {
        public CarValidation()
        {
            RuleFor(c => c.Plaque)
                .NotEmpty().WithMessage("O campo Placa precisa ser fornecido")
                .Length(8).WithMessage("O campo Placa precisa ter 8 caracteres");

            RuleFor(c => c.Owner)
                .NotEmpty().WithMessage("O campo Proprietário precisa ser fornecido")
                .Length(5, 100).WithMessage("O campo Placa precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.YearOfManufacture)
                .NotEmpty().WithMessage("O campo Ano de Fabricação precisa ser fornecido");

            RuleFor(c => c.YearModel)
                .NotEmpty().WithMessage("O campo Ano do Modelo precisa ser fornecido");
        }
    }
}
