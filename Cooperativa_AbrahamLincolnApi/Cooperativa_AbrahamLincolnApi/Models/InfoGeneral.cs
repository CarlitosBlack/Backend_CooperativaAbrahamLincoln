using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class InfoGeneral
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public byte[] Documento { get; set; } = null!;
        public string? UsuarioInsercion { get; set; }
        public DateTime? FechaInsercion { get; set; }
        public int ComiteEduCoopId { get; set; }

        public virtual ComiteEduCoop ComiteEduCoop { get; set; } = null!;
    }
}
