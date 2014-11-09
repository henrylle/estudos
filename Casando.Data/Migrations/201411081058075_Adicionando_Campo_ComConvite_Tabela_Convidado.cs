namespace Casando.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionando_Campo_ComConvite_Tabela_Convidado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Convidado", "ComConvite", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Convidado", "ComConvite");
        }
    }
}
