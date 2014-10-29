namespace Casando.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabela_De_Usuario_E_Perfil : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Perfil",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Guid = c.Guid(nullable: false),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
            DropTable("dbo.Perfil");
        }
    }
}
