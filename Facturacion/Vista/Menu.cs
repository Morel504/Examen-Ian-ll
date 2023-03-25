using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void UsuariosToolStripButton_Click(object sender, EventArgs e)
        {
        }

        private void ProductosToolStripButton_Click(object sender, EventArgs e)
        {
        }

        private void NuevaFacturaToolStripButton_Click(object sender, EventArgs e)
        {
            FacturaForm facturaForm = new FacturaForm();
            facturaForm.MdiParent = this;
            facturaForm.Show();
        }


    }
}
