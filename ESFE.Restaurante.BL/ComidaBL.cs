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
    public class ComidaBL
    {
        ComidaDAL objd = new ComidaDAL();
        public List<ComidaEN> MostrarComida()
        {
            return ComidaDAL.MostrarComida();
        }
        public int ModificarComida(ComidaEN pComidaEN)
        {
            return ComidaDAL.ModificarComida(pComidaEN);
        }
        public  int EliminarComida(ComidaEN pComidaEN)
        {
            return ComidaDAL.EliminarComida(pComidaEN);
        }
        public int GuardarComida(ComidaEN pComidaEN)
        {
            return ComidaDAL.GuardarComida(pComidaEN);
        }
        public DataTable BuscarComida(ComidaEN pComidaEN)
        {
            return objd.BuscarComida(pComidaEN);
        }
    }
}
