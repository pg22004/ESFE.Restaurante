using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.Restaurante.EN
{
    public class ComidaEN
    {
        public Int32 Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Double Precio { get; set; }
        public Byte IdCategoriaComida { get; set; }
    }
}
