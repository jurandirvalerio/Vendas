namespace AcessoDados.Implementacoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correcao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Venda", "Cliente_Codigo", "dbo.Cliente");
            DropForeignKey("dbo.VendaItem", "Venda_Codigo", "dbo.Venda");
            DropForeignKey("dbo.VendaItem", "Produto_Codigo", "dbo.Produto");
            DropIndex("dbo.Venda", new[] { "Cliente_Codigo" });
            DropIndex("dbo.VendaItem", new[] { "Produto_Codigo" });
            DropIndex("dbo.VendaItem", new[] { "Venda_Codigo" });
            DropColumn("dbo.Venda", "CodigoCliente");
            DropColumn("dbo.VendaItem", "CodigoVenda");
            DropColumn("dbo.VendaItem", "CodigoProduto");
            RenameColumn(table: "dbo.Venda", name: "Cliente_Codigo", newName: "CodigoCliente");
            RenameColumn(table: "dbo.VendaItem", name: "Venda_Codigo", newName: "CodigoVenda");
            RenameColumn(table: "dbo.VendaItem", name: "Produto_Codigo", newName: "CodigoProduto");
            AlterColumn("dbo.Venda", "CodigoCliente", c => c.Int(nullable: false));
            AlterColumn("dbo.VendaItem", "CodigoProduto", c => c.Int(nullable: false));
            AlterColumn("dbo.VendaItem", "CodigoVenda", c => c.Int(nullable: false));
            CreateIndex("dbo.Venda", "CodigoCliente");
            CreateIndex("dbo.VendaItem", "CodigoVenda");
            CreateIndex("dbo.VendaItem", "CodigoProduto");
            AddForeignKey("dbo.Venda", "CodigoCliente", "dbo.Cliente", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.VendaItem", "CodigoVenda", "dbo.Venda", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.VendaItem", "CodigoProduto", "dbo.Produto", "Codigo", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendaItem", "CodigoProduto", "dbo.Produto");
            DropForeignKey("dbo.VendaItem", "CodigoVenda", "dbo.Venda");
            DropForeignKey("dbo.Venda", "CodigoCliente", "dbo.Cliente");
            DropIndex("dbo.VendaItem", new[] { "CodigoProduto" });
            DropIndex("dbo.VendaItem", new[] { "CodigoVenda" });
            DropIndex("dbo.Venda", new[] { "CodigoCliente" });
            AlterColumn("dbo.VendaItem", "CodigoVenda", c => c.Int());
            AlterColumn("dbo.VendaItem", "CodigoProduto", c => c.Int());
            AlterColumn("dbo.Venda", "CodigoCliente", c => c.Int());
            RenameColumn(table: "dbo.VendaItem", name: "CodigoProduto", newName: "Produto_Codigo");
            RenameColumn(table: "dbo.VendaItem", name: "CodigoVenda", newName: "Venda_Codigo");
            RenameColumn(table: "dbo.Venda", name: "CodigoCliente", newName: "Cliente_Codigo");
            AddColumn("dbo.VendaItem", "CodigoProduto", c => c.Int(nullable: false));
            AddColumn("dbo.VendaItem", "CodigoVenda", c => c.Int(nullable: false));
            AddColumn("dbo.Venda", "CodigoCliente", c => c.Int(nullable: false));
            CreateIndex("dbo.VendaItem", "Venda_Codigo");
            CreateIndex("dbo.VendaItem", "Produto_Codigo");
            CreateIndex("dbo.Venda", "Cliente_Codigo");
            AddForeignKey("dbo.VendaItem", "Produto_Codigo", "dbo.Produto", "Codigo");
            AddForeignKey("dbo.VendaItem", "Venda_Codigo", "dbo.Venda", "Codigo");
            AddForeignKey("dbo.Venda", "Cliente_Codigo", "dbo.Cliente", "Codigo");
        }
    }
}
