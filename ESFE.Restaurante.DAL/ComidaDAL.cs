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
   public class ComidaDAL
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");
        public static List<ComidaEN> MostrarComida()
        {
            List<ComidaEN> _Lista = new List<ComidaEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("SP_MostrarComida", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _Lista.Add(new ComidaEN
                    {
                        Id = _reader.GetInt32(0),
                        Nombre = _reader.GetString(1),
                        Descripcion = _reader.GetString(2),
                        Precio = _reader.GetDouble(3),
                        IdCategoriaComida = _reader.GetByte(4)

                    }) ;
                }
                _conn.Close();
            }
            return _Lista;

        }
        public DataTable BuscarComida(ComidaEN pComidaEN)
        {
            SqlCommand _comando = new SqlCommand("SP_BuscarComida", _conn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@Nombre", pComidaEN.Nombre);
            SqlDataAdapter adaptador = new SqlDataAdapter(_comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;

        }
        public static int ModificarComida(ComidaEN pComidaEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando =
                new SqlCommand("SP_ModificarComida", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pComidaEN.Id));
                _comando.Parameters.Add(new SqlParameter("@Nombre", pComidaEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@Descripcion", pComidaEN.Descripcion));
                _comando.Parameters.Add(new SqlParameter("@Precio", pComidaEN.Precio));
                _comando.Parameters.Add(new SqlParameter("@IdCategoriaComida", pComidaEN.IdCategoriaComida));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int EliminarComida(ComidaEN pComidaEN)
        {

            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando =
                new SqlCommand("SP_EliminarComida", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pComidaEN.Id));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int GuardarComida(ComidaEN pComidaEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("SP_GuardarComida", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Nombre", pComidaEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@Descripcion", pComidaEN.Descripcion));
                _comando.Parameters.Add(new SqlParameter("@Precio", pComidaEN.Precio));
                _comando.Parameters.Add(new SqlParameter("@IdCategoriaComida", pComidaEN.IdCategoriaComida));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;

            }
        }
    }
}
