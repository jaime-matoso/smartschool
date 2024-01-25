using SmartschoolApi.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartschoolApi.Data.ValueObject
{
    public class AlunoVO
    {
        public int Codigo { get; set; }
        
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public int Idade { get; set; }

        public bool Status { get; set; }

    }
}
