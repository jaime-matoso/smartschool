using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartschoolApi.Data.ValueObject;
using SmartschoolApi.Model;
using SmartschoolApi.Model.Context;
using SmartschoolApi.Repository.Intefaces;
using SmartSchoolApi.Data.ValueObject;

namespace SmartschoolApi.Repository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly SmartContext _context;
        private IMapper _mapper;

        public ProfessorRepository(SmartContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProfessorVO>> FindAllAsync()
        {
            IEnumerable<Professor> professores = await _context.Professores.ToListAsync();
            var professorVO = _mapper.Map<IEnumerable<ProfessorVO>>(professores);
            return professorVO;
        }

        public async Task<IEnumerable<ProfessorVO>> FindAllProfessorDisciplinasAsync()
        {
            IEnumerable<Professor> professores = await _context.Professores.Include(p => p.Disciplinas).ToListAsync();
            var professorVO = _mapper.Map<IEnumerable<ProfessorVO>>(professores);
            return professorVO;
        }

        public async Task<ProfessorVO> FindByIdAsync(int id)
        {
            Professor professor = await _context.Professores.Where(a => a.Id == id).FirstOrDefaultAsync();
            var professorVO = _mapper.Map<ProfessorVO>(professor);
            return professorVO;
        }

        public async Task<ProfessorVO> FindProfessorDisciplinaByIdAsync(int id)
        {
            Professor professor = await _context.Professores.Include(p => p.Disciplinas).Where(a => a.Id == id).FirstOrDefaultAsync();
            var professorVO = _mapper.Map<ProfessorVO>(professor);
            return professorVO;
        }

        public async Task<ProfessorRegisterVO> CreateByIdAsync(ProfessorRegisterVO professorVO)
        {
            var professor = _mapper.Map<Professor>(professorVO);
            _context.Professores.Add(professor);
            await _context.SaveChangesAsync();
            return professorVO;
        }

        public async Task<ProfessorRegisterVO> UpdateByIdAsync(ProfessorRegisterVO professorVO)
        {
            var professor = _mapper.Map<Professor>(professorVO);
            _context.Professores.Update(professor);
            await _context.SaveChangesAsync();
            return professorVO;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            try
            {
                Professor professor = await _context.Professores.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (professor == null)
                    return false;

                _context.Professores.Remove(professor);
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
