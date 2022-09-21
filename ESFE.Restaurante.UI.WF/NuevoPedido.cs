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
    public partial class NuevoPedido : Form
    {
        SqlConnection _conn = new SqlConnection();

        PedidoEN _pedidoEN = new PedidoEN();
        PedidoBL _pedidoBL = new PedidoBL();
        ClienteBL _clienteBL = new ClienteBL();
        EmpleadoBL _empleadoBL = new EmpleadoBL();

        public NuevoPedido()
        {
            InitializeComponent();
            cbCliente.DataSource = _clienteBL.MostrarCliente();
            cbCliente.DisplayMember = "Nombre";
            cbCliente.ValueMember = "Id";

            cbEmpleado.DataSource = _empleadoBL.MostrarEmpleado();
            cbEmpleado.DisplayMember = "Nombre";
            cbEmpleado.ValueMember = "Id";
        }
        public void CargarGrid()
        {
            AdministrarPedido Adminp = new AdministrarPedido();
            SqlCommand comando = new SqlCommand("Select * from Pedido", _conn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            Adminp.dgPedido.DataSource = tabla;
        }

      

        private void btnguardarP_Click(object sender, EventArgs e)
        {
            _pedidoEN.IdCliente =Convert.ToInt64(txtIdCliente.Text);
            _pedidoEN.IdEmpleado= Convert.ToInt32(txtIdEmpleado.Text);
            _pedidoEN.FechaHora = Convert.ToDateTime(txtFH.Text);
            _pedidoBL.GuardarPedido(_pedidoEN);
            CargarGrid();

            txtIdCliente.Clear();
            txtIdEmpleado.Clear();
            txtFH.Clear();
       
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            _pedidoEN.IdCliente = Convert.ToInt64(txtIdCliente.Text);
            _pedidoEN.IdEmpleado = Convert.ToInt32(txtIdEmpleado.Text);
            _pedidoEN.FechaHora = Convert.ToDateTime(txtFH.Text);
            _pedidoEN.Id = Convert.ToInt64(txtCodPed);
            _pedidoBL.EliminarPedido(_pedidoEN);
            CargarGrid();

            txtIdCliente.Clear();
            txtIdEmpleado.Clear();
            txtFH.Clear();
            txtCodPed.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            _pedidoEN.IdCliente = Convert.ToInt64(txtIdCliente.Text);
            _pedidoEN.IdEmpleado = Convert.ToInt32(txtIdEmpleado.Text);
            _pedidoEN.FechaHora = Convert.ToDateTime(txtFH.Text);
            _pedidoEN.Id = Convert.ToInt64(txtCodPed.Text);
            _pedidoBL.ModificarPedido(_pedidoEN);
            CargarGrid();

            txtIdCliente.Clear();
            txtIdEmpleado.Clear();
            txtFH.Clear();
            txtCodPed.Clear();
        }

        private void NuevoPedido_Load(object sender, EventArgs e)
        {
            if (txtCodPed.Text == "")
            {
                btnguardarP.Visible = true;
            }
            else
            {
                btnguardarP.Visible = false; ;
            }
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdCliente.Text = cbCliente.SelectedValue.ToString();
        }

        private void cbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdEmpleado.Text = cbEmpleado.SelectedValue.ToString();
        }
    }
}
