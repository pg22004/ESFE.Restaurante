using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESFE.Restaurante.UI.WF
{
    public partial class Bienvenida : Form
    {
        public Bienvenida()
        {
            InitializeComponent();
        }

        private void btnGuardarC_Click(object sender, EventArgs e)
        {
            Cliente frm = new Cliente();
            frm.ShowDialog();
        }
    }
}
