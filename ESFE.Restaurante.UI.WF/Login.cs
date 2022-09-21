using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ESFE.Restaurante.UI.WF
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("Select Usuario, Contraseña from Acceso where Usuario = @vUsuario and Contraseña = @vContraseña", conexion);
            comando.Parameters.AddWithValue("@vUsuario", txtUsuario.Text);
            comando.Parameters.AddWithValue("@vContraseña", txtContraseña.Text);

            SqlDataReader lector = comando.ExecuteReader(); 
            if(lector.Read())
            {
                conexion.Close();
                ControlAdministrar frm = new ControlAdministrar();
                frm.ShowDialog();

                
            }

        }
    }
}
