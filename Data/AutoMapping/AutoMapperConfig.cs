using AutoMapper;
using SGIEscolar.Data.Models;
using SGIEscolar.ViewModels;

namespace SGIEscolar.Data.AutoMapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //Create Mappinges
            CreateMap<Professor,ProfessorViewModel>().ReverseMap();
            CreateMap<Aluno,AlunoViewModel>().ReverseMap();
            CreateMap<Endereco,EnderecoViewModel>().ReverseMap();
            CreateMap<Turma,TurmaViewModel>().ReverseMap();
            CreateMap<Usuario,UsuarioViewModel>().ReverseMap();
            CreateMap<Permissao,PermissaoViewModel>().ReverseMap();
            CreateMap<Licenca,LicencaViewModel>().ReverseMap();
            CreateMap<Instituicao,InstituicaoViewModel>().ReverseMap();
        }
    }
}
