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
    public partial class ControlAdministrar : Form
    {
        public ControlAdministrar()
        {
            InitializeComponent();
        }
        //funcion
        private void abrircliente(object abrircliente)
        {
            //Condicion, con el nombre del panel
            if (this.contenedor.Controls.Count > 0)
                this.contenedor.Controls.RemoveAt(0);
            //Se crea un form
            Form fh = abrircliente as Form;
            //No es un form de nivel superior
            fh.TopLevel = false;
            //Se adapte al contenedor
            fh.Dock = DockStyle.Fill;
            //Se agrega el panel
            this.contenedor.Controls.Add(fh);
            this.contenedor.Tag = fh;
            fh.Show();
        }

        private void btncliente_Click_1(object sender, EventArgs e)
        {
            abrircliente(new AdministarCliente());
        }

        private void aabrirempleado(object abrirempleado)
        {
            if (this.contenedor.Controls.Count > 0)
                this.contenedor.Controls.RemoveAt(0);
            Form fh = abrirempleado as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.contenedor.Controls.Add(fh);
            this.contenedor.Tag = fh;
            fh.Show();
        }

        private void btnempleado_Click(object sender, EventArgs e)
        {
            abrircliente(new AdministrarEmpleado());
        }

        private void abrircomida(object abrircomida)
        {
            if (this.contenedor.Controls.Count > 0)
                this.contenedor.Controls.RemoveAt(0);
            Form fh = abrircomida as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.contenedor.Controls.Add(fh);
            this.contenedor.Tag = fh;
            fh.Show();
        }

        private void btncomida_Click(object sender, EventArgs e)
        {
            abrircomida(new AdministrarComida());
        }

        private void abrirbebida(object abrirbebida)
        {
            if (this.contenedor.Controls.Count > 0)
                this.contenedor.Controls.RemoveAt(0);
            Form fh = abrirbebida as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.contenedor.Controls.Add(fh);
            this.contenedor.Tag = fh;
            fh.Show();
        }

        private void btnbebidas_Click(object sender, EventArgs e)
        {
            abrirbebida(new AdministrarBebida());
        }

        private void abrirpedido(object abrirpedido)
        {
            if (this.contenedor.Controls.Count > 0)
                this.contenedor.Controls.RemoveAt(0);
            Form fh = abrirpedido as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.contenedor.Controls.Add(fh);
            this.contenedor.Tag = fh;
            fh.Show();
        }

        private void btnpedidos_Click(object sender, EventArgs e)
        {
            abrirpedido(new AdministrarPedido());
        }

        private void abrircategoriac(object abrircategoriac)
        {
            if (this.contenedor.Controls.Count > 0)
                this.contenedor.Controls.RemoveAt(0);
            Form fh = abrircategoriac as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.contenedor.Controls.Add(fh);
            this.contenedor.Tag = fh;
            fh.Show();
        }

        private void btncategoriac_Click(object sender, EventArgs e)
        {
            abrircategoriac(new AdministrarCategoriaC());
        }

        private void abrircategoriab(object abrircategoriab)
        {
            if (this.contenedor.Controls.Count > 0)
                this.contenedor.Controls.RemoveAt(0);
            Form fh = abrircategoriab as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.contenedor.Controls.Add(fh);
            this.contenedor.Tag = fh;
            fh.Show();
        }

        private void btncategoriab_Click(object sender, EventArgs e)
        {
            abrircategoriab(new AdministrarCategoriaB());
        }

        private void abrirpedidoc(object abrirpedidoc)
        {
            if (this.contenedor.Controls.Count > 0)
                this.contenedor.Controls.RemoveAt(0);
            Form fh = abrirpedidoc as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.contenedor.Controls.Add(fh);
            this.contenedor.Tag = fh;
            fh.Show();
        }

        private void btnpedidoc_Click(object sender, EventArgs e)
        {
            abrirpedidoc(new AdministrarPedidoC());
        }

        private void abrirpedidob(object abrirpedidob)
        {
            if (this.contenedor.Controls.Count > 0)
                this.contenedor.Controls.RemoveAt(0);
            Form fh = abrirpedidob as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.contenedor.Controls.Add(fh);
            this.contenedor.Tag = fh;
            fh.Show();
        }

        private void btnpedidob_Click(object sender, EventArgs e)
        {
            abrirpedidob(new AdministrarPedidoB());
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void abrirtipoc(object abrirpedidob)
        {
            if (this.contenedor.Controls.Count > 0)
                this.contenedor.Controls.RemoveAt(0);
            Form fh = abrirpedidob as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.contenedor.Controls.Add(fh);
            this.contenedor.Tag = fh;
            fh.Show();
        }

        private void btnTipoC_Click(object sender, EventArgs e)
        {
            abrirtipoc(new AdministrarTipoC());
        }
    }
}
