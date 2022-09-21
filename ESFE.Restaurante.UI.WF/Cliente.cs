using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//-----------------------------
using ESFE.Restaurante.EN;
using ESFE.Restaurante.BL;
using System.Data.SqlClient;

namespace ESFE.Restaurante.UI.WF
{
    public partial class Cliente : Form
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");

        ClienteEN _clienteEN = new ClienteEN();
        ClienteBL _clienteBL = new ClienteBL();

        public Cliente()
        {
            InitializeComponent();
        }
        public void CargarGrid()
        {
           
        }
        private void btnGuardarC_Click(object sender, EventArgs e)
        {
            _clienteEN.Nombre = txtNombre.Text;
            _clienteEN.Apellido = txtApellido.Text;
            _clienteEN.Dui = txtDui.Text;
            _clienteEN.Gmail = txtGmail.Text;
            _clienteEN.Telefono = txtTelefono.Text;
            _clienteBL.GuardarCliente(_clienteEN);
            CargarGrid();

            txtNombre.Clear();
            txtApellido.Clear();
            txtDui.Clear();
            txtGmail.Clear();
            txtTelefono.Clear();
        }
    }
}
