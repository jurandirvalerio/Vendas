namespace AcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Email = c.String(),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Venda",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        CodigoCliente = c.Int(nullable: false),
                        Cliente_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Codigo)
                .Index(t => t.Cliente_Codigo);
            
            CreateTable(
                "dbo.VendaItem",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        CodigoVenda = c.Int(nullable: false),
                        CodigoProduto = c.Int(nullable: false),
                        PrecoUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantidade = c.Int(nullable: false),
                        Produto_Codigo = c.Int(),
                        Venda_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Produto", t => t.Produto_Codigo)
                .ForeignKey("dbo.Venda", t => t.Venda_Codigo)
                .Index(t => t.Produto_Codigo)
                .Index(t => t.Venda_Codigo);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        PrecoSugerido = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendaItem", "Venda_Codigo", "dbo.Venda");
            DropForeignKey("dbo.VendaItem", "Produto_Codigo", "dbo.Produto");
            DropForeignKey("dbo.Venda", "Cliente_Codigo", "dbo.Cliente");
            DropIndex("dbo.VendaItem", new[] { "Venda_Codigo" });
            DropIndex("dbo.VendaItem", new[] { "Produto_Codigo" });
            DropIndex("dbo.Venda", new[] { "Cliente_Codigo" });
            DropTable("dbo.Produto");
            DropTable("dbo.VendaItem");
            DropTable("dbo.Venda");
            DropTable("dbo.Cliente");
        }
    }
}
