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
    public partial class AdministrarTipoC : Form
    {
        TipoCargoEN _tipoCargoEN = new TipoCargoEN();
        TipoCargoBL _tipoCargoBL = new TipoCargoBL();
        public AdministrarTipoC()
        {
            InitializeComponent();
        }
        public void CargarGrid()
        {
            dgCargos.DataSource = _tipoCargoBL.MostrarTipoCargo();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            TipoCargo nuevoTC = new TipoCargo();
            nuevoTC.btnModificar.Visible = false;
            nuevoTC.btneliminar.Visible = false;
            nuevoTC.Show();
        }

        private void AdministrarTipoC_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void dgCargos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TipoCargo ntc = new TipoCargo();
            if (dgCargos.SelectedRows.Count > 0)
            {
                ntc.txtCodTc.Text = dgCargos.CurrentRow.Cells["Id"].Value.ToString();
                ntc.txtNombre.Text = dgCargos.CurrentRow.Cells["Nombre"].Value.ToString();

            }
            ntc.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}
