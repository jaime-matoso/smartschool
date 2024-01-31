using SmartschoolApi.Data.ValueObject;
using SmartschoolApi.Model;
using SmartSchoolApi.Data.ValueObject;

namespace SmartschoolApi.Repository.Intefaces
{
    public interface IProfessorRepository
    {
        Task<IEnumerable<ProfessorVO>> FindAllAsync();

        Task<ProfessorVO> FindByIdAsync(int id);

        Task<ProfessorRegisterVO> CreateByIdAsync(ProfessorRegisterVO professor);

        Task<ProfessorRegisterVO> UpdateByIdAsync(ProfessorRegisterVO professor);

        Task<ProfessorVO> FindProfessorDisciplinaByIdAsync(int id);

        Task<IEnumerable<ProfessorVO>> FindAllProfessorDisciplinasAsync();


        Task<bool> DeleteByIdAsync(int id);

    }
}
