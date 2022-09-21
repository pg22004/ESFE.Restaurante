using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---------------------------------------------------
using ESFE.Restaurante.EN;
using System.Data;
using System.Data.SqlClient;

namespace ESFE.Restaurante.DAL
{
    public class ClienteDAL
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");

        public static List<ClienteEN> ValidarCliente(ClienteEN pclienteEN)
        {
            List<ClienteEN> _Lista = new List<ClienteEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("ValidarCliente", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Nombre", pclienteEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@Apellido", pclienteEN.Apellido));
                _comando.Parameters.Add(new SqlParameter("@Dui", pclienteEN.Dui));
                _comando.Parameters.Add(new SqlParameter("@Gmail", pclienteEN.Gmail));
                _comando.Parameters.Add(new SqlParameter("@Telefono", pclienteEN.Telefono));
                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _Lista.Add(new ClienteEN
                    {                    
                        Nombre = _reader.GetString(0),
                        Apellido = _reader.GetString(1),
                        Dui = _reader.GetString(2),
                        Gmail = _reader.GetString(3),
                        Telefono = _reader.GetString(4),
                        Id = _reader.GetInt64(5),
                    });
                }
                _conn.Close();
            }
            return _Lista;
        }

        public static List<ClienteEN> MostrarCliente()
        {
            List<ClienteEN> _Lista = new List<ClienteEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("SP_MostrarCliente", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _Lista.Add(new ClienteEN
                    {
                        Id = _reader.GetInt64(0),
                        Nombre = _reader.GetString(1),
                        Apellido = _reader.GetString(2),
                        Dui = _reader.GetString(3),
                        Gmail = _reader.GetString(4),
                        Telefono = _reader.GetString(5),

                    });
                }
                _conn.Close();
            }
            return _Lista;
        }
       public DataTable BuscarCliente(ClienteEN pClienteEN)
        {
            SqlCommand _comando = new SqlCommand("SP_BuscarCliente", _conn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("Dui", pClienteEN.Dui);
            SqlDataAdapter adaptador = new SqlDataAdapter(_comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }
        public static int ModificarCliente(ClienteEN pClienteEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando =
                new SqlCommand("SP_ModificarCliente", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pClienteEN.Id));
                _comando.Parameters.Add(new SqlParameter("@Nombre", pClienteEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@Apellido", pClienteEN.Apellido));
                _comando.Parameters.Add(new SqlParameter("@Dui", pClienteEN.Dui));
                _comando.Parameters.Add(new SqlParameter("@Gmail", pClienteEN.Gmail));
                _comando.Parameters.Add(new SqlParameter("@Telefono", pClienteEN.Telefono));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int EliminarCliente(ClienteEN pClienteEN)
        {

            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando =
                new SqlCommand("SP_EliminarCliente", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pClienteEN.Id));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int GuardarCliente(ClienteEN pClienteEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("SP_GuardarCliente", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Nombre", pClienteEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@Apellido", pClienteEN.Apellido));
                _comando.Parameters.Add(new SqlParameter("@Dui", pClienteEN.Dui));
                _comando.Parameters.Add(new SqlParameter("@Gmail", pClienteEN.Gmail));
                _comando.Parameters.Add(new SqlParameter("@Telefono", pClienteEN.Telefono));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;

            }
        }
    }
}
