var vendaJS = vendaJS || {};

vendaJS.ID_CODIGO_CLIENTE = "#codigoCliente";
vendaJS.NOME_CLIENTE = "#nomeCliente";
vendaJS.CONTROLLER = "/venda/";
vendaJS.ID_CODIGO_PRODUTO = "#codigoProduto";
vendaJS.DESCRICAO_PRODUTO = "#descricaoProduto";
vendaJS.PRECO_PRODUTO = "#precoProduto";

vendaJS.selecionouCliente = function(e) {
	$(vendaJS.ID_CODIGO_CLIENTE).val($(e.currentTarget).data('codigo'));
	$(vendaJS.NOME_CLIENTE).val($(e.currentTarget).data('nome'));
	sistemaJS.fecharModal();
};

vendaJS.selecionarCliente = function () {

	var _montarModal = function (html) {
		sistemaJS.exibirModal(html);
		vendaJS.atribuirEventosModalClientes();
	};

	$.get(serviceBaseUrl + vendaJS.CONTROLLER + 'selecionarClientes').done(_montarModal);
};

vendaJS.selecionarProduto = function () {

	var _montarModal = function (html) {
		sistemaJS.exibirModal(html);
		vendaJS.atribuirEventosModalProdutos();
	};

	$.get(serviceBaseUrl + vendaJS.CONTROLLER + 'selecionarProdutos').done(_montarModal);
};

vendaJS.selecionouProduto = function (e) {
	$(vendaJS.ID_CODIGO_PRODUTO).val($(e.currentTarget).data('codigo'));
	$(vendaJS.DESCRICAO_PRODUTO).val($(e.currentTarget).data('descricao'));
	$(vendaJS.PRECO_PRODUTO).val($(e.currentTarget).data('preco'));
	sistemaJS.fecharModal();
};

vendaJS.salvar = function () {

	var _codigo = sistemaJS.urlParam("codigo");
	var _inclusao = _codigo === null;
	var _urlCadastro = _inclusao ? "incluir" : "alterar";

	var _urlCompletaCadastro = serviceBaseUrl + vendaJS.CONTROLLER + _urlCadastro;

	var _preencherVenda = function () {
		var venda = {
			Descricao: $("#descricao").val(),
			PrecoSugerido: $(vendaJS.ID_PRECO_SUGERIDO).val()
		};

		if (!_inclusao) { venda.Codigo = _codigo; }
		return venda;
	};

	var _done = function(data) {
		if (data.resultado) {
			window.location = serviceBaseUrl + vendaJS.CONTROLLER + "listar";
		} else {
			sistemaJS.exibirMensagem(data.mensagem);
		}
	};

	$.post(_urlCompletaCadastro, _preencherVenda()).done(_done);
};

vendaJS.atribuirEventos = function() {
	$("#selecionarCliente").click(vendaJS.selecionarCliente);
	$("#selecionarProduto").click(vendaJS.selecionarProduto);
	$("#salvar").click(vendaJS.salvar);
};

vendaJS.atribuirEventosModalClientes = function() {
	$('.selecionouCliente').click(vendaJS.selecionouCliente);
};

vendaJS.atribuirEventosModalProdutos = function () {
	$('.selecionouProduto').click(vendaJS.selecionouProduto);
};

vendaJS.atribuirMascaras = function() {
	$(vendaJS.PRECO_PRODUTO).mask("##0,00", { reverse: true });
};

$(document).ready(function () {
	vendaJS.atribuirMascaras();
	vendaJS.atribuirEventos();
});