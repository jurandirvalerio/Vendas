var vendaJS = vendaJS || {};

vendaJS.ID_PRECO_SUGERIDO = "#precoSugerido";
vendaJS.CONTROLLER = "/venda/";

vendaJS.selecionarCliente = function() {
	
	sistemaJS.exibirModal('<b>teste</b>');
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
	$("#salvar").click(vendaJS.salvar);
};

vendaJS.atribuirMascaras = function() {
	$(vendaJS.ID_PRECO_SUGERIDO).mask("##0,00", { reverse: true });
};

$(document).ready(function () {
	vendaJS.atribuirMascaras();
	vendaJS.atribuirEventos();
});