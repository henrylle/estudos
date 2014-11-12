namespace Casando.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajuste_Tabela_CotacaoPresente : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CotacaoPresente", name: "Presente_Id", newName: "PresenteId");
            RenameIndex(table: "dbo.CotacaoPresente", name: "IX_Presente_Id", newName: "IX_PresenteId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CotacaoPresente", name: "IX_PresenteId", newName: "IX_Presente_Id");
            RenameColumn(table: "dbo.CotacaoPresente", name: "PresenteId", newName: "Presente_Id");
        }
    }
}
