using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class InfoSocioComiteElectoral
    {
        public int Id { get; set; }
        public string Categoria { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public byte[] Documento { get; set; } = null!;
        public string? UsuarioInsercion { get; set; }
        public DateTime? FechaInsercion { get; set; }
        public int ComiteElectoralId { get; set; }

        public virtual ComiteElectoral ComiteElectoral { get; set; } = null!;
    }
}
