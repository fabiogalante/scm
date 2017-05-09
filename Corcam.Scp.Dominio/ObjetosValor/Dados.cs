using System;
using Corcam.Scp.Dominio.Enum;
using Corcam.Scp.Dominio.Helpers;
using FluentValidator;

namespace Corcam.Scp.Dominio.ObjetosValor
{
    public class Dados : Notifiable
    {
        protected Dados(){} 
        public Dados(Sexo sexo, DateTime dataNascimento, decimal peso, decimal altura)
        {
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Peso = peso;
            Altura = altura;
            Idade = dataNascimento.GetCurrentAge();
        }

        public Sexo Sexo { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public decimal Peso { get; private set; }
        public decimal Altura { get; private set; }
        public int Idade { get;  }







    }
}
