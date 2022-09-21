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
    public partial class AdministrarEmpleado : Form
    {
        SqlConnection _conn = new SqlConnection();

        EmpleadoEN _empleadoEN = new EmpleadoEN();
        EmpleadoBL _empleadoBL = new EmpleadoBL();
        public AdministrarEmpleado()
        {
            InitializeComponent();
        }
        public void CargarGrid()
        {
            dgtempleado.DataSource = _empleadoBL.MostrarEmpleado();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
            NuevoEmpleado nuevoEmpF= new NuevoEmpleado();
            nuevoEmpF.btnModificar.Visible = false;
            nuevoEmpF.btnEliminar.Visible = false;
            nuevoEmpF.Show();
            
        }

        private void AdministrarEmpleado_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _empleadoEN.Id =Convert.ToByte(txtNombre.Text);
            DataTable tabla = new DataTable();
            tabla = _empleadoBL.BuscarEmpleado(_empleadoEN);
            dgtempleado.DataSource = tabla;
        }

        private void dgtempleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NuevoEmpleado nb = new NuevoEmpleado();
            if (dgtempleado.SelectedRows.Count > 0)
            {
                nb.txtCodEmp.Text = dgtempleado.CurrentRow.Cells["Id"].Value.ToString();
                nb.txtNombre.Text = dgtempleado.CurrentRow.Cells["Nombre"].Value.ToString();
                nb.txtSNombre.Text = dgtempleado.CurrentRow.Cells["SegundoNombre"].Value.ToString();
                nb.txtApellido.Text = dgtempleado.CurrentRow.Cells["Apellido"].Value.ToString();
                nb.txtSApellido.Text = dgtempleado.CurrentRow.Cells["SegundoApellido"].Value.ToString();
                nb.txtGmail.Text = dgtempleado.CurrentRow.Cells["Gmail"].Value.ToString();
                nb.txtTele.Text = dgtempleado.CurrentRow.Cells["Telefono"].Value.ToString();
                nb.cbCargo.Text = dgtempleado.CurrentRow.Cells["IdTipoCargo"].Value.ToString();
            }
            nb.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}
