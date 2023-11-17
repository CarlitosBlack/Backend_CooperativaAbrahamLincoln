using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class InfoSocioAdministracion
    {
        public int Id { get; set; }
        public string Categoria { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; } = null!;
        public byte[] Documento { get; set; } = null!;
        public string? UsuarioInsercion { get; set; }
        public DateTime? FechaInsercion { get; set; }
        public int ConsejoAdministracionId { get; set; }

        public virtual ConsejoAdministracion ConsejoAdministracion { get; set; } = null!;
    }
}
