using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.Restaurante.EN
{
    public class EmpleadoEN
    {
        public Int32 Id { get; set; }
        public string Nombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Apellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Gmail { get; set; }
        public string Telefono { get; set; }
        public byte IdTipoCargo { get; set; }
    }
}
