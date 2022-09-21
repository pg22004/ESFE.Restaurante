using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---------------------------------------------------
using ESFE.Restaurante.EN;
using System.Data;
using System.Data.SqlClient;
//--------------------------------------------------

namespace ESFE.Restaurante.DAL
{
    public class PedidoDAL
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");
        public static int GuardarPedido(PedidoEN pPedidoEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("SP_GuardarPedido", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@IdCliente", pPedidoEN.IdCliente));
                _comando.Parameters.Add(new SqlParameter("@IdEmpleado", pPedidoEN.IdEmpleado));
                _comando.Parameters.Add(new SqlParameter("@FechaHora", pPedidoEN.FechaHora));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;

            }
        }
        public static int EliminarPedido(PedidoEN pPedidoEN)
        {

            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando =
                new SqlCommand("SP_EliminarPedido", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pPedidoEN.Id));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int ModificarPedido(PedidoEN pPedidoEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando =
                new SqlCommand("SP_ModificarPedido", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pPedidoEN.Id));
                _comando.Parameters.Add(new SqlParameter("@IdCliente", pPedidoEN.IdCliente));
                _comando.Parameters.Add(new SqlParameter("@IdEmpleado", pPedidoEN.IdEmpleado));
                _comando.Parameters.Add(new SqlParameter("@FechaHora", pPedidoEN.FechaHora));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static List<PedidoEN> MostrarPedido()
        {
            List<PedidoEN> _Lista = new List<PedidoEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("SP_MostrarPedido", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _Lista.Add(new PedidoEN
                    {
                        Id = _reader.GetInt64(0),
                        IdCliente = _reader.GetInt64(1),
                        IdEmpleado = _reader.GetInt32(2),
                        FechaHora = _reader.GetDateTime(3),

                    });
                }
                _conn.Close();
            }
            return _Lista;
        }
       public DataTable BuscarPedido(PedidoEN pPedidoEN)
        {
            SqlCommand _Comando = new SqlCommand("SP_BuscarPedido", _conn); 
           _Comando.CommandType = CommandType.StoredProcedure;
            _Comando.Parameters.AddWithValue("Id", pPedidoEN.Id);
            SqlDataAdapter adaptador = new SqlDataAdapter(_Comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;

        }
    }
}
