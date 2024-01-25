using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartschoolApi.Data.ValueObject;
using SmartschoolApi.Helpers;
using SmartschoolApi.Model;
using SmartschoolApi.Repository;
using SmartschoolApi.Repository.Intefaces;

namespace SmartschoolApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;
        
        public AlunoController(IAlunoRepository alunoRepository) 
        {
            _alunoRepository = alunoRepository ?? throw new ArgumentNullException(nameof(alunoRepository));
        }

        /// <summary>
        /// Método que retorna todos os alunos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams)
        {
            var alunos = await _alunoRepository.FindAllAsync(pageParams);
            Response.AddPagination(alunos.CurrentPage, alunos.PageSize, alunos.TotalItems, alunos.TotalPages);

            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var aluno = await _alunoRepository.FindByIdAsync(id);

            if(aluno == null)
                return NotFound();

            return Ok(aluno);
        }

        [HttpPost]
        public async Task<IActionResult> CreateByIdAsync(AlunoRegisterVO aluno)
        {
            if (aluno == null)
                return BadRequest();

            var result = await _alunoRepository.CreateByIdAsync(aluno);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateByIdAsync(AlunoRegisterVO aluno)
        {
            if (aluno == null)
                return BadRequest();

            var result = await _alunoRepository.UpdateByIdAsync(aluno);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var status = await _alunoRepository.DeleteByIdAsync(id);
            if (!status)
                return BadRequest();

            return Ok("Aluno excluído com sucesso!");
        }
    }
}
