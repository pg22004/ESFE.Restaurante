function RegistroPedidoC() {
    var PedidoComida = {};
    PedidoComida.IdComida = $("#IdComida").val();
    PedidoComida.IdPedido = $("#IdPedido").val();
    PedidoComida.CantidadPlatos = $("#CantidadPlatos").val();
    PedidoComida.TotalPagar = $("#TotalPagar").val();


    $.ajax({
        type: 'POST',
        url: '/PedidoC/GuardarPedidoComida',
        data: '{pPedidoComidaEN:' + JSON.stringify(PedidoComida) + '}',
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