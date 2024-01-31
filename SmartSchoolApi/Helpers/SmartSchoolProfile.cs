using AutoMapper;
using SmartschoolApi.Data.ValueObject;
using SmartschoolApi.Model;
using SmartSchoolApi.Data.ValueObject;
using SmartSchoolApi.Helpers;

namespace SmartschoolApi.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoVO>()
                .ForMember(
                    dest => dest.Codigo,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                )
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.DataNascimento.GetAge())
                );

            CreateMap<Professor, ProfessorVO>()
                .ForMember(
                    dest => dest.Codigo,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                );

            CreateMap<ProfessorVO, Professor>();
            
            CreateMap<Professor, ProfessorRegisterVO>();
            CreateMap<ProfessorRegisterVO, Professor>();

            CreateMap<Aluno, AlunoRegisterVO>();
            CreateMap<AlunoRegisterVO,Aluno>();
            
        }
    }
}
