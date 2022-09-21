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
    public partial class AdministrarComida : Form
    {
       

        ComidaEN _comidaEN = new ComidaEN();
        ComidaBL _comidaBL = new ComidaBL();

        public AdministrarComida()
        {
            InitializeComponent();
        }

        public void CargarGrid()
        {
            dgMostrarComida.DataSource = _comidaBL.MostrarComida();
        }


        private void dgMostrarComida_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdministrarComida_Load(object sender, EventArgs e)
        {

            CargarGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _comidaEN.Nombre = txtNombre.Text;
            DataTable tabla = new DataTable();
            tabla = _comidaBL.BuscarComida(_comidaEN);
            dgMostrarComida.DataSource = tabla;
        }

        private void dgMostrarComida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NuevaComida nb = new NuevaComida();
            if (dgMostrarComida.SelectedRows.Count > 0)
            {
                nb.txtCodCom.Text = dgMostrarComida.CurrentRow.Cells["Id"].Value.ToString();
                nb.txtNombre.Text = dgMostrarComida.CurrentRow.Cells["Nombre"].Value.ToString();
                nb.txtDescripcion.Text = dgMostrarComida.CurrentRow.Cells["Descripcion"].Value.ToString();
                nb.txtPrecio.Text = dgMostrarComida.CurrentRow.Cells["Precio"].Value.ToString();
                nb.txtIdCategoriaC.Text = dgMostrarComida.CurrentRow.Cells["IdCategoriaComida"].Value.ToString();

            }
            nb.Show();
        }

        private void btnNuevaC_Click(object sender, EventArgs e)
        {
            NuevaComida nuevaComF = new NuevaComida();
            nuevaComF.btnModificar.Visible = false;
            nuevaComF.btnEliminar.Visible = false;
            nuevaComF.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}
