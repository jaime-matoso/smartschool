using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartschoolApi.Data.ValueObject;
using SmartschoolApi.Helpers;
using SmartschoolApi.Model;
using SmartschoolApi.Model.Context;
using SmartschoolApi.Repository.Intefaces;

namespace SmartschoolApi.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly SmartContext _context;
        private IMapper _mapper;

        public AlunoRepository(SmartContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PageList<AlunoVO>> FindAllAsync(PageParams pageParams)
        {
            IEnumerable<Aluno> alunos = await _context.Alunos.ToListAsync();
            var AlunoVo =  _mapper.Map<IEnumerable<AlunoVO>>(alunos);
            return PageList<AlunoVO>.CreateAsync(AlunoVo, pageParams.PageNumber, pageParams.PageSize);
        }

        public async Task<AlunoVO?> FindByIdAsync(int id)
        {
            Aluno? aluno = await _context.Alunos.FindAsync(id);
            return _mapper.Map<AlunoVO>(aluno);
        }

        public async Task<AlunoRegisterVO> CreateByIdAsync(AlunoRegisterVO aluno)
        {
            _context.Alunos.Add(_mapper.Map<Aluno>(aluno));
            await _context.SaveChangesAsync();
            return aluno;
        }

        public async Task<AlunoRegisterVO> UpdateByIdAsync(AlunoRegisterVO aluno)
        {
            _context.Alunos.Update(_mapper.Map<Aluno>(aluno));
            await _context.SaveChangesAsync();
            return aluno;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            try
            {
                Aluno? aluno = await _context.Alunos.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (aluno == null)
                    return false;

                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
