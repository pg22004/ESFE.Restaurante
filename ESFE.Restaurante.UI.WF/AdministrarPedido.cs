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
    public partial class AdministrarPedido : Form
    {
        SqlConnection _conn = new SqlConnection();
        PedidoEN _pedidoEN = new PedidoEN();
        PedidoBL _pedidoBL = new PedidoBL();

        public AdministrarPedido()
        {
            InitializeComponent();
        }
        public void CargarGrid()
        {
            dgPedido.DataSource = _pedidoBL.MostrarPedido();
        }

     

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            NuevoPedido nuevoPF = new NuevoPedido();
            nuevoPF.btnModificar.Visible = false;
            nuevoPF.btneliminar.Visible = false;
            nuevoPF.Show();

        }

        private void AdministrarPedido_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _pedidoEN.Id = Convert.ToInt64(txtNombre.Text);
            DataTable tabla = new DataTable();
            tabla = _pedidoBL.BuscarPedido(_pedidoEN);
            dgPedido.DataSource = tabla;
        }

        private void dgPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NuevoPedido nb = new NuevoPedido();
            if (dgPedido.SelectedRows.Count > 0)
            {
                nb.txtCodPed.Text = dgPedido.CurrentRow.Cells["Id"].Value.ToString();
                nb.txtIdCliente.Text = dgPedido.CurrentRow.Cells["IdCliente"].Value.ToString();
                nb.txtIdEmpleado.Text = dgPedido.CurrentRow.Cells["IdEmpleado"].Value.ToString();
                nb.txtFH.Text = dgPedido.CurrentRow.Cells["FechaHora"].Value.ToString();
               

            }
            nb.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrid();

        }
    }
}
