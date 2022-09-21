function RegistroPedidoB() {
    var PedidoBebida = {};
    PedidoBebida.IdBebida = $("#IdBebida").val();
    PedidoBebida.IdPedido = $("#IdPedido").val();
    PedidoBebida.CantidadBebida = $("#CantidadBebida").val();
    PedidoBebida.TotalPagar = $("#TotalPagar").val();


    $.ajax({
        type: 'POST',
        url: '/PedidoB/GuardarPedidoBebida',
        data: '{pPedidoBebidaEN:' + JSON.stringify(PedidoBebida) + '}',
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