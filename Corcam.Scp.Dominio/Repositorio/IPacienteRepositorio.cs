using System;
using System.Collections.Generic;
using System.Linq;
using Corcam.Scp.Dominio.Comandos.Resultados;
using Corcam.Scp.Dominio.Entidades;

namespace Corcam.Scp.Dominio.Repositorio
{
    public interface IPacienteRepositorio
    {
        Paciente Obter(Guid id);
        PacientesResultado Get(string cpf);
        IQueryable<Paciente> ObterPacientes();
        IEnumerable<PacientesResultado> ObterPacientesTodos();
        void SalvarPaciente(Paciente paciente);
        void Atualizar(Paciente paciente);
        void Excluir(Paciente paciente);
        void Excluir(Guid id);
        void Salvar();
    }
}
