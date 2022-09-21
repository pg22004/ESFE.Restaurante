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
    public partial class ModificarCliente : Form
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");

        ClienteEN _clienteEN = new ClienteEN();
        ClienteBL _clienteBL = new ClienteBL();
        public ModificarCliente()
        {
            InitializeComponent();
        }
        public void CargarGrid()
        {
            AdministarCliente Adminc = new AdministarCliente();
            SqlCommand comando = new SqlCommand("Select * from Cliente", _conn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            Adminc.dgCliente.DataSource = tabla;
        }
        private void ModificarCliente_Load(object sender, EventArgs e)
        {
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            _clienteEN.Nombre = txtNombre.Text;
            _clienteEN.Apellido = txtApellido.Text;
            _clienteEN.Dui = txtDui.Text;
            _clienteEN.Gmail = txtGmail.Text;
            _clienteEN.Telefono = txtTelefono.Text;
            _clienteEN.Id = Convert.ToInt64(txtCodCli.Text);
            _clienteBL.ModificarCliente(_clienteEN);
            CargarGrid();

            txtNombre.Clear();
            txtApellido.Clear();
            txtDui.Clear();
            txtGmail.Clear();
            txtTelefono.Clear();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            _clienteEN.Nombre = txtNombre.Text;
            _clienteEN.Apellido = txtApellido.Text;
            _clienteEN.Dui = txtDui.Text;
            _clienteEN.Gmail = txtGmail.Text;
            _clienteEN.Telefono = txtTelefono.Text;
            _clienteEN.Id = Convert.ToInt64(txtCodCli.Text);
            _clienteBL.EliminarCliente(_clienteEN);
            CargarGrid();

            txtNombre.Clear();
            txtApellido.Clear();
            txtDui.Clear();
            txtGmail.Clear();
            txtTelefono.Clear();
        }
    }
}
