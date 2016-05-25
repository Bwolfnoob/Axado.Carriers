using AutoMapper;
using Axado.Carriers.Application.Entities;
using Axado.Carriers.Application.Interfaces;
using Axado.Carriers.Application.ViewModels;
using Axado.Carriers.Domain.Entities;
using Axado.Carriers.Domain.Interface.Repository;
using Axado.Carriers.Domain.Interface.Services;
using Axado.Carriers.Domain.Service;
using Axado.Carriers.Infraestructure.Context;
using Axado.Carriers.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Axado.Carriers.Application
{
    public class AxadoModules
    {
        public static void SetAppService(IServiceCollection services)
        {

            Mapper.Initialize(c => { c.CreateMissingTypeMaps = true;
                c.CreateMap<Rate, RateViewModel>()
                .ForMember(d => d.IdUser, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(d => d.IdCarrier, opt => opt.MapFrom(src => src.Carrier.Id))
                .ReverseMap();
                c.CreateMap<User, UserViewModel>().ReverseMap();
            });

            services.AddTransient<DbContext , AxadoSqlServerContext>();

            services.AddTransient<ICarrierRepository, CarrierRepository>();
            services.AddTransient<ICarrierService, CarrierService>();
            services.AddTransient<ICarrierAppService, CarrierAppService>();

            services.AddTransient<IRateRepository, RateRepository>();
            services.AddTransient<IRateService, RateService>();
            services.AddTransient<IRateAppService, RateAppService>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserAppService, UserAppService>();

           
        }
    }
}
