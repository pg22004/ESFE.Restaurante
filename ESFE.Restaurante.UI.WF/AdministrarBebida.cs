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
    public partial class AdministrarBebida : Form
    {
       

        BebidaEN _bebidaEN = new BebidaEN();
        BebidaBL _bebidaBL = new BebidaBL();

        public AdministrarBebida()
        {
            InitializeComponent();
            
        }

        public void CargarGrid()
        {
            dgMostrarBebida.DataSource = _bebidaBL.MostrarBebida();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevaBebida nuevaBebF = new NuevaBebida();
            nuevaBebF.btnModificar.Visible = false;
            nuevaBebF.btneliminar.Visible = false;
            nuevaBebF.Show();
        }

        private void AdministrarBebida_Load(object sender, EventArgs e)
        {
           
            CargarGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _bebidaEN.Nombre = txtNombre.Text;
            DataTable tabla = new DataTable();
            tabla = _bebidaBL.BuscarBebida(_bebidaEN);
            dgMostrarBebida.DataSource = tabla;
        }

        private void dgMostrarBebida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NuevaBebida nb = new NuevaBebida();
            if (dgMostrarBebida.SelectedRows.Count>0)
            {
                nb.txtCodB.Text = dgMostrarBebida.CurrentRow.Cells["Id"].Value.ToString();
                nb.txtNombre.Text = dgMostrarBebida.CurrentRow.Cells["Nombre"].Value.ToString();
                nb.txtDescrip.Text = dgMostrarBebida.CurrentRow.Cells["Descripcion"].Value.ToString();
                nb.txtPrecio.Text = dgMostrarBebida.CurrentRow.Cells["Precio"].Value.ToString();
                nb.txtIdCategoria.Text = dgMostrarBebida.CurrentRow.Cells["IdCategoriaBebida"].Value.ToString();

            }
            nb.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}
