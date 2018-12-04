var clienteJS = clienteJS || {};

clienteJS.CONTROLLER = "/cliente/";
clienteJS.ID_EMAIL = "#email";
clienteJS.ID_TELEFONE = "#telefone";
clienteJS.ID_DATA = "#dataNascimento";

clienteJS.salvar = function () {

	var _codigo = sistemaJS.urlParam("codigo");
	var _inclusao = _codigo === null;
	var _urlCadastro = _inclusao ? "incluir" : "alterar";

	var _urlCompletaCadastro = serviceBaseUrl + clienteJS.CONTROLLER + _urlCadastro;

	var _preencherCliente = function () {
		var cliente = {
			Nome: $("#nome").val(),
			Email: $(clienteJS.ID_EMAIL).val(),
			Telefone: $(clienteJS.ID_TELEFONE).val(),
			DataNascimento: $(clienteJS.ID_DATA).val()
		};

		if (!_inclusao) { cliente.Codigo = _codigo; }
		return cliente;
	};

	var _done = function(data) {
		if (data.resultado) {
			window.location = serviceBaseUrl + clienteJS.CONTROLLER + "listar";
		} else {
			sistemaJS.exibirMensagem(data.mensagem);
		}
	};

	$.post(_urlCompletaCadastro, _preencherCliente()).done(_done);
};

clienteJS.atribuirEventos = function() {
	$("#salvar").click(clienteJS.salvar);
};

clienteJS.atribuirMascaras = function () {

	$(clienteJS.ID_DATA).val($(clienteJS.ID_DATA).val().slice(0,10));
	$(clienteJS.ID_DATA).datepicker({
		dateFormat: "dd/mm/yy",
		timepicker: false,
		defaultDate: new Date()
	});

	$(clienteJS.ID_TELEFONE).mask('(00) 0000-00009');
	$(clienteJS.ID_TELEFONE).blur(function (event) {
		if ($(this).val().length == 15) {
			$(clienteJS.ID_TELEFONE).mask('(00) 00000-0009');
		} else {
			$(clienteJS.ID_TELEFONE).mask('(00) 0000-00009');
		}
	});
};

$(document).ready(function () {
	clienteJS.atribuirMascaras();
	clienteJS.atribuirEventos();
});