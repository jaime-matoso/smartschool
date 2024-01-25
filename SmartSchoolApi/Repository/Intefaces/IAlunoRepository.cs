using SmartschoolApi.Data.ValueObject;
using SmartschoolApi.Helpers;
using SmartschoolApi.Model;

namespace SmartschoolApi.Repository.Intefaces
{
    public interface IAlunoRepository
    {
        Task<PageList<AlunoVO>> FindAllAsync(PageParams pageParams);

        Task<AlunoVO?> FindByIdAsync(int id);

        Task<AlunoRegisterVO> CreateByIdAsync(AlunoRegisterVO aluno);

        Task<AlunoRegisterVO> UpdateByIdAsync(AlunoRegisterVO aluno);

        Task<bool> DeleteByIdAsync(int id);

    }
}
