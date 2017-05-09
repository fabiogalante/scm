using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Corcam.Scp.Web.Model
{
    public class PacienteDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o Cpf")]
        [DisplayName("Cpf:")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Informe o Cpf")]
        [DisplayName("Nome comppleto:")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Informe o Sexo")]
        public int Sexo { get; set; }

        [Required(ErrorMessage = "Informe o Cpf")]
        [DisplayName("Data de nascimento:")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }


        [Required(ErrorMessage = "Informe o peso")]
        public decimal Peso { get; set; }

        [Required(ErrorMessage = "Informe o altura")]
        public decimal Altura { get; set; }
    }
}
