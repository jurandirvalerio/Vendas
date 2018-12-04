var sistemaJS = sistemaJS || {};

sistemaJS.urlParam = function(parameter) {

	function getUrlVars() {
		var vars = {};
		var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi,
			function(m, key, value) {
				vars[key] = value;
			});
		return vars;
	}

	var urlparameter = null;
	if (window.location.href.indexOf(parameter) > -1) {
		urlparameter = getUrlVars()[parameter];
	}
	return urlparameter;
};

sistemaJS.exibirMensagem = function (texto) {
	$("html").append("<div id='dialog'></div>");
	$("#dialog").html(texto);
	$("#dialog").dialog({
		close: function (event, ui) { $("#dialog").remove(); },
		closeOnEscape: true,
		modal: true
	});
};

sistemaJS.exibirModal = function (html) {
	$("html").append("<div id='dialog'></div>");
	$("#dialog").html(html);
	$("#dialog").dialog({
		close: function (event, ui) { $("#dialog").remove(); },
		closeOnEscape: true,
		modal: true,
		height: 400,
		width: 600
	});
};

sistemaJS.exibirPergunta = function(texto, callbackSuccess) {

	$("html").append("<div id='dialog'></div>");
	$("#dialog").html(texto);
	$("#dialog").dialog({
		close: function (event, ui) { $("#dialog").remove(); },
		closeOnEscape: true,
		modal: true,
		buttons: {
			"Confirmar": function () {
				$("#dialog").remove();
				callbackSuccess();
			},
			"Cancelar": function () {
				$(this).dialog("close");
			}
		}
	});
}