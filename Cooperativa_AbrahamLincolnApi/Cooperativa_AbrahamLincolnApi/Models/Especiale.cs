using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class Especiale
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public byte[] Documento { get; set; } = null!;
        public string? UsuarioInsercion { get; set; }
        public DateTime? FechaInsercion { get; set; }
        public int ComitesId { get; set; }

        public virtual Comite Comites { get; set; } = null!;
    }
}
