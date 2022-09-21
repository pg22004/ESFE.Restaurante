using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//-------------------------------------
using ESFE.Restaurante.EN;
using ESFE.Restaurante.BL;
using System.Data.SqlClient;

namespace ESFE.Restaurante.UI.WF
{
    public partial class NuevoEmpleado : Form
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");

        EmpleadoEN _empleadoEN = new EmpleadoEN();
        EmpleadoBL _empleadoBL = new EmpleadoBL();
        TipoCargoBL _tipoCargoBL = new TipoCargoBL();
        public NuevoEmpleado()
        {
            InitializeComponent();
            cbCargo.DataSource = _tipoCargoBL.MostrarTipoCargo();
            cbCargo.DisplayMember = "Nombre";
            cbCargo.ValueMember = "Id";
        }
        public void CargarGrid()
        {
            AdministrarEmpleado Adminb = new AdministrarEmpleado();
            SqlCommand comando = new SqlCommand("Select * from Empleado", _conn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            Adminb.dgtempleado.DataSource = tabla;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _empleadoEN.Nombre = txtNombre.Text;
            _empleadoEN.SegundoNombre = txtSNombre.Text;
            _empleadoEN.Apellido = txtApellido.Text;
            _empleadoEN.SegundoApellido = txtSApellido.Text;
            _empleadoEN.Gmail = txtGmail.Text;
            _empleadoEN.Telefono = txtTele.Text;
            _empleadoEN.IdTipoCargo = Convert.ToByte(cbCargo.Text);
            _empleadoBL.GuardarEmpleado(_empleadoEN);
            CargarGrid();

            txtNombre.Clear();
            txtSNombre.Clear();
            txtApellido.Clear();
            txtSApellido.Clear();
            txtGmail.Clear();
            txtTele.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            _empleadoEN.Nombre = txtNombre.Text;
            _empleadoEN.SegundoNombre = txtSNombre.Text;
            _empleadoEN.Apellido = txtApellido.Text;
            _empleadoEN.SegundoApellido = txtSApellido.Text;
            _empleadoEN.Gmail = txtGmail.Text;
            _empleadoEN.Telefono = txtTele.Text;
            _empleadoEN.IdTipoCargo = Convert.ToByte(cbCargo.Text);
            _empleadoEN.Id = Convert.ToInt32(txtCodEmp.Text);
            _empleadoBL.EliminarEmpleado(_empleadoEN);
            CargarGrid();

            txtNombre.Clear();
            txtSNombre.Clear();
            txtApellido.Clear();
            txtSApellido.Clear();
            txtGmail.Clear();
            txtTele.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            _empleadoEN.Nombre = txtNombre.Text;
            _empleadoEN.SegundoNombre = txtSNombre.Text;
            _empleadoEN.Apellido = txtApellido.Text;
            _empleadoEN.SegundoApellido = txtSApellido.Text;
            _empleadoEN.Gmail = txtGmail.Text;
            _empleadoEN.Telefono = txtTele.Text;
            _empleadoEN.IdTipoCargo = Convert.ToByte(cbCargo.Text);
            _empleadoEN.Id = Convert.ToInt32(txtCodEmp.Text);
            _empleadoBL.ModificarEmpleado(_empleadoEN);
            CargarGrid();

            txtNombre.Clear();
            txtSNombre.Clear();
            txtApellido.Clear();
            txtSApellido.Clear();
            txtGmail.Clear();
            txtTele.Clear();
        }

        private void NuevoEmpleado_Load(object sender, EventArgs e)
        {
            if (txtCodEmp.Text == "")
            {
                btnGuardar.Visible = true;
            }
            else
            {
                btnGuardar.Visible = false; ;
            }
        }

        private void cbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdTipoC.Text = cbCargo.SelectedValue.ToString();
        }
    }
}
