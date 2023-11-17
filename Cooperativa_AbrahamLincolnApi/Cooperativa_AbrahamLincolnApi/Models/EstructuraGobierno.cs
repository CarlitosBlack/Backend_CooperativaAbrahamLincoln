using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class EstructuraGobierno
    {
        public int Id { get; set; }
        public string NombreDocumento { get; set; } = null!;
        public byte[] Documento { get; set; } = null!;
        public string? UsuarioInsercion { get; set; }
        public DateTime? FechaInsercion { get; set; }
        public int OrganizacionId { get; set; }

        public virtual Organizacion Organizacion { get; set; } = null!;
    }
}
