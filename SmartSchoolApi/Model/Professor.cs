using SmartschoolApi.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SmartschoolApi.Model
{
    [Table("professor")]
    public class Professor : BaseEntity 
    {
        public Professor() { }

        public Professor(int id, string nome, string sobrenome, string telefone)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Telefone = telefone;
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
        
        public IEnumerable<Disciplina>? Disciplinas { get; set; }
    }
}
