using System.Data.Entity;
using Corcam.Scp.Compartilhado;
using Corcam.Scp.Dominio.Entidades;
using Corcam.Scp.Infra.Mapeamento;

namespace Corcam.Scp.Infra.Contexto
{
    public class ScpDataContext : DbContext
    {

        //Seta Infra Default
        //Enable-Migrations
        //Add-Migration v1
        //Update-Database



        public ScpDataContext() : base(Runtime.ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Paciente> Pacientes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PacienteMap());
        }
    }



}
