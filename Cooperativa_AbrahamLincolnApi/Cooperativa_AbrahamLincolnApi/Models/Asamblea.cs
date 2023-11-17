using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class Asamblea
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public byte[]? Convocatoria { get; set; }
        public byte[]? Actas { get; set; }
        public byte[]? Anexos { get; set; }
        public byte[]? Acuerdos { get; set; }
        public string? UsuarioInsercion { get; set; }
        public DateTime? FechaInsercion { get; set; }
        public int AsambleaGeneralId { get; set; }

        public virtual AsambleaGeneral AsambleaGeneral { get; set; } = null!;
    }
}
