using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class ProcesosElectorale
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; } = null!;
        public byte[] Document { get; set; } = null!;
        public string? UsuarioInsercion { get; set; }
        public DateTime? FechaInsercion { get; set; }
        public int ComiteElectoralId { get; set; }

        public virtual ComiteElectoral ComiteElectoral { get; set; } = null!;
    }
}
