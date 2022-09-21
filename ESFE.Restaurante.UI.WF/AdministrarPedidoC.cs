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
    public partial class AdministrarPedidoC : Form
    {
        PedidoComidaEN _pedidoComidaEN = new PedidoComidaEN();
        PedidoComidaBL _pedidoComidaBL = new PedidoComidaBL();
        public AdministrarPedidoC()
        {
            InitializeComponent();
        }
        public void CargarGrid()
        {
            dgPedidoC.DataSource = _pedidoComidaBL.MostrarPedidoComida();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            NuevoPedidoC nuevoPedcF = new NuevoPedidoC();
            nuevoPedcF.btnModificar.Visible = false;
            nuevoPedcF.btneliminar.Visible = false;
            nuevoPedcF.Show();
        }

        private void AdministrarPedidoC_Load(object sender, EventArgs e)
        {

            CargarGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _pedidoComidaEN.Id = Convert.ToInt64(txtNombre.Text);
            DataTable tabla = new DataTable();
            tabla = _pedidoComidaBL.BuscarPedidoComida(_pedidoComidaEN);
            dgPedidoC.DataSource = tabla;
        }

        private void dgPedidoC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NuevoPedidoC np = new NuevoPedidoC();
            if (dgPedidoC.SelectedRows.Count > 0)
            {
                np.txtCodPc.Text = dgPedidoC.CurrentRow.Cells["Id"].Value.ToString();
                np.cbIdComida.Text = dgPedidoC.CurrentRow.Cells["IdComida"].Value.ToString();
                np.txtPedido.Text = dgPedidoC.CurrentRow.Cells["IdPedido"].Value.ToString();
                np.txtCP.Text = dgPedidoC.CurrentRow.Cells["CantidadPlatos"].Value.ToString();
                np.txtTotal.Text = dgPedidoC.CurrentRow.Cells["TotalPagar"].Value.ToString();


            }
            np.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}
