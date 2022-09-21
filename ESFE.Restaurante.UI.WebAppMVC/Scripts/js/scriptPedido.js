function RegistroPedido() {
    var Pedido = {};
    Pedido.IdCliente = $("#IdCliente").val();
    Pedido.IdEmpleado = $("#IdEmpleado").val();
    Pedido.FechaHora = $("#FechaHora").val();
  

    $.ajax({
        type: 'POST',
        url: '/Pedido/GuardarPedido',
        data: '{pPedidoEN:' + JSON.stringify(Pedido) + '}',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var respuesta = data.Mensaje;
            alert(respuesta);
            window.location.href = '/Cliente/Menu';
        },
        error: function () {
            alert("Error al guardar");
        }
    });
}