var produtoJS = produtoJS || {};

produtoJS.CONTROLLER = "/produto/";

produtoJS.excluir = function (e) {

	var _urlCompletaExclusao = serviceBaseUrl + produtoJS.CONTROLLER + "excluir";

	var _preencherProduto = function () {
		return {
			codigo: $(e.currentTarget).data('codigo'),
		};
	};

	var _done = function (data) {
		if (data.resultado) {
			window.location = serviceBaseUrl + produtoJS.CONTROLLER + "listar";
		} else {
			sistemaJS.exibirMensagem(data.mensagem);
		}
	};

	var _excluir = function() {
		$.post(_urlCompletaExclusao, _preencherProduto()).done(_done);
	};

	sistemaJS.exibirPergunta("Confirmar a exclusão?", _excluir);
};

produtoJS.atribuirEventos = function () {
	$(".excluir").click(produtoJS.excluir);
};

$(document).ready(function () {
	produtoJS.atribuirEventos();
});