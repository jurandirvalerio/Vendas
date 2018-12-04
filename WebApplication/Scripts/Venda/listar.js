var vendaJS = vendaJS || {};

vendaJS.CONTROLLER = "/venda/";

vendaJS.excluir = function (e) {

	var _urlCompletaExclusao = serviceBaseUrl + vendaJS.CONTROLLER + "excluir";

	var _preencherVenda = function () {
		return {
			codigo: $(e.currentTarget).data('codigo'),
		};
	};

	var _done = function (data) {
		if (data.resultado) {
			window.location = serviceBaseUrl + vendaJS.CONTROLLER + "listar";
		} else {
			sistemaJS.exibirMensagem(data.mensagem);
		}
	};

	var _excluir = function() {
		$.post(_urlCompletaExclusao, _preencherVenda()).done(_done);
	};

	sistemaJS.exibirPergunta("Confirmar a exclusão?", _excluir);
};

vendaJS.atribuirEventos = function () {
	$(".excluir").click(vendaJS.excluir);
};

$(document).ready(function () {
	vendaJS.atribuirEventos();
});