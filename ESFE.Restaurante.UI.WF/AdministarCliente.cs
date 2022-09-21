using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//--------------------------
using ESFE.Restaurante.EN;
using ESFE.Restaurante.BL;
using System.Data.SqlClient;

namespace ESFE.Restaurante.UI.WF
{
    public partial class AdministarCliente : Form
    {
       ClienteEN _clienteEN = new ClienteEN();
        ClienteBL _clienteBL = new ClienteBL();
        public AdministarCliente()
        {
            InitializeComponent();
        }
        public void CargarGrid()
        {
            dgCliente.DataSource = _clienteBL.MostrarCliente();
        }


        private void AdministarCliente_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void dgCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ModificarCliente nb = new ModificarCliente();
            if (dgCliente.SelectedRows.Count > 0)
            {
                nb.txtCodCli.Text = dgCliente.CurrentRow.Cells["Id"].Value.ToString();
                nb.txtNombre.Text = dgCliente.CurrentRow.Cells["Nombre"].Value.ToString();
                nb.txtApellido.Text = dgCliente.CurrentRow.Cells["Apellido"].Value.ToString();
                nb.txtDui.Text = dgCliente.CurrentRow.Cells["Dui"].Value.ToString();
                nb.txtGmail.Text = dgCliente.CurrentRow.Cells["Gmail"].Value.ToString();
                nb.txtTelefono.Text = dgCliente.CurrentRow.Cells["Telefono"].Value.ToString();

            }
            nb.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _clienteEN.Dui = txtNombre.Text;
            DataTable tb = new DataTable();
            tb = _clienteBL.BuscarCliente(_clienteEN);
            dgCliente.DataSource = tb;

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}
