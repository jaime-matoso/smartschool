using SmartschoolApi.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SmartschoolApi.Model
{
    [Table("aluno")]
    public class Aluno : BaseEntity
    {
        public Aluno() { }

        public Aluno(int id, string nome, string sobrenome, string telefone, DateTime dataNascimento, DateTime dataInicio, bool status)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            DataInicio = dataInicio;
            Status = status;
            AlunoDisciplinas = null;
        }

        [Column("nome")]
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        [Column("sobrenome")]
        [Required]
        [StringLength(150)]
        public string Sobrenome { get; set; }

        [Column("telefone")]
        [Required]
        [StringLength(20)]
        public string Telefone { get; set; }

        [Column("data_nascimento")]
        [Required]
        public DateTime DataNascimento { get; set; }

        [Column("data_inicio")]
        [Required]
        public DateTime DataInicio { get; set; }

        [Column("status")]
        [Required]
        public bool Status { get; set; }

        public IEnumerable<AlunoDisciplina>? AlunoDisciplinas { get; }

    }
}
