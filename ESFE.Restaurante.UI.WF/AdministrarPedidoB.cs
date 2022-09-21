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
    public partial class AdministrarPedidoB : Form
    {
        PedidoBebidaEN _pedidoBebidaEN = new PedidoBebidaEN();
        PedidoBebidaBL _pedidoBebidaBL = new PedidoBebidaBL();
        public AdministrarPedidoB()
        {
            InitializeComponent();
        }
        public void CargarGrid()
        {
            dgPedidoB.DataSource = _pedidoBebidaBL.MostrarPedidoBebida();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevoPedidoB nuevoPebF = new NuevoPedidoB();
            nuevoPebF.btnModificar.Visible = false;
            nuevoPebF.btneliminar.Visible = false;
            nuevoPebF.Show();

        }

        private void AdministrarPedidoB_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _pedidoBebidaEN.Id = Convert.ToInt64(txtNombre.Text);
            DataTable tabla = new DataTable();
            tabla = _pedidoBebidaBL.BuscarPedidoBebida(_pedidoBebidaEN);
            dgPedidoB.DataSource = tabla;
        }

        private void dgPedidoB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NuevoPedidoB np = new NuevoPedidoB();
            if (dgPedidoB.SelectedRows.Count > 0)
            {
                np.txtCodPb.Text = dgPedidoB.CurrentRow.Cells["Id"].Value.ToString();
                np.cbIdBebida.Text = dgPedidoB.CurrentRow.Cells["IdBebida"].Value.ToString();
                np.txtCodP.Text = dgPedidoB.CurrentRow.Cells["IdPedido"].Value.ToString();
                np.txtCantidadB.Text = dgPedidoB.CurrentRow.Cells["CantidadBebida"].Value.ToString();
                np.txtTotal.Text = dgPedidoB.CurrentRow.Cells["TotalPagar"].Value.ToString();


            }
            np.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}
