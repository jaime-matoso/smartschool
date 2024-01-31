using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartschoolApi.Data.ValueObject;
using SmartschoolApi.Helpers;
using SmartschoolApi.Model;
using SmartschoolApi.Repository.Intefaces;
using SmartSchoolApi.Data.ValueObject;

namespace SmartSchoolApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : Controller
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorController(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository ?? throw new ArgumentNullException(nameof(professorRepository));
        }

        /// <summary>
        /// Método que retorna todos os professores cadastrados.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var professores = await _professorRepository.FindAllAsync();
            return Ok(professores);
        }

        [HttpGet("/GetAllProfessorDisciplinasAsync")]
        public async Task<IActionResult> GetAllProfessorDisciplinasAsync()
        {
            var professores = await _professorRepository.FindAllProfessorDisciplinasAsync();
            return Ok(professores);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var professor = await _professorRepository.FindByIdAsync(id);

            if (professor == null)
                return NotFound();

            return Ok(professor);
        }

        

        [HttpGet("/GetProfessorDisciplinaById/{id}")]
        public async Task<IActionResult> GetProfessorDisciplinaById(int id)
        {
            var professor = await _professorRepository.FindProfessorDisciplinaByIdAsync(id);

            if (professor == null)
                return NotFound();

            return Ok(professor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateByIdAsync(ProfessorRegisterVO professor)
        {
            if (professor == null)
                return BadRequest();

            var result = await _professorRepository.CreateByIdAsync(professor);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateByIdAsync(ProfessorRegisterVO professor)
        {
            if (professor == null)
                return BadRequest();

            var result = await _professorRepository.UpdateByIdAsync(professor);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var status = await _professorRepository.DeleteByIdAsync(id);
            if (!status)
                return BadRequest();

            return Ok("Professor excluído com sucesso!");
        }

    }
}
