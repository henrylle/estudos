namespace Casando.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Alterando_Nome_Da_Coluna_NumeroConvites : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Convidado", "NumeroConvites", "NumeroDeExibiveis");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Convidado", "NumeroDeExibiveis", "NumeroConvites");

        }
    }
}
