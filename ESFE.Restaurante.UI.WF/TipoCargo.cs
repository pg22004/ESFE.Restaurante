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
    public partial class TipoCargo : Form
    {

        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");
        TipoCargoEN _tipoCargoEN = new TipoCargoEN();
        TipoCargoBL _tipoCargoBL = new TipoCargoBL();
        public TipoCargo()
        {
            InitializeComponent();
        }
        public void CargarGrid()
        {
            AdministrarTipoC AdminTC = new AdministrarTipoC();
            SqlCommand comando = new SqlCommand("Select * from TipoCargo", _conn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            AdminTC.dgCargos.DataSource = tabla;
        }

        private void TipoCargo_Load(object sender, EventArgs e)
        {
            if (txtCodTc.Text == "")
            {
                btnguardar.Visible = true;
            }
            else
            {
                btnguardar.Visible = false; ;
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            _tipoCargoEN.Nombre = txtNombre.Text;
            _tipoCargoBL.GuardarTipoCargo(_tipoCargoEN);
            CargarGrid();

            txtNombre.Clear();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            _tipoCargoEN.Id = Convert.ToByte(txtCodTc.Text);
            _tipoCargoEN.Nombre = txtNombre.Text;
            _tipoCargoBL.EliminarTipoCargo(_tipoCargoEN);
            CargarGrid();

            txtCodTc.Clear();
            txtNombre.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            _tipoCargoEN.Id = Convert.ToByte(txtCodTc.Text);
            _tipoCargoEN.Nombre = txtNombre.Text;
            _tipoCargoBL.ModificarTipoCargo(_tipoCargoEN);
            CargarGrid();

            txtCodTc.Clear();
            txtNombre.Clear();
        }
    }
}
