
function GuardarRegistro() {
    var Cliente = {};
    Cliente.Nombre = $("#NombreCliente").val();
    Cliente.Apellido = $("#ApellidoCliente").val();
    Cliente.Dui = $("#DuiCliente").val();
    Cliente.Gmail = $("#GmailCliente").val();
    Cliente.Telefono = $("#TelefonoCliente").val();

    $.ajax({
        type: 'POST',
        url: '/Cliente/GuardarCliente',
        data: '{pClienteEN:' + JSON.stringify(Cliente) + '}',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var respuesta = data.Mensaje;
            alert(respuesta);
           
        },
        error: function () {
            alert("Error al guardar");
        }
    });
}

function ClienteId() {
    var Cliente = {};
    Cliente.Nombre = $("#NombreCliente").val();
    Cliente.Apellido = $("#ApellidoCliente").val();
    Cliente.Dui = $("#DuiCliente").val();
    Cliente.Gmail = $("#GmailCliente").val();
    Cliente.Telefono = $("#TelefonoCliente").val();

    $.ajax({
        type: 'POST',
        url: '/Cliente/ClienteJs',
        data: '{pClienteEN:' + JSON.stringify(Cliente) + '}',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",

        success: function (data)
        {
            var respuesta = data.Mensaje;
            var CliId = data.ClienId;
            if (CliId > 0) {
                alert("Tu código es: " + CliId);
                window.location.href = '/Cliente/RPedido';
                document.getElementById('ClienteID').innerText = CliId;
            }
            else {
                alert(respuesta);
            }
        },
        error: function () {
            alert("Error al guardar");
        }
    });
}


//function BuscarCliente() {
   
//    var Dui = $.urlParam('Dui');
//    $.ajax({
//        type: 'POST',
//        url: '/Cliente/BuscarCliente',
//        dataType: 'json',
//        data: { dui: Dui },
//        success: function (data) {
//            $("#IdCliente").val(data.Id);
//            $("#NombreCliente").val(data.Nombre);
//            $("#ApellidoCliente").val(data.Apellido);
//            $("#DuiCliente").val(data.Dui);
//            $("#GmailCliente").val(data.Gmail);
//            $("#TelefonoCliente").val(data.Telefono);
//        },
//        error: function (ex) {
//            var r = jQuery.parseJSON(response.responseText);
//            alert("Messaje: " + r.Messaje);
//            alert("StackTrace: " + r.StackTrace);
//            alert("ExceptionType: " + r.ExceptionType);

//        }
//    });
//    return false;
//}

//function ActualizarCliente() {
//    var Cliente = {};
//    Cliente.Id = $("#IdCliente").val();
//    Cliente.Nombre = $("#NombreCliente").val();
//    Cliente.Apellido = $("#ApellidoCliente").val();
//    Cliente.Dui = $("#DuiCliente").val();
//    Cliente.Gmail = $("#GmailCliente").val();
//    Cliente.Telefono = $("#TelefonoCliente").val();

//    $.ajax({
//        type: 'POST',
//        url: '/Cliente/ModificarCliente',
//        data: '{pClienteEN:' + JSON.stringify(Cliente) + '}',
//        dataType: 'json',
//        contentType: "application/json; charset=utf-8",
//        success: function (data) {
//            var respuesta = data.Mensaje;
//            alert(respuesta);
           
//        },
//        error: function () {
//            alert("Error al guardar");
//        }
//    });
//}



    
    