using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartschoolApi.Data.ValueObject
{
    public class AlunoRegisterVO
    {
       public int Id { get; set; }
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataInicio { get; set; }

        public bool Status { get; set; }
    }
}
