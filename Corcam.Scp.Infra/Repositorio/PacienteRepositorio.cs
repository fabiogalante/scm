using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Corcam.Scp.Compartilhado;
using Corcam.Scp.Dominio.Comandos.Resultados;
using Corcam.Scp.Dominio.Entidades;
using Corcam.Scp.Dominio.Repositorio;
using Corcam.Scp.Infra.Contexto;
using Dapper;

namespace Corcam.Scp.Infra.Repositorio
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly ScpDataContext _context;

        public PacienteRepositorio(ScpDataContext context)
        {
            _context = context;
        }
        public Paciente Obter(Guid id)
        {
            return _context
                .Pacientes
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }

        public PacientesResultado Get(string cpf)
        {
            //return _context
            //    .Pacientes
            //    .AsNoTracking()
            //    .Select(x => new ObterPacientesComandoResultado
            //    {
            //        NomeCompleto = x.Nome.PrimeiroNome
            //    }).FirstOrDefault(x => x.Cpf == cpf);

            //Ou com Dapper


            var query =
                "SELECT NomeCompleto ,Sexo ,DataNasicmento ,Peso ,Altura FROM Scp.dbo.ViewPaciente WHERE [CPF]=@cpf ";

            using (var connection = new SqlConnection(Runtime.ConnectionString))
            {
                connection.Open();
                return connection
                    .Query<PacientesResultado>(query,
                        new {cpf})
                    .FirstOrDefault();
            }
        }

        public IEnumerable<PacientesResultado> ObterPacientesTodos()
        {
            var query =
                "SELECT Id, Cpf, NomeCompleto ,Sexo , DataNascimento ,Peso ,Altura FROM Scp.dbo.ObterPacientesView";

            using (var connection = new SqlConnection(Runtime.ConnectionString))
            {
                connection.Open();

                return connection
                    .Query<PacientesResultado>(query);
            }
        }

        public IQueryable<Paciente> ObterPacientes()
        {
            return _context
                .Pacientes
                .AsNoTracking();
        }

        public void SalvarPaciente(Paciente paciente)
        {
            _context
                .Pacientes
                .Add(paciente);
        }

        public void Atualizar(Paciente paciente)
        {

            //Indica os campos que não sofreram alteração
            _context.Pacientes.Attach(paciente);
            _context.Entry(paciente).State = EntityState.Modified;
            _context.Entry(paciente).Property(c => c.Documento.Numero).IsModified = false;
            _context.SaveChanges();


        }

        public void Excluir(Paciente paciente)
        {
            _context.Entry(paciente).State = EntityState.Deleted;
        }

        public void Excluir(Guid id)
        {
            var paciente = _context.Pacientes.Find(id);
            _context.Entry(paciente).State = EntityState.Deleted;
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
