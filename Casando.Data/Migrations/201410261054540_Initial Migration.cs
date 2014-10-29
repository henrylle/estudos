namespace Casando.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Convidado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Endereco = c.String(),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        Presente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Presente", t => t.Presente_Id)
                .Index(t => t.Presente_Id);
            
            CreateTable(
                "dbo.Presente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Convidado", "Presente_Id", "dbo.Presente");
            DropIndex("dbo.Convidado", new[] { "Presente_Id" });
            DropTable("dbo.Presente");
            DropTable("dbo.Convidado");
        }
    }
}
