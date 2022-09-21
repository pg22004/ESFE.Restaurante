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
    public partial class NuevaComida : Form
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");

        ComidaEN _comidaEN = new ComidaEN();
        ComidaBL _comidaBL = new ComidaBL();
        CategoriaComidaBL _categoriaComidaBL = new CategoriaComidaBL();

        public NuevaComida()
        {
            InitializeComponent();
            cbCategoriaC.DataSource = _categoriaComidaBL.MostrarCategoriaComida();
            cbCategoriaC.DisplayMember = "Nombre";
            cbCategoriaC.ValueMember = "Id";
        }

        public void CargarGrid()
        {
            AdministrarComida Adminc = new AdministrarComida();
            SqlCommand comando = new SqlCommand("Select * from Comida", _conn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            Adminc.dgMostrarComida.DataSource = tabla;
        }

        private void NuevaComida_Load(object sender, EventArgs e)
        {
            if (txtCodCom.Text == "")
            {
                btnGuardar.Visible = true;
            }
            else
            {
                btnGuardar.Visible = false; ;
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {        
                _comidaEN.Nombre = txtNombre.Text;
                _comidaEN.Descripcion = txtDescripcion.Text;
                _comidaEN.Precio = Convert.ToDouble(txtPrecio.Text);
                _comidaEN.IdCategoriaComida = Convert.ToByte(txtIdCategoriaC.Text);
                _comidaBL.GuardarComida(_comidaEN);
                CargarGrid();


                txtNombre.Clear();
                txtDescripcion.Clear();
                txtPrecio.Clear();
                txtIdCategoriaC.Clear();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
                _comidaEN.Id = Convert.ToByte(txtCodCom.Text);
                _comidaEN.Nombre = txtNombre.Text;
                _comidaEN.Descripcion = txtDescripcion.Text;
                _comidaEN.Precio = Convert.ToDouble(txtPrecio.Text);
                _comidaEN.IdCategoriaComida = Convert.ToByte(txtIdCategoriaC.Text);
                _comidaBL.EliminarComida(_comidaEN);

                txtNombre.Clear();
                txtDescripcion.Clear();
                txtPrecio.Clear();
                txtCodCom.Clear();
                CargarGrid();         
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            _comidaEN.Id = Convert.ToByte(txtCodCom.Text);
            _comidaEN.Nombre = txtNombre.Text;
            _comidaEN.Descripcion = txtDescripcion.Text;
            _comidaEN.Precio = Convert.ToDouble(txtPrecio.Text);
            _comidaEN.IdCategoriaComida = Convert.ToByte(txtIdCategoriaC.Text);
            _comidaBL.ModificarComida(_comidaEN);

            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtCodCom.Clear();
            CargarGrid();
        }

        private void cbCategoriaC_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdCategoriaC.Text = cbCategoriaC.SelectedValue.ToString();
        }
    }
}
