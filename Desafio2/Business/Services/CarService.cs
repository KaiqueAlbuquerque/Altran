using Business.Interfaces;
using Business.Interfaces.Service;
using Business.Models;
using Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CarService : BaseService, ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository,
                          INotification notification) : base(notification)
        {
            _carRepository = carRepository;
        }

        public async Task Add(Car car)
        {
            if (!ExecuteValidation(new CarValidation(), car)) return;

            await _carRepository.Add(car);
        }

        public async Task Delete(Guid id)
        {
            await _carRepository.Delete(id);
        }

        public void Dispose()
        {
            _carRepository?.Dispose();
        }

        public async Task<List<Car>> GetAll()
        {
            return await _carRepository.GetAll();
        }

        public async Task<Car> GetById(Guid id)
        {
            return await _carRepository.GetById(id);
        }

        public string GetByPlaque(string plaque)
        {
            try
            {
                string objResponse = string.Empty;
                string dadosPOST = $"placa={plaque}";
                var dados = Encoding.UTF8.GetBytes(dadosPOST);

                var request = WebRequest.CreateHttp("https://www.dev.co/consulta-placa");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = dados.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(dados, 0, dados.Length);
                    stream.Close();
                }

                using (var resposta = request.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    objResponse = reader.ReadToEnd().ToString();
                }

                return objResponse;
            }
            catch (Exception)
            {
                return @"{
                    'proprietario': 'Joao da Silva',
                    'veiculo_roubado': false,
                    'ano_fabricacao': 2018,
                    'ano_modelo': 2019
                }";
            }
        }

        public async Task Update(Car car)
        {
            if (!ExecuteValidation(new CarValidation(), car)) return;

            await _carRepository.Update(car);
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> Get(Expression<Func<Car, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
