using AutoMapper;
using MyServices.Entities;
using MyServices.Models.People;

namespace MyServices.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateRequest -> User
            CreateMap<CreateRequest, People>()
                .ForMember(dest => dest.cNombres, opt => opt.MapFrom(src => src.Nombres))
                .ForMember(dest => dest.cApellidoPaterno, opt => opt.MapFrom(src => src.ApellidoPaterno))
                .ForMember(dest => dest.cApellidoMaterno, opt => opt.MapFrom(src => src.ApellidoMaterno))
                .ForMember(dest => dest.nTipoDOI, opt => opt.MapFrom(src => src.TipoDOI))
                .ForMember(dest => dest.cNumeroDOI, opt => opt.MapFrom(src => src.CodigoDOI))
                .ForMember(dest => dest.cNumeroTelefono, opt => opt.MapFrom(src => src.NumeroTelefono))
                .ForMember(dest => dest.cCorreoElectronico, opt => opt.MapFrom(src => src.CorreoElectronico))
                .ForMember(dest => dest.cDireccion, opt => opt.MapFrom(src => src.Direccion))
                .ForMember(dest => dest.cPersonaId, opt => opt.Ignore()); // Ignorar el mapeo de la clave primaria




            // UpdateRequest -> User
            CreateMap<UpdateRequest, People>()
                .ForMember(dest => dest.cNombres, opt => opt.MapFrom(src => src.Nombres))
                .ForMember(dest => dest.cApellidoPaterno, opt => opt.MapFrom(src => src.ApellidoPaterno))
                .ForMember(dest => dest.cApellidoMaterno, opt => opt.MapFrom(src => src.ApellidoMaterno))
                .ForMember(dest => dest.nTipoDOI, opt => opt.MapFrom(src => src.TipoDOI))
                .ForMember(dest => dest.cNumeroDOI, opt => opt.MapFrom(src => src.CodigoDOI))
                .ForMember(dest => dest.cNumeroTelefono, opt => opt.MapFrom(src => src.NumeroTelefono))
                .ForMember(dest => dest.cCorreoElectronico, opt => opt.MapFrom(src => src.CorreoElectronico))
                .ForMember(dest => dest.cDireccion, opt => opt.MapFrom(src => src.Direccion))
                .ForMember(dest => dest.cPersonaId, opt => opt.Ignore()); // Ignorar el mapeo de la clave primaria





                    
         
        }
    }
}
