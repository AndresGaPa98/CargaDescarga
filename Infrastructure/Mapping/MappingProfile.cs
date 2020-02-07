using AutoMapper;
using CargaDescarga;
using Scm.Controllers.Dtos;
using Scm.Domain;


namespace Scm.Infrastructure.Mapping
{
    
    public class MappingProfile : Profile {
    public MappingProfile() {
             CreateMap<AppUser, RegisterUserResponseDto>();
             CreateMap<Empleado, EmpleadoDtos>();
             CreateMap<EmpleadoDtos,Empleado>();
             CreateMap<EmpleadoResponseDto,Empleado>();
             CreateMap<Empleado,EmpleadoResponseDto>();
             CreateMap<EmpleadoUpdateDto,Empleado>();
             CreateMap<Empleado,EmpleadoUpdateDto>();
             CreateMap<ValeDto, Vale>()
                .ForMember(dest=> dest.FechaExpedicionVale, 
                          opt=>opt.MapFrom(src=>src.Fecha))
                .ForMember(dest=> dest.FolioVale, 
                         opt=>opt.MapFrom(src=>src.Folio));

                CreateMap<RegisterValesDto, RegistroVale>().ReverseMap();
<<<<<<< Updated upstream

                CreateMap<RegistroVale, RegisterValesResponseDto>();
<<<<<<< HEAD
            CreateMap<EmpresaDtos, Empresa>();
            CreateMap<Empresa, EmpresaDtos>();
            CreateMap<Empresa, EmpresaResponseDto>().ReverseMap();
=======
                CreateMap<EmpresaDtos, Empresa>().ReverseMap();
                CreateMap<EmpresaResponseDto, Empresa>().ReverseMap();

=======

                CreateMap<RegistroVale, RegisterValesResponseDto>();
>>>>>>> Stashed changes
>>>>>>> 30dc523020a5843d80cb588a1f7933373b9f918e
            
        }
    }
}