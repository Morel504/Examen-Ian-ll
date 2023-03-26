using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vista
{
    public partial class TicketForm : Form
    {
        public TicketForm()
        {
            InitializeComponent();
        }

        Cliente miCliente = null;
        ClienteDB clienteDB = new ClienteDB();
        List<DetalleTicket> listaDetalles = new List<DetalleTicket>();
        TicketDB facturaDB = new TicketDB();
        decimal precio = 0;
        decimal isv = 0;
        decimal isv2 = 0;
        decimal totalAPagar = 0;
        decimal descuento = 0;



        private void FacturaForm_Load(object sender, System.EventArgs e)
        {
            UsuarioTextBox.Text = System.Threading.Thread.CurrentPrincipal.Identity.Name;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Ticket miTicket = new Ticket();

            miTicket.CodigoUsuario = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            miTicket.IdentidadCliente = IdentidadTextBox.Text;
            miTicket.Fecha = FechaDateTimePicker.Value;
            miTicket.TipoSoporte = TipoSoporteComboBox.Text;
            miTicket.DescripcionSolicitud = DescripcionSolicitudRichTextBox1.Text;
            miTicket.RespuestaSolicitud = RespuestaSolicitudRichTextBox2.Text;
            miTicket.Precio = PrecioTextBox.Text;
            miTicket.ISV = isv;
            miTicket.Descuento = descuento;
            miTicket.Total = totalAPagar;

            //bool insertar = TicketDB.GuardarTickett(miTicket);

            //if (insertar)
            //{
            //    LimpiarControles();
            //    MessageBox.Show("Ticket Guardado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("No se Guardó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}


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
            precio = Convert.ToDecimal(PrecioTextBox.Text);
            descuento = Convert.ToDecimal(DescuentoTextBox.Text);
            isv = Convert.ToDecimal(ImpuestoTextBox.Text);
            Calculo();
        }


        private void Calculo()
        {
            isv2 = isv / 100;
            totalAPagar = precio - descuento;
            totalAPagar = totalAPagar - isv2;
            TotalTextBox.Text = Convert.ToString(totalAPagar);
        }


    }
}
