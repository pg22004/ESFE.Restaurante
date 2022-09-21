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
    public partial class AdministrarCategoriaC : Form
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");

        CategoriaComidaEN _categoriacEN = new CategoriaComidaEN();
        CategoriaComidaBL _categoriacBL = new CategoriaComidaBL();

        public AdministrarCategoriaC()
        {
            InitializeComponent();
        }
        public void CargarGrid()
        {
            dgMostrarCategoriaC.DataSource = _categoriacBL.MostrarCategoriaComida();
        }

   

        private void AdministrarCategoriaC_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _categoriacEN.Nombre = txtNombre.Text;
            DataTable tabla = new DataTable();
            tabla = _categoriacBL.BuscarCategoriaComida(_categoriacEN);
            dgMostrarCategoriaC.DataSource = tabla;
        }

        private void dgMostrarCategoriaC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NuevaCategoriaC nb = new NuevaCategoriaC();
            if (dgMostrarCategoriaC.SelectedRows.Count > 0)
            {
                nb.txtCodCC.Text = dgMostrarCategoriaC.CurrentRow.Cells["Id"].Value.ToString();
                nb.txtNombre.Text = dgMostrarCategoriaC.CurrentRow.Cells["Nombre"].Value.ToString();

            }
            nb.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevaCategoriaC nuevaCF = new NuevaCategoriaC();
            nuevaCF.btnModificar.Visible = false;
            nuevaCF.btneliminar.Visible = false;
            nuevaCF.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}
