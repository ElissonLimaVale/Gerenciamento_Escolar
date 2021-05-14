using AutoMapper;
using SGIEscolar.Data.Models;
using SGIEscolar.ViewModels;

namespace SGIEscolar.Data.AutoMapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //Create Mappings
            CreateMap<UsuarioViewModel, Usuario>().ReverseMap();
            CreateMap<PermissaoViewModel, Permissao>().ReverseMap();
            CreateMap<LicencaViewModel, Licenca>().ReverseMap();
        }
    }
}
