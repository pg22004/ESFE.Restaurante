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
    public class EmpleadoBL
    {
        EmpleadoDAL objd = new EmpleadoDAL();
        public List<EmpleadoEN> MostrarEmpleado()
        {
            return EmpleadoDAL.MostrarEmpleado();
        }
        public  int ModificarEmpleado(EmpleadoEN pEmpleadoEN)
        {
            return EmpleadoDAL.ModificarEmpleado(pEmpleadoEN);
        }
        public  int EliminarEmpleado(EmpleadoEN pEmpleadoEN)
        {
            return EmpleadoDAL.EliminarEmpleado(pEmpleadoEN);
        }
        public int GuardarEmpleado(EmpleadoEN pEmpleadoEN)
        {
            return EmpleadoDAL.GuardarEmpleado(pEmpleadoEN);
        }
        public DataTable BuscarEmpleado(EmpleadoEN pEmpleadoEN)
        {
            return objd.BuscarEmpleado(pEmpleadoEN);
        }
    }
}
