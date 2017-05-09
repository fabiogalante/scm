using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Corcam.Scp.Dominio.Entidades;

namespace Corcam.Scp.Infra.Mapeamento
{
    public class PacienteMap : EntityTypeConfiguration<Paciente>
    {
        public PacienteMap()
        {
            //CPF + Nome Completo + Sexo + Data de Nascimento + Peso + Altura


            ToTable("Paciente");
            HasKey(x => x.Id);

            Property(x => x.Documento.Numero).IsRequired().HasMaxLength(11).IsFixedLength().HasColumnName("Cpf")
                .HasColumnAnnotation("Index", new IndexAnnotation(new[] {
                        new IndexAttribute("Index") { IsUnique = true }
                    }
                ));
            
            Property(x => x.Nome.PrimeiroNome).IsRequired().HasMaxLength(60).HasColumnName("Nome");
            Property(x => x.Nome.SobreNome).IsRequired().HasMaxLength(60).HasColumnName("Sobrenome");
            Property(x => x.Dados.Sexo).IsRequired().HasColumnName("Sexo");
            Property(x => x.Dados.DataNascimento).IsRequired().HasColumnName("DataNascimento");
            Property(x => x.Dados.Peso).IsRequired().HasPrecision(6,2).HasColumnName("Peso");
            Property(x => x.Dados.Altura).IsRequired().HasPrecision(6,2).HasColumnName("Altura");

        }
    }
}
