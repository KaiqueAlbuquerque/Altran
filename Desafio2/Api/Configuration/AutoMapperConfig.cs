using Api.ViewModel;
using AutoMapper;
using Business.Models;
using System;

namespace Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Car, CarViewModel>()
                .ForMember(dest => dest.ano_modelo, opt => opt.MapFrom(src => src.YearModel.Year.ToString()))
                .ForMember(dest => dest.ano_fabricacao, opt => opt.MapFrom(src => src.YearOfManufacture.Year.ToString()))
                .ForMember(dest => dest.placa, opt => opt.MapFrom(src => src.Plaque))
                .ForMember(dest => dest.proprietario, opt => opt.MapFrom(src => src.Owner))
                .ForMember(dest => dest.veiculo_roubado, opt => opt.MapFrom(src => src.Stolen));

            CreateMap<CarViewModel, Car>()
                .ForMember(dest => dest.YearModel, opt => opt.MapFrom(src => Convert.ToDateTime($"{src.ano_modelo}-12-31 00:00:00")))
                .ForMember(dest => dest.YearOfManufacture, opt => opt.MapFrom(src => Convert.ToDateTime($"{src.ano_fabricacao}-12-31 00:00:00")))
                .ForMember(dest => dest.Plaque, opt => opt.MapFrom(src => src.placa))
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.proprietario))
                .ForMember(dest => dest.Stolen, opt => opt.MapFrom(src => src.veiculo_roubado));
        }
    }
}
