namespace Corcam.Scp.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Paciente", "Cpf", unique: true, name: "Index");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Paciente", "Index");
        }
    }
}
