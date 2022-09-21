using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------------
using ESFE.Restaurante.EN;
using ESFE.Restaurante.DAL;
using System.Data;

namespace ESFE.Restaurante.BL
{
    public class PedidoBL
    {
       PedidoDAL objd = new PedidoDAL();
        public int GuardarPedido(PedidoEN pPedidoEN)
        {
            return PedidoDAL.GuardarPedido(pPedidoEN);
        }
        public  int EliminarPedido(PedidoEN pPedidoEN)
        {
            return PedidoDAL.EliminarPedido(pPedidoEN);
        }
        public int ModificarPedido(PedidoEN pPedidoEN)
        {
            return PedidoDAL.ModificarPedido(pPedidoEN);
        }
        public List<PedidoEN> MostrarPedido()
        {
            return PedidoDAL.MostrarPedido();
        }
        public DataTable BuscarPedido(PedidoEN pPedidoEN)
        {
            return objd.BuscarPedido(pPedidoEN);
        }
    }
}
