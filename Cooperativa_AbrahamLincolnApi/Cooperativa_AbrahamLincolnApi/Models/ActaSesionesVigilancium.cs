using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class ActaSesionesVigilancium
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public byte[] Documento { get; set; } = null!;
        public string? UsuarioInsercion { get; set; }
        public DateTime? FechaInsercion { get; set; }
        public int ConsejoVigilanciaId { get; set; }

        public virtual ConsejoVigilancium ConsejoVigilancia { get; set; } = null!;
    }
}
