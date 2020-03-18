using Api.ViewModel;
using AutoMapper;
using Business.Interfaces;
using Business.Interfaces.Service;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/cars")]
    public class CarController : MainController
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarController(ICarService carService,
                             IMapper mapper,
                             INotification notification) : base(notification)
        {
            _carService = carService;
            _mapper = mapper;
        }


        [HttpGet("getByPlaque")]
        public async Task<ActionResult<CarViewModel>> GetByPlaque(string plaque)
        {
            var carViewModel = JsonConvert.DeserializeObject<CarViewModel>(_carService.GetByPlaque(plaque));

            if (carViewModel == null)
                return NotFound();

            carViewModel.placa = plaque;

            await AddCar(carViewModel);

            return CustomResponse(carViewModel);
        }

        [HttpGet]
        public async Task<IEnumerable<CarViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CarViewModel>>(await _carService.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CarViewModel>> GetById(Guid id)
        {
            var car = _mapper.Map<CarViewModel>(await _carService.GetById(id));

            if (car == null) 
                return NotFound();

            return car;
        }

        [HttpPost]
        public async Task<ActionResult<CarViewModel>> Add(CarViewModel carViewModel)
        {
            if (!ModelState.IsValid) 
                return CustomResponse(ModelState);

            await _carService.Add(_mapper.Map<Car>(carViewModel));

            return CustomResponse(carViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CarViewModel>> Update(Guid id, CarViewModel carViewModel)
        {
            if (id != carViewModel.Id)
            {
                NotificationError("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(carViewModel);
            }

            if (!ModelState.IsValid) 
                return CustomResponse(ModelState);

            await _carService.Update(_mapper.Map<Car>(carViewModel));

            return CustomResponse(carViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CarViewModel>> Delete(Guid id)
        {
            var carViewModel = _mapper.Map<CarViewModel>(await _carService.GetById(id));

            if (carViewModel == null) 
                return NotFound();

            await _carService.Delete(id);

            return CustomResponse(carViewModel);
        }

        #region Métodos privados
        private async Task AddCar(CarViewModel carViewModel)
        {
            var carModel = _mapper.Map<Car>(carViewModel);
            await _carService.Add(carModel);
        }
        #endregion
    }
}
