using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------------
using System.Data;
using ESFE.Restaurante.EN;
using ESFE.Restaurante.DAL;

namespace ESFE.Restaurante.BL
{
    public class BebidaBL
    {
       BebidaDAL objd = new BebidaDAL();
        public List<BebidaEN> MostrarBebida()
        {
            return BebidaDAL.MostrarBebida();
        }
        public  int ModificarBebida(BebidaEN pBebidaEN)
        {
            return BebidaDAL.ModificarBebida(pBebidaEN);
        }
        public  int EliminarBebida(BebidaEN pBebidaEN)
        {
            return BebidaDAL.EliminarBebida(pBebidaEN);
        }
        public int GuardarBebida(BebidaEN pBebidaEN)
        {
            return BebidaDAL.GuardarBebida(pBebidaEN);
        }
        public DataTable BuscarBebida(BebidaEN pBebidaEN)
        {
            return objd.BuscarBebida(pBebidaEN);
        }
    }
}
