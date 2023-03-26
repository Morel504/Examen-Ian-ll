using System;

namespace Entidades
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string IdentidadCliente { get; set; }
        public string CodigoUsuario { get; set; }
        public string TipoSoporte { get; set; }
        public string DescripcionSolicitud { get; set; }
        public string RespuestaSolicitud { get; set; }
        public string Precio { get; set; }
        public decimal ISV { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }

        public Ticket()
        {
        }

        public Ticket(int id, DateTime fecha, string identidadCliente, string codigoUsuario, string tipoSoporte, string descripcionSolicitud, string respuestaSolicitud, string precio, decimal iSV, decimal descuento, decimal total)
        {
            Id = id;
            Fecha = fecha;
            IdentidadCliente = identidadCliente;
            CodigoUsuario = codigoUsuario;
            TipoSoporte = tipoSoporte;
            DescripcionSolicitud = descripcionSolicitud;
            RespuestaSolicitud = respuestaSolicitud;
            Precio = precio;
            ISV = iSV;
            Descuento = descuento;
            Total = total;
        }
    }
}
