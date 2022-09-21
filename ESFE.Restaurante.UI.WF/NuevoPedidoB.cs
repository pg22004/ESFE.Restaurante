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
    public partial class NuevoPedidoB : Form
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");

        PedidoBebidaEN _pedidoBebidaEN = new PedidoBebidaEN();
        PedidoBebidaBL _pedidoBebidaBL = new PedidoBebidaBL();
        BebidaBL _BebidaBL = new BebidaBL();
        public NuevoPedidoB()
        {
            InitializeComponent();
            cbIdBebida.DataSource = _BebidaBL.MostrarBebida();
            cbIdBebida.DisplayMember = "Nombre";
            cbIdBebida.ValueMember = "Id";

        }
        public void CargarGrid()
        {
            AdministrarPedidoB Adminpb = new AdministrarPedidoB();
            SqlCommand comando = new SqlCommand("Select * from PedidoBebida", _conn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            Adminpb.dgPedidoB.DataSource = tabla;
        }

        private void NuevoPedidoB_Load(object sender, EventArgs e)
        {
            if (txtCodPb.Text == "")
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
            _pedidoBebidaEN.IdBebida = Convert.ToInt32(txtIdP.Text);
            _pedidoBebidaEN.IdPedido = Convert.ToInt64(txtCodP.Text);
            _pedidoBebidaEN.CantidadBebida = Convert.ToInt32(txtCantidadB.Text);
            _pedidoBebidaEN.TotalPagar = Convert.ToDouble(txtTotal.Text);
            _pedidoBebidaBL.GuardarPedidoBebida(_pedidoBebidaEN);
            CargarGrid();


            txtIdP.Clear();
            txtCantidadB.Clear();
            txtTotal.Clear();
            txtCodP.Clear();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            _pedidoBebidaEN.IdBebida = Convert.ToInt32(txtIdP.Text);
            _pedidoBebidaEN.IdPedido = Convert.ToInt64(txtCodP.Text);
            _pedidoBebidaEN.CantidadBebida = Convert.ToInt32(txtCantidadB.Text);
            _pedidoBebidaEN.TotalPagar = Convert.ToDouble(txtTotal.Text);
            _pedidoBebidaEN.Id = Convert.ToInt64(txtCodPb.Text);    
            _pedidoBebidaBL.EliminarPedidoBebida(_pedidoBebidaEN);
            CargarGrid();


            txtIdP.Clear();
            txtCantidadB.Clear();
            txtTotal.Clear();
            txtCodP.Clear();
            txtCodPb.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            _pedidoBebidaEN.IdBebida = Convert.ToInt32(txtIdP.Text);
            _pedidoBebidaEN.IdPedido = Convert.ToInt64(txtCodP.Text);
            _pedidoBebidaEN.CantidadBebida = Convert.ToInt32(txtCantidadB.Text);
            _pedidoBebidaEN.TotalPagar = Convert.ToDouble(txtTotal.Text);
            _pedidoBebidaEN.Id = Convert.ToInt64(txtCodPb.Text);
            _pedidoBebidaBL.ModificarPedidoBebida(_pedidoBebidaEN);
            CargarGrid();

            txtIdP.Clear();
            txtCantidadB.Clear();
            txtTotal.Clear();
            txtCodP.Clear();
            txtCodPb.Clear();
        }

        private void cbIdBebida_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdP.Text = cbIdBebida.SelectedValue.ToString();
        }
    }
}
