using Microsoft.EntityFrameworkCore;
using SmartschoolApi.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SmartschoolApi.Model
{
    public class AlunoDisciplina
    {
        public int AlunoId { get; set; }

        public int DisciplinaId { get; set; }

        [JsonIgnore]
        public Aluno? Aluno { get; set; }

        public Disciplina? Disciplina { get; set; }
    }
}
