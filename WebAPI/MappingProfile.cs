using AutoMapper;
using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<Company, CompanyDto>()
           .ForMember(c => c.FullAddress,
           opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
            CreateMap<Klient, KlientDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Prodaja, ProdajaDto>();
            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<KlientForCreationDto, Klient>();
            CreateMap<ProdajaForCreationDto, Prodaja>();
            CreateMap<EmployeeForUpdateDto, Employee>();
            CreateMap<CompanyForUpdateDto, Company>();
            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();
            CreateMap<ProdajaForUpdateDto, Prodaja>().ReverseMap();
            CreateMap<KlientForUpdateDto, Klient>();
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
