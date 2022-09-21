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
   public class PedidoComidaBL
   {
        PedidoComidaDAL objP = new PedidoComidaDAL();
        public int GuardarPedidoComida(PedidoComidaEN pPedidoComidaEN)
        {
            return PedidoComidaDAL.GuardarPedidoComida(pPedidoComidaEN);
        }
        public  int EliminarPedidoComida(PedidoComidaEN pPedidoComidaEN)
        {
            return PedidoComidaDAL.EliminarPedidoComida(pPedidoComidaEN);
        }
        public int ModificarPedidoComida(PedidoComidaEN pPedidoComidaEN)
        {
            return PedidoComidaDAL.ModificarPedidoComida(pPedidoComidaEN);
        }
        public List<PedidoComidaEN> MostrarPedidoComida()
        {
            return PedidoComidaDAL.MostrarPedidoComida();
        }
       public DataTable BuscarPedidoComida(PedidoComidaEN pPedidoComidaEN)
       {
            return objP.BuscarPedidoComida(pPedidoComidaEN);
       }

   }
}
