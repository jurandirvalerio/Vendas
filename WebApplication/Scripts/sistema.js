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
	$("#dialog").html(texto);
	$("#dialog").dialog({
		close: function (event, ui) { $("#dialog").html(''); },
		closeOnEscape: true,
		modal: true
	});
};