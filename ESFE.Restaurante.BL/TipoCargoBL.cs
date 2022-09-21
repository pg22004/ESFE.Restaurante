using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------------
using ESFE.Restaurante.EN;
using ESFE.Restaurante.DAL;

namespace ESFE.Restaurante.BL
{
   public class TipoCargoBL
    {
        public int GuardarTipoCargo(TipoCargoEN pTipoCargoEN)
        {
            return TipoCargoDAL.GuardarTipoCargo(pTipoCargoEN);
        }
        public int EliminarTipoCargo(TipoCargoEN pTipoCargoEN)
        {
            return TipoCargoDAL.EliminarTipoCargo(pTipoCargoEN);
        }
        public int ModificarTipoCargo(TipoCargoEN pTipoCargoEN)
        {
            return TipoCargoDAL.ModificarTipoCargo(pTipoCargoEN);
        }
        public List<TipoCargoEN> MostrarTipoCargo()
        {
            return TipoCargoDAL.MostrarTipoCargo();
        }
    }
}
