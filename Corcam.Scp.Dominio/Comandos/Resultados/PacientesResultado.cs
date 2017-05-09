using System;

namespace Corcam.Scp.Dominio.Comandos.Resultados
{
    public class PacientesResultado
    {
        public Guid Id { get; set; }
        public string Cpf { get; set; }

        public string NomeCompleto { get; set; }

        public string Sexo { get; set; }

        public DateTime DataNascimento { get; set; }

        public decimal Peso { get; set; }

        public decimal Altura { get; set; }
    }
}



//CREATE VIEW[dbo].[ObterPacientesView]
//AS
//SELECT        Id, Cpf, Nome + ' ' + Sobrenome as NomeCompleto, 

//CASE WHEN Sexo = 1 THEN 'Masculino' WHEN Sexo = 2 THEN 'Feminino' END AS Sexo, DataNascimento, Peso, Altura
//FROM            dbo.Paciente

//GO



//select* from[ObterPacientesView]

