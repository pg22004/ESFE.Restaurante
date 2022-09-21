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
    public partial class NuevaCategoriaB : Form
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-SIJQEDF\SERVIDORSQL;Initial Catalog=RestauranteBD;Integrated Security=True");
        CategoriaBebidaEN _categoriabEN = new CategoriaBebidaEN();
        CategoriaBebidaBL _categoriabBL = new CategoriaBebidaBL();

        public NuevaCategoriaB()
        {
            InitializeComponent();
            
        }
        public void CargarGrid()
        {
            AdministrarCategoriaB Adminb = new AdministrarCategoriaB();
            SqlCommand comando = new SqlCommand("Select * from CategoriaBebida", _conn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            Adminb.dgMostrarCategoriaB.DataSource = tabla;
        }

        private void NuevaCategoriaB_Load(object sender, EventArgs e)
        {
            if (txtCodCB.Text == "")
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
            _categoriabEN.Nombre = txtNombre.Text;
            _categoriabBL.GuardarCategoriaBebida(_categoriabEN);
            CargarGrid();

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            _categoriabEN.Id = Convert.ToByte(txtCodCB.Text);
            _categoriabEN.Nombre = txtNombre.Text;
            _categoriabBL.EliminarCategoriaBebida(_categoriabEN);

          
            txtCodCB.Clear();
            CargarGrid();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            _categoriabEN.Id = Convert.ToByte(txtCodCB.Text);
            _categoriabEN.Nombre = txtNombre.Text;
            _categoriabBL.ModificarCategoriaBebida(_categoriabEN);
            CargarGrid();

            txtCodCB.Clear();
           
        }
      
    }
}
