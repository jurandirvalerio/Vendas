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
		modal: true,
		width: 400
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

sistemaJS.fecharModal = function() {
	$("#dialog").dialog("close");
	$("#dialog").remove();
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

sistemaJS.guid = function () {
	function s4() {
		return Math.floor((1 + Math.random()) * 0x10000)
			.toString(16)
			.substring(1);
	}
	return s4() + s4() + '-' + s4() + '-' + s4() + '-' + s4() + '-' + s4() + s4() + s4();
}