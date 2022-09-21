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
    public class PedidoBebidaBL
    {
        PedidoBebidaDAL objP = new PedidoBebidaDAL();
        public int GuardarPedidoBebida(PedidoBebidaEN pPedidoBebidaEN)
        {
            return PedidoBebidaDAL.GuardarPedidoBebida(pPedidoBebidaEN);
        }
        public  int EliminarPedidoBebida(PedidoBebidaEN pPedidoBebidaEN)
        {
            return PedidoBebidaDAL.EliminarPedidoBebida(pPedidoBebidaEN);
        }
        public int ModificarPedidoBebida(PedidoBebidaEN pPedidoBebidaEN)
        {
            return PedidoBebidaDAL.ModificarPedidoBebida(pPedidoBebidaEN);
        }
        public List<PedidoBebidaEN> MostrarPedidoBebida()
        {
            return PedidoBebidaDAL.MostrarPedidoBebida();
        }
       public DataTable BuscarPedidoBebida(PedidoBebidaEN pPedidoBebidaEN)
        {
            return objP.BuscarPedidoBebida(pPedidoBebidaEN);
        }

    }
}
