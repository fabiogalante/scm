using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corcam.Scp.Compartilhado;
using Corcam.Scp.Dominio.ObjetosValor;
using FluentValidator;

namespace Corcam.Scp.Dominio.Entidades
{
    public class Paciente : Entidade
    {
        protected Paciente() { } //Utilizado pelo Proxy do Entity

        public Paciente(Documento documento, Nome nome, Dados dados)
        {
            Documento = documento;
            Nome = nome;
            Dados = dados;


            if (! Documento.ValidarCpf(documento.Numero))
                AddNotification("Documento", "CPF inválido");

            new ValidationContract<Paciente>(this)
                .IsGreaterThan(f => f.Dados.Idade, 12, "Idade inválida")
                .IsGreaterThan(f => f.Dados.Altura, 0.1m, "Informe a altura")
                .IsGreaterThan(f => f.Dados.Peso, 0.1m, "Informe o peso")
                .IsRequired(f => f.Documento.Numero, "Informe o CPF");
        }

        //CPF + Nome Completo + Sexo + Data de Nascimento + Peso + Altura


        public Documento Documento { get; private set; }
        public Nome Nome { get; private set; }
        public Dados Dados { get; private set; }
        
       

    }
}
