using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class Directivo
    {
        public int Id { get; set; }
        public string TipoEquipo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Cargo { get; set; } = null!;
        public string? UsuarioInsercion { get; set; }
        public DateTime? FechaInsercion { get; set; }
        public int OrganizacionId { get; set; }

        public virtual Organizacion Organizacion { get; set; } = null!;
    }
}
