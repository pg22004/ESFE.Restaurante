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
    public partial class AdministrarCategoriaB : Form
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");

        CategoriaBebidaEN _categoriabEN = new CategoriaBebidaEN();
        CategoriaBebidaBL _categoriabBL = new CategoriaBebidaBL();
        public AdministrarCategoriaB()
        {
            InitializeComponent();
        }
        public void CargarGrid()
        {
            dgMostrarCategoriaB.DataSource = _categoriabBL.MostrarCategoriaBebida();
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            NuevaCategoriaB nuevaCatF = new NuevaCategoriaB();
            nuevaCatF.btnModificar.Visible = false;
            nuevaCatF.btnEliminar.Visible = false;
            nuevaCatF.Show();

        }

        private void AdministrarCategoriaB_Load(object sender, EventArgs e)
        {

            CargarGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
                _categoriabEN.Nombre = txtNombre.Text;
                DataTable tabla = new DataTable();
                tabla = _categoriabBL.BuscarCategoriaBebida(_categoriabEN);
                dgMostrarCategoriaB.DataSource = tabla;
            
        }

        private void dgMostrarCategoriaB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NuevaCategoriaB nb = new NuevaCategoriaB();
            if (dgMostrarCategoriaB.SelectedRows.Count > 0)
            {
                nb.txtCodCB.Text = dgMostrarCategoriaB.CurrentRow.Cells["Id"].Value.ToString();
                nb.txtNombre.Text = dgMostrarCategoriaB.CurrentRow.Cells["Nombre"].Value.ToString();
               
            }
            nb.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}
