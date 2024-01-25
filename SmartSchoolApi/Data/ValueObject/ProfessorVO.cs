using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartSchoolApi.Data.ValueObject
{
    public class ProfessorVO
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }
    }
}
