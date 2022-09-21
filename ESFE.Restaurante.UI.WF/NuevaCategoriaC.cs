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
    public partial class NuevaCategoriaC : Form
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");

        CategoriaComidaEN _categoriacEN = new CategoriaComidaEN();
        CategoriaComidaBL _categoriacBL = new CategoriaComidaBL();

        public NuevaCategoriaC()
        {
            InitializeComponent();
        }
        public void CargarGrid()
        {
            AdministrarCategoriaC Adminb = new AdministrarCategoriaC();
            SqlCommand comando = new SqlCommand("Select * from CategoriaComida", _conn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            Adminb.dgMostrarCategoriaC.DataSource = tabla;
        }

       

    

        private void btnguardar_Click(object sender, EventArgs e)
        {
            _categoriacEN.Nombre = txtNombre.Text;
            _categoriacBL.GuardarCategoriaComida(_categoriacEN);
            CargarGrid();

            txtNombre.Clear();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            _categoriacEN.Id = Convert.ToByte(txtCodCC.Text);
            _categoriacEN.Nombre = txtNombre.Text;
            _categoriacBL.EliminarCategoriaComida(_categoriacEN);

            txtNombre.Clear();
            txtCodCC.Clear();
            CargarGrid();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            _categoriacEN.Id = Convert.ToByte(txtCodCC.Text);
            _categoriacEN.Nombre = txtNombre.Text;
            _categoriacBL.ModificarCategoriaComida(_categoriacEN);
            CargarGrid();

            txtNombre.Clear();
            txtCodCC.Clear();
            
        }

        private void NuevaCategoriaC_Load(object sender, EventArgs e)
        {
            if (txtCodCC.Text == "")
            {
                btnguardar.Visible = true;
            }
            else
            {
                btnguardar.Visible = false; ;
            }
        }
    }
}
