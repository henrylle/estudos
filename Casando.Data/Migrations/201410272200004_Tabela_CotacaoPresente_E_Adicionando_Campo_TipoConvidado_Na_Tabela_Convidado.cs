namespace Casando.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabela_CotacaoPresente_E_Adicionando_Campo_TipoConvidado_Na_Tabela_Convidado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Convidado", "TipoConvidado", c => c.Int(nullable: false));
            DropColumn("dbo.Presente", "Valor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Presente", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Convidado", "TipoConvidado");
        }
    }
}
