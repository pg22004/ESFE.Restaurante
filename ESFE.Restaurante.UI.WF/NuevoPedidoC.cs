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
    public partial class NuevoPedidoC : Form
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");

        PedidoComidaEN _pedidoComidaEN = new PedidoComidaEN();
        PedidoComidaBL _pedidoComidaBL = new PedidoComidaBL();
        ComidaBL _ComidaBL = new ComidaBL();
        public NuevoPedidoC()
        {
            InitializeComponent();
            cbIdComida.DataSource = _ComidaBL.MostrarComida();
            cbIdComida.DisplayMember = "Nombre";
            cbIdComida.ValueMember = "Id";
        }
        public void CargarGrid()
        {
            AdministrarPedidoC Adminpc = new AdministrarPedidoC();
            SqlCommand comando = new SqlCommand("Select * from PedidoComida", _conn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            Adminpc.dgPedidoC.DataSource = tabla;
        }
        private void NuevoPedidoC_Load(object sender, EventArgs e)
        {
            if (txtCodPc.Text == "")
            {
                btnguardar.Visible = true;
            }
            else
            {
                btnguardar.Visible = false; ;
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {

            _pedidoComidaEN.IdComida= Convert.ToInt32(txtId.Text);
            _pedidoComidaEN.IdPedido = Convert.ToInt64(txtPedido.Text);
            _pedidoComidaEN.CantidadPlatos = Convert.ToInt32(txtCP.Text);
            _pedidoComidaEN.TotalPagar = Convert.ToDouble(txtTotal.Text);
            _pedidoComidaBL.GuardarPedidoComida(_pedidoComidaEN);
            CargarGrid();


            txtId.Clear();
            txtPedido.Clear();
            txtCP.Clear();
            txtTotal.Clear();

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
          
            _pedidoComidaEN.IdComida = Convert.ToInt32(txtId.Text);
            _pedidoComidaEN.IdPedido = Convert.ToInt64(txtPedido.Text);
            _pedidoComidaEN.CantidadPlatos = Convert.ToInt32(txtCP.Text);
            _pedidoComidaEN.TotalPagar = Convert.ToDouble(txtTotal.Text);
            _pedidoComidaEN.Id = Convert.ToInt64(txtCodPc.Text);
            _pedidoComidaBL.EliminarPedidoComida(_pedidoComidaEN);
            CargarGrid();

            txtCodPc.Clear();
            txtId.Clear();
            txtPedido.Clear();
            txtCP.Clear();
            txtTotal.Clear();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            _pedidoComidaEN.IdComida = Convert.ToInt32(txtId);
            _pedidoComidaEN.IdPedido = Convert.ToInt64(txtPedido.Text);
            _pedidoComidaEN.CantidadPlatos= Convert.ToInt32(txtCP.Text);
            _pedidoComidaEN.TotalPagar = Convert.ToDouble(txtTotal.Text);
            _pedidoComidaEN.Id = Convert.ToInt64(txtCodPc.Text);
            _pedidoComidaBL.ModificarPedidoComida(_pedidoComidaEN);
            CargarGrid();

            txtCodPc.Clear();
            txtId.Clear();
            txtPedido.Clear();
            txtCP.Clear();
            txtTotal.Clear();
        }

        private void cbIdComida_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtId.Text = cbIdComida.SelectedValue.ToString();
        }
    }
}
