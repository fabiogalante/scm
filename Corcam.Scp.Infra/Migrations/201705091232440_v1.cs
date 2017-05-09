namespace Corcam.Scp.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Cpf = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        Nome = c.String(nullable: false, maxLength: 60),
                        Sobrenome = c.String(nullable: false, maxLength: 60),
                        Sexo = c.Int(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Peso = c.Decimal(nullable: false, precision: 6, scale: 2),
                        Altura = c.Decimal(nullable: false, precision: 6, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Paciente");
        }
    }
}
