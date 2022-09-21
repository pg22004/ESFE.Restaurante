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
    public class CategoriaBebidaBL
    {
        CategoriaBebidaDAL objd = new CategoriaBebidaDAL();
        public int GuardarCategoriaBebida(CategoriaBebidaEN pCategoriaBebidaEN)
        {
            return CategoriaBebidaDAL.GuardarCategoriaBebida(pCategoriaBebidaEN);
        }
        public  int EliminarCategoriaBebida(CategoriaBebidaEN pCategoriaBebidaEN)
        {
            return CategoriaBebidaDAL.EliminarCategoriaBebida(pCategoriaBebidaEN);
        }
        public  int ModificarCategoriaBebida(CategoriaBebidaEN pCategoriaBebidaEN)
        {
            return CategoriaBebidaDAL.ModificarCategoriaBebida(pCategoriaBebidaEN);
        }
        public List<CategoriaBebidaEN> MostrarCategoriaBebida()
        {
            return CategoriaBebidaDAL.MostrarCategoriaBebida();
        }

        public DataTable BuscarCategoriaBebida(CategoriaBebidaEN pCategoriaBebidaEN)
        {
            return objd.BuscarCategoriaBebida(pCategoriaBebidaEN);
        }
    }
}
