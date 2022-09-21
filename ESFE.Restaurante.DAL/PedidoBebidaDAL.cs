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
    public class PedidoBebidaDAL
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");
        public static int GuardarPedidoBebida(PedidoBebidaEN pPedidoBebidaEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("SP_GuardarPedidoBebida", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@IdBebida", pPedidoBebidaEN.IdBebida));
                _comando.Parameters.Add(new SqlParameter("@IdPedido", pPedidoBebidaEN.IdPedido));
                _comando.Parameters.Add(new SqlParameter("@CantidadBebida", pPedidoBebidaEN.CantidadBebida));
                _comando.Parameters.Add(new SqlParameter("@TotalPagar", pPedidoBebidaEN.TotalPagar));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;

            }
        }
        public static int EliminarPedidoBebida(PedidoBebidaEN pPedidoBebidaEN)
        {

            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando =
                new SqlCommand("SP_EliminarPedidoBebida", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pPedidoBebidaEN.Id));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int ModificarPedidoBebida(PedidoBebidaEN pPedidoBebidaEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando =
                new SqlCommand("SP_ModificarPedidoBebida", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pPedidoBebidaEN.Id));
                _comando.Parameters.Add(new SqlParameter("@IdBebida", pPedidoBebidaEN.IdBebida));
                _comando.Parameters.Add(new SqlParameter("@IdPedido", pPedidoBebidaEN.IdPedido));
                _comando.Parameters.Add(new SqlParameter("@CantidadBebida", pPedidoBebidaEN.CantidadBebida));
                _comando.Parameters.Add(new SqlParameter("@TotalPagar", pPedidoBebidaEN.TotalPagar));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static List<PedidoBebidaEN> MostrarPedidoBebida()
        {
            List<PedidoBebidaEN> _Lista = new List<PedidoBebidaEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("SP_MostrarPedidoBebida", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _Lista.Add(new PedidoBebidaEN
                    {
                        Id = _reader.GetInt64(0),
                        IdBebida = _reader.GetInt32(1),
                        IdPedido = _reader.GetInt64(2),
                        CantidadBebida = _reader.GetInt32(3),
                        TotalPagar = _reader.GetDouble(4),


                    });
                }
                _conn.Close();
            }
            return _Lista;
        }
        public DataTable BuscarPedidoBebida(PedidoBebidaEN pPedidoBebidaEN)
        {
            SqlCommand _Comando = new SqlCommand("SP_BuscarPedidoBebida", _conn);
            _Comando.CommandType = CommandType.StoredProcedure;
            _Comando.Parameters.AddWithValue("Id", pPedidoBebidaEN.Id);
            SqlDataAdapter adaptador = new SqlDataAdapter(_Comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;

        }
    }
}
