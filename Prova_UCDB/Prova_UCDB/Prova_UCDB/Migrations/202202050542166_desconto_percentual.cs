namespace Prova_UCDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class desconto_percentual : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido", "DescontoPercentual", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedido", "DescontoPercentual");
        }
    }
}
