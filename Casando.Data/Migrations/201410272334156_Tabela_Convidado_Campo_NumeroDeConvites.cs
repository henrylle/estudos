namespace Casando.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabela_Convidado_Campo_NumeroDeConvites : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Convidado", "NumeroConvites", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Convidado", "NumeroConvites");
        }
    }
}
