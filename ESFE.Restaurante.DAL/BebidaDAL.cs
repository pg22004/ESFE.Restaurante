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
    public class BebidaDAL
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");

        public static List<BebidaEN> MostrarBebida()
        {
            List<BebidaEN> _Lista = new List<BebidaEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("SP_MostrarBebida", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _Lista.Add(new BebidaEN
                    {
                        Id = _reader.GetInt32(0),
                        Nombre = _reader.GetString(1),
                        Descripcion = _reader.GetString(2),
                        Precio = _reader.GetDouble(3),
                        IdCategoriaBebida = _reader.GetByte(4)
                    });
                }
                _conn.Close();
            }
            return _Lista;
        }

       public DataTable BuscarBebida(BebidaEN pBebidaEN)
           {
           SqlCommand _comando = new SqlCommand("SP_BuscarBebida", _conn);
           _comando.CommandType = CommandType.StoredProcedure;
           _comando.Parameters.AddWithValue("@Nombre", pBebidaEN.Nombre);
           SqlDataAdapter adaptador = new SqlDataAdapter(_comando);
           DataTable tabla = new DataTable();
           adaptador.Fill(tabla);
           return tabla;


            }
        public static int ModificarBebida(BebidaEN pBebidaEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando =
                new SqlCommand("SP_ModificarBebida", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pBebidaEN.Id));
                _comando.Parameters.Add(new SqlParameter("@Nombre", pBebidaEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@Descripcion", pBebidaEN.Descripcion));
                _comando.Parameters.Add(new SqlParameter("@Precio", pBebidaEN.Precio));
                _comando.Parameters.Add(new SqlParameter("@IdCategoriaBebida", pBebidaEN.IdCategoriaBebida));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int EliminarBebida(BebidaEN pBebidaEN)
        {

            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando =
                new SqlCommand("SP_EliminarBebida", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pBebidaEN.Id));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int GuardarBebida(BebidaEN pBebidaEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("SP_GuardarBebida", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Nombre", pBebidaEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@Descripcion", pBebidaEN.Descripcion));
                _comando.Parameters.Add(new SqlParameter("@Precio", pBebidaEN.Precio));
                _comando.Parameters.Add(new SqlParameter("@IdCategoriaBebida", pBebidaEN.IdCategoriaBebida));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;

            }
        }
    }
}
