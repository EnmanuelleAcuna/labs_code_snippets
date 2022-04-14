// AJAX
// Manejar error personalizado enviado desde el controlador a AJAX 

// Código del controlador: 
return new HttpStatusCodeResult(410, "Unable to find customer.") 

// Código AJAX: 
function callAJAX() {
	$.ajax(
		{
			url:'/home/deleteCustomer',
			data: {id: "A123"},
			success: function (result) {//handle successful execution
			}, 
	  		error: function (xhr, httpStatusMessage, customErrorMessage) { 
				if (xhr.status === 410) { 
		  			alert(customErrorMessage);
				}
			}
		});
}