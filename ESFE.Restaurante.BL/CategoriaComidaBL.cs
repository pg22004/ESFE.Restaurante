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
    public class CategoriaComidaBL
    {
        CategoriaComidaDAL objd = new CategoriaComidaDAL();
        public int GuardarCategoriaComida(CategoriaComidaEN pCategoriaComidaEN)
        {
            return CategoriaComidaDAL.GuardarCategoriaComida(pCategoriaComidaEN);
        }
        public int EliminarCategoriaComida(CategoriaComidaEN pCategoriaComidaEN)
        {
            return CategoriaComidaDAL.EliminarCategoriaComida(pCategoriaComidaEN);
        }
        public  int ModificarCategoriaComida(CategoriaComidaEN pCategoriaComidaEN)
        {
            return CategoriaComidaDAL.ModificarCategoriaComida(pCategoriaComidaEN);
        }
        public List<CategoriaComidaEN> MostrarCategoriaComida()
        {
            return CategoriaComidaDAL.MostrarCategoriaComida();
        }
        public DataTable BuscarCategoriaComida(CategoriaComidaEN pCategoriaComidaEN)
        {
            return objd.BuscarCategoriaComida(pCategoriaComidaEN);
        }
    }
}
