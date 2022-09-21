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
    public partial class NuevaBebida : Form
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");

        BebidaEN _bebidaEN = new BebidaEN();
        BebidaBL _bebidaBL = new BebidaBL();
        CategoriaBebidaBL _categoriaBebidaBL = new CategoriaBebidaBL();    
        public NuevaBebida()
        {
            InitializeComponent();
           
            cbCategoria.DataSource = _categoriaBebidaBL.MostrarCategoriaBebida();
            cbCategoria.DisplayMember = "Nombre";
            cbCategoria.ValueMember = "Id";
        }
        public void CargarGrid()
        {
            AdministrarBebida Adminb = new AdministrarBebida();
            SqlCommand comando = new SqlCommand("Select * from Bebida", _conn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            Adminb.dgMostrarBebida.DataSource = tabla;
        }

        private void NuevaBebida_Load(object sender, EventArgs e)
        {
            if (txtCodB.Text == "")
            {
                btnGuardarB.Visible = true;
            }
            else
            {
                btnGuardarB.Visible = false; ;
            }
        }

        private void btnguardarnuevaB_Click(object sender, EventArgs e)
        {
            _bebidaEN.Nombre = txtNombre.Text;
            _bebidaEN.Descripcion = txtDescrip.Text;
            _bebidaEN.Precio = Convert.ToDouble(txtPrecio.Text);
            _bebidaEN.IdCategoriaBebida = Convert.ToByte(txtIdCategoria.Text);
            _bebidaBL.GuardarBebida(_bebidaEN);
            CargarGrid();

            txtNombre.Clear();
            txtDescrip.Clear();
            txtPrecio.Clear();
            txtIdCategoria.Clear();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {

            _bebidaEN.Nombre = txtNombre.Text;
            _bebidaEN.Descripcion = txtDescrip.Text;
           _bebidaEN.Precio = Convert.ToDouble(txtPrecio.Text);
            _bebidaEN.IdCategoriaBebida = Convert.ToByte(txtIdCategoria.Text);
            _bebidaEN.Id = Convert.ToByte(txtCodB.Text);

            _bebidaBL.EliminarBebida(_bebidaEN);
            CargarGrid();

            txtNombre.Clear();
            txtDescrip.Clear();
            txtPrecio.Clear();
            txtIdCategoria.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            _bebidaEN.Nombre = txtNombre.Text;
            _bebidaEN.Descripcion = txtDescrip.Text;
            _bebidaEN.Precio = Convert.ToDouble(txtPrecio.Text);
            _bebidaEN.IdCategoriaBebida = Convert.ToByte(txtIdCategoria.Text);
            _bebidaEN.Id = Convert.ToByte(txtCodB.Text);

            _bebidaBL.ModificarBebida(_bebidaEN);

            txtNombre.Clear();
            txtDescrip.Clear();
            txtPrecio.Clear();
            txtIdCategoria.Clear();
            CargarGrid();
        }

        private void cbCategoriaB_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdCategoria.Text = cbCategoria.SelectedValue.ToString();
        }
    }
}
