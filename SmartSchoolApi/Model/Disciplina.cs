using SmartschoolApi.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SmartschoolApi.Model
{
    [Table("disciplina")]
    public class Disciplina : BaseEntity
    {
        public Disciplina() { }

        public Disciplina(int id, string descricao, int professorId)
        {
            Id = id;
            Descricao = descricao;
            ProfessorId = professorId;
        }

        [Column("nome")]
        [Required]
        [StringLength(150)]
        public string Descricao { get; set; }

        [JsonIgnore]
        public int ProfessorId { get; set; }

        [JsonIgnore]
        public Professor Professor { get; set; }

    }
}
