namespace Casando.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class N_Para_N_Convidado_E_Presente : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Convidado", "Presente_Id", "dbo.Presente");
            DropIndex("dbo.Convidado", new[] { "Presente_Id" });
            CreateTable(
                "dbo.PresenteConvidado",
                c => new
                    {
                        Presente_Id = c.Int(nullable: false),
                        Convidado_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Presente_Id, t.Convidado_Id })
                .ForeignKey("dbo.Presente", t => t.Presente_Id, cascadeDelete: true)
                .ForeignKey("dbo.Convidado", t => t.Convidado_Id, cascadeDelete: true)
                .Index(t => t.Presente_Id)
                .Index(t => t.Convidado_Id);
            
            DropColumn("dbo.Convidado", "Presente_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Convidado", "Presente_Id", c => c.Int());
            DropForeignKey("dbo.PresenteConvidado", "Convidado_Id", "dbo.Convidado");
            DropForeignKey("dbo.PresenteConvidado", "Presente_Id", "dbo.Presente");
            DropIndex("dbo.PresenteConvidado", new[] { "Convidado_Id" });
            DropIndex("dbo.PresenteConvidado", new[] { "Presente_Id" });
            DropTable("dbo.PresenteConvidado");
            CreateIndex("dbo.Convidado", "Presente_Id");
            AddForeignKey("dbo.Convidado", "Presente_Id", "dbo.Presente", "Id");
        }
    }
}
