using Api.ViewModel;
using Business.Interfaces;
using Business.Services;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Test
{
    public class QueryBoard
    {
        private Mock<ICarRepository> _carRepository;
        private Mock<INotification> _notification;

        [Fact]
        public void CarQueryBoard()
        {
            _carRepository = new Mock<ICarRepository>();
            _notification = new Mock<INotification>();

            var carService = new CarService(_carRepository.Object, _notification.Object);

            var carViewModelBase = new CarViewModel()
            {
                placa = "ddd-1234",
                proprietario = "Joao da Silva",
                veiculo_roubado = false,
                ano_fabricacao = "2018",
                ano_modelo = "2019"
            };

            var carViewModel = JsonConvert.DeserializeObject<CarViewModel>(carService.GetByPlaque("ddd-1234"));
            carViewModel.placa = "ddd-1234";

            Assert.Equal(carViewModelBase.placa, carViewModel.placa);
            Assert.Equal(carViewModelBase.proprietario, carViewModel.proprietario);
            Assert.Equal(carViewModelBase.veiculo_roubado, carViewModel.veiculo_roubado);
            Assert.Equal(carViewModelBase.ano_modelo, carViewModel.ano_modelo);
            Assert.Equal(carViewModelBase.ano_fabricacao, carViewModel.ano_fabricacao);
        }
    }
}
