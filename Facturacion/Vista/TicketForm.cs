using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vista
{
    public partial class FacturaForm : Form
    {
        public FacturaForm()
        {
            InitializeComponent();
        }

        Cliente miCliente = null;
        ClienteDB clienteDB = new ClienteDB();
        List<DetalleTicket> listaDetalles = new List<DetalleTicket>();
        TicketDB facturaDB = new TicketDB();
        decimal precio = 0;
        decimal isv = 010;
        decimal totalAPagar = 0;
        decimal descuento = 0;



        private void FacturaForm_Load(object sender, System.EventArgs e)
        {
            UsuarioTextBox.Text = System.Threading.Thread.CurrentPrincipal.Identity.Name;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Ticket miTicket = new Ticket();
            miTicket.Fecha = FechaDateTimePicker.Value;
            miTicket.CodigoUsuario = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            miTicket.ISV = isv;
            miTicket.Descuento = descuento;
            miTicket.Total = totalAPagar;

            bool inserto = facturaDB.Guardar(miTicket, listaDetalles);

            if (inserto)
            {
                LimpiarControles();
                IdentidadTextBox.Focus();
                MessageBox.Show("Factura registrada exitosamente");
            }
            else
                MessageBox.Show("No se pudo registrar la factura");
        }

        private void LimpiarControles()
        {

            listaDetalles = null;
            FechaDateTimePicker.Value = DateTime.Now;
            IdentidadTextBox.Clear();
            NombreClienteTextBox.Clear();
            PrecioTextBox.Clear();
            DescuentoTextBox.Clear();
            TotalTextBox.Clear();
        }

        private void BuscarClienteButton_Click(object sender, EventArgs e)
        {
            BuscarClienteForm form = new BuscarClienteForm();
            form.ShowDialog();
            miCliente = new Cliente();
            miCliente = form.cliente;
            IdentidadTextBox.Text = miCliente.Identidad;
            NombreClienteTextBox.Text = miCliente.Nombre;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            precio = Convert.ToInt32(PrecioTextBox.Text);
            descuento = Convert.ToInt32(DescuentoTextBox.Text);
            Calculo();
        }


        private void Calculo()
        {
            totalAPagar = precio - descuento;
            TotalTextBox.Text = Convert.ToString(totalAPagar);
        }

    }
}
