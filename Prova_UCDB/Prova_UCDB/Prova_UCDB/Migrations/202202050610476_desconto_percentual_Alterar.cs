namespace Prova_UCDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class desconto_percentual_Alterar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pedido", "DescontoPercentual", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pedido", "DescontoPercentual", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
