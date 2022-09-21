using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.Restaurante.EN
{
    public class PedidoComidaEN
    {

        public Int64 Id { get; set; }
        public Int32 IdComida { get; set; }
        public Int64 IdPedido { get; set; }
        public Int32 CantidadPlatos { get; set; }
        public  Double TotalPagar { get; set; }
    }
}
