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
    public class EmpleadoDAL
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");

        public static List<EmpleadoEN> MostrarEmpleado()
        {
            List<EmpleadoEN> _Lista = new List<EmpleadoEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("SP_MostrarEmpleado", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _Lista.Add(new EmpleadoEN
                    {
                        Id = _reader.GetInt32(0),
                        Nombre = _reader.GetString(1),
                        SegundoNombre = _reader.GetString(2),
                        Apellido = _reader.GetString(3),
                        SegundoApellido = _reader.GetString(4),
                        Gmail = _reader.GetString(5),
                        Telefono = _reader.GetString(6),
                        IdTipoCargo = _reader.GetByte(7),

                    });
                }
                _conn.Close();
            }
            return _Lista;
        }
        public DataTable BuscarEmpleado(EmpleadoEN pEmpleadoEN)
        {
            SqlCommand _comando = new SqlCommand("SP_BuscarEmpleado", _conn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@Id", pEmpleadoEN.Id);
            SqlDataAdapter adaptador = new SqlDataAdapter(_comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;


        }
        public static int ModificarEmpleado(EmpleadoEN pEmpleadoEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando =
                new SqlCommand("SP_ModificarEmpleado", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pEmpleadoEN.Id));
                _comando.Parameters.Add(new SqlParameter("@Nombre", pEmpleadoEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@SegundoNombre", pEmpleadoEN.SegundoNombre));
                _comando.Parameters.Add(new SqlParameter("@Apellido", pEmpleadoEN.Apellido));
                _comando.Parameters.Add(new SqlParameter("@SegundoApellido", pEmpleadoEN.SegundoApellido));
                _comando.Parameters.Add(new SqlParameter("@Gmail", pEmpleadoEN.Gmail));
                _comando.Parameters.Add(new SqlParameter("@Telefono", pEmpleadoEN.Telefono));
                _comando.Parameters.Add(new SqlParameter("@IdTipoCargo", pEmpleadoEN.IdTipoCargo));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int EliminarEmpleado(EmpleadoEN pEmpleadoEN)
        {

            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando =
                new SqlCommand("SP_EliminarEmpleado", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pEmpleadoEN.Id));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
        public static int GuardarEmpleado(EmpleadoEN pEmpleadoEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SQLServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("SP_GuardarEmpleado", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Nombre", pEmpleadoEN.Nombre));
                _comando.Parameters.Add(new SqlParameter("@SegundoNombre", pEmpleadoEN.SegundoNombre));
                _comando.Parameters.Add(new SqlParameter("@Apellido", pEmpleadoEN.Apellido));
                _comando.Parameters.Add(new SqlParameter("@SegundoApellido", pEmpleadoEN.SegundoApellido));
                _comando.Parameters.Add(new SqlParameter("@Gmail", pEmpleadoEN.Gmail));
                _comando.Parameters.Add(new SqlParameter("@Telefono", pEmpleadoEN.Telefono));
                _comando.Parameters.Add(new SqlParameter("@IdTipoCargo", pEmpleadoEN.IdTipoCargo));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;

            }
        }
    }
}
