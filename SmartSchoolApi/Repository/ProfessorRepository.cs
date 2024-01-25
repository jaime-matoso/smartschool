using Microsoft.EntityFrameworkCore;
using SmartschoolApi.Data.ValueObject;
using SmartschoolApi.Model;
using SmartschoolApi.Model.Context;
using SmartschoolApi.Repository.Intefaces;

namespace SmartschoolApi.Repository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly SmartContext _context;
        //private IMapper _mapper;

        public ProfessorRepository(SmartContext context /*IMapper mapper*/)
        {
            _context = context;
            //_mapper = mapper;
        }

        public async Task<IEnumerable<Professor>> FindAllAsync()
        {
            IEnumerable<Professor> professores = await _context.Professores.ToListAsync();
            return professores;
        }

        public async Task<Professor> FindByIdAsync(int id)
        {
            Professor professor = await _context.Professores.Where(a => a.Id == id).FirstOrDefaultAsync();
            return professor;
        }

        public async Task<Professor> CreateByIdAsync(Professor professor)
        {
            _context.Professores.Add(professor);
            await _context.SaveChangesAsync();
            return professor;
        }

        public async Task<Professor> UpdateByIdAsync(Professor professor)
        {
            _context.Professores.Update(professor);
            await _context.SaveChangesAsync();
            return professor;
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
