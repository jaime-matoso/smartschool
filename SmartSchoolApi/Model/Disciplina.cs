using SmartschoolApi.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int ProfessorId { get; set; }

        public Professor Professor { get; set; }

    }
}
