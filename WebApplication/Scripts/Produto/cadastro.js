var produtoJS = produtoJS || {};

produtoJS.ID_PRECO_SUGERIDO = "#precoSugerido";
produtoJS.CONTROLLER = "/produto/";

produtoJS.salvar = function () {

	var _codigo = sistemaJS.urlParam("codigo");
	var _inclusao = _codigo === null;
	var _urlCadastro = _inclusao ? "incluir" : "alterar";

	var _urlCompletaCadastro = serviceBaseUrl + produtoJS.CONTROLLER + _urlCadastro;

	var _preencherProduto = function () {
		var produto = {
			Descricao: $("#descricao").val(),
			PrecoSugerido: $(produtoJS.ID_PRECO_SUGERIDO).val()
		};

		if (!_inclusao) { produto.Codigo = _codigo; }
		return produto;
	};

	var _done = function(data) {
		if (data.resultado) {
			window.location = serviceBaseUrl + produtoJS.CONTROLLER + "listar";
		} else {
			sistemaJS.exibirMensagem(data.mensagem);
		}
	};

	$.post(_urlCompletaCadastro, _preencherProduto()).done(_done);
};

produtoJS.atribuirEventos = function() {
	$("#salvar").click(produtoJS.salvar);
};

produtoJS.atribuirMascaras = function() {
	$(produtoJS.ID_PRECO_SUGERIDO).mask("##0,00", { reverse: true });
};

$(document).ready(function () {
	produtoJS.atribuirMascaras();
	produtoJS.atribuirEventos();
});