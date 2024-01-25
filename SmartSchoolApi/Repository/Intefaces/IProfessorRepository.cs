using SmartschoolApi.Data.ValueObject;
using SmartschoolApi.Model;

namespace SmartschoolApi.Repository.Intefaces
{
    public interface IProfessorRepository
    {
        Task<IEnumerable<Professor>> FindAllAsync();

        Task<Professor> FindByIdAsync(int id);

        Task<Professor> CreateByIdAsync(Professor professor);

        Task<Professor> UpdateByIdAsync(Professor professor);

        Task<bool> DeleteByIdAsync(int id);

    }
}
