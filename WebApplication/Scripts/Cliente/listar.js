var clienteJS = clienteJS || {};

clienteJS.CONTROLLER = "/cliente/";

clienteJS.excluir = function (e) {

	var _urlCompletaExclusao = serviceBaseUrl + clienteJS.CONTROLLER + "excluir";

	var _preencherCliente = function () {
		return {
			codigo: $(e.currentTarget).data('codigo'),
		};
	};

	var _done = function (data) {
		if (data.resultado) {
			window.location = serviceBaseUrl + clienteJS.CONTROLLER + "listar";
		} else {
			sistemaJS.exibirMensagem(data.mensagem);
		}
	};

	var _excluir = function() {
		$.ajax({
			method: 'post',
			url: _urlCompletaExclusao,
			data: _preencherCliente()
		}).done(_done);
	};

	sistemaJS.exibirPergunta("Confirmar a exclusão?", _excluir);
};

clienteJS.atribuirEventos = function () {
	$(".excluir").click(clienteJS.excluir);
};

$(document).ready(function () {
	clienteJS.atribuirEventos();
});