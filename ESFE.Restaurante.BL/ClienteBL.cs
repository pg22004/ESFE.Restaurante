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
    public class ClienteBL
    {
        ClienteDAL objC = new ClienteDAL();

        public List<ClienteEN> ValidarCliente(ClienteEN pclienteEN)
        {
            return ClienteDAL.ValidarCliente(pclienteEN);
        }
        public List<ClienteEN> MostrarCliente()
        {
            return ClienteDAL.MostrarCliente();
        }
        public  int ModificarCliente(ClienteEN pClienteEN)
        {
            return ClienteDAL.ModificarCliente(pClienteEN);
        }
        public  int EliminarCliente(ClienteEN pClienteEN)
        {
            return ClienteDAL.EliminarCliente(pClienteEN);
        }
        public  int GuardarCliente(ClienteEN pClienteEN)
        {
            return ClienteDAL.GuardarCliente(pClienteEN);
        }

        public DataTable BuscarCliente(ClienteEN pClienteEN)
        {
           return objC.BuscarCliente(pClienteEN);
        }
    }
}
