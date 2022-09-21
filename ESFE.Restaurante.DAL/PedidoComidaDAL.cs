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
    public class PedidoComidaDAL
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");
        public static int GuardarPedidoComida(PedidoComidaEN pPedidoComidaEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("SP_GuardarPedidoComida", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@IdComida", pPedidoComidaEN.IdComida));
                _comando.Parameters.Add(new SqlParameter("@IdPedido", pPedidoComidaEN.IdPedido));
                _comando.Parameters.Add(new SqlParameter("@CantidadPlatos", pPedidoComidaEN.CantidadPlatos));
                _comando.Parameters.Add(new SqlParameter("@TotalPagar", pPedidoComidaEN.TotalPagar));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;

            }
        }
        public static int EliminarPedidoComida(PedidoComidaEN pPedidoComidaEN)
        {

            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando =
                new SqlCommand("SP_EliminarPedidoComida", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pPedidoComidaEN.Id));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int ModificarPedidoComida(PedidoComidaEN pPedidoComidaEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando =
                new SqlCommand("SP_ModificarPedidoComida", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pPedidoComidaEN.Id));
                _comando.Parameters.Add(new SqlParameter("@IdComida", pPedidoComidaEN.IdComida));
                _comando.Parameters.Add(new SqlParameter("@IdPedido", pPedidoComidaEN.IdPedido));
                _comando.Parameters.Add(new SqlParameter("@CantidadPlatos", pPedidoComidaEN.CantidadPlatos));
                _comando.Parameters.Add(new SqlParameter("@TotalPagar", pPedidoComidaEN.TotalPagar));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static List<PedidoComidaEN> MostrarPedidoComida()
        {
            List<PedidoComidaEN> _Lista = new List<PedidoComidaEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("SP_MostrarPedidoComida", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _Lista.Add(new PedidoComidaEN
                    {
                        Id = _reader.GetInt64(0),
                        IdComida = _reader.GetInt32(1),
                        IdPedido = _reader.GetInt64(2),
                        CantidadPlatos = _reader.GetInt32(3),
                        TotalPagar = _reader.GetDouble(4),


                    });
                }
                _conn.Close();
            }
            return _Lista;
        }
        public DataTable BuscarPedidoComida(PedidoComidaEN pPedidoComidaEN)
        {
            SqlCommand _comando = new SqlCommand("SP_BuscarPedidoComida", _conn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("Id", pPedidoComidaEN.Id);
            SqlDataAdapter adaptador = new SqlDataAdapter(_comando);
            DataTable tb = new DataTable();
            adaptador.Fill(tb);
            return tb;
        }


    }
}
