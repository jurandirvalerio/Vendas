var vendaJS = vendaJS || {};

vendaJS.ID_CODIGO_CLIENTE = "#codigoCliente";
vendaJS.NOME_CLIENTE = "#nomeCliente";
vendaJS.CONTROLLER = "/venda/";
vendaJS.ID_CODIGO_PRODUTO = "#codigoProduto";
vendaJS.DESCRICAO_PRODUTO = "#descricaoProduto";
vendaJS.PRECO_PRODUTO = "#precoProduto";
vendaJS.QUANTIDADE_PRODUTO = "#quantidadeProduto";
vendaJS.TABLE_BODY = "#itensVenda > tbody";

vendaJS.TEMPLATE_LINHA = "<tr data-guid='{5}'><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td><a class='excluirItemVenda' href='javascript: void (0)' data-codigo='{4} data-guid='{5}'>Excluir</a></td></tr>";

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
	$(vendaJS.QUANTIDADE_PRODUTO).val('1');
	sistemaJS.fecharModal();
};

vendaJS.excluirProduto = function(e) {
	$(e.currentTarget).closest('tr').remove();
};

vendaJS.produtoInvalidoParaAdicionar = function () {
	return $(vendaJS.ID_CODIGO_PRODUTO).val() === '' ||
		$(vendaJS.DESCRICAO_PRODUTO).val() === '' ||
		$(vendaJS.PRECO_PRODUTO).val() === '';
};

vendaJS.adicionarProduto = function () {

	if (vendaJS.produtoInvalidoParaAdicionar()) {
		sistemaJS.exibirMensagem('Preencha todos os campos para adicionar ao pedido');
		return;
	}

	var _atribuirEventosItemVenda = function() {
		$('.excluirItemVenda').click(vendaJS.excluirProduto);
	};

	var _calcularTotalLinha = function() {

		var precoProduto = $(vendaJS.PRECO_PRODUTO).val().replace(',', '.');
		var quantidadeProduto = $(vendaJS.QUANTIDADE_PRODUTO).val();
		var total = parseFloat(precoProduto) * parseFloat(quantidadeProduto);
		return total.toFixed(2).replace('.', ',');
	};

	var _obterLinhaTemplateItemVenda = function() {
		var linha = vendaJS.TEMPLATE_LINHA;
		linha = linha.replace('{0}', $(vendaJS.DESCRICAO_PRODUTO).val());
		linha = linha.replace('{1}', $(vendaJS.PRECO_PRODUTO).val());
		linha = linha.replace('{2}', $(vendaJS.QUANTIDADE_PRODUTO).val());
		linha = linha.replace('{3}', _calcularTotalLinha());
		linha = linha.replace('{4}', $(vendaJS.ID_CODIGO_PRODUTO).val());
		linha = linha.replace('{5}', $(sistemaJS.guid()).val());
		return linha;
	};

	var _limparCamposProduto = function() {
		$(vendaJS.ID_CODIGO_PRODUTO).val('');
		$(vendaJS.DESCRICAO_PRODUTO).val('');
		$(vendaJS.PRECO_PRODUTO).val('');
		$(vendaJS.QUANTIDADE_PRODUTO).val('');
	};

	$(vendaJS.TABLE_BODY).append(_obterLinhaTemplateItemVenda);
	_limparCamposProduto();
	_atribuirEventosItemVenda();
};

vendaJS.semItensVenda = function() {
	return $(vendaJS.TABLE_BODY + ' > tr').length === 0;
};

vendaJS.semClienteSelecionado = function() {
	return $(vendaJS.ID_CODIGO_CLIENTE).val() === '0';
};

vendaJS.salvar = function () {

	if (vendaJS.semClienteSelecionado()) {
		sistemaJS.exibirMensagem('Selecione um cliente para venda');
		return;
	}

	if (vendaJS.semItensVenda()) {
		sistemaJS.exibirMensagem('Adicione pelos menos um produto para vender');
		return;
	}

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
	$('#adicionarProduto').click(vendaJS.adicionarProduto);
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