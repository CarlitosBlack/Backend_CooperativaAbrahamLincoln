using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class DocumentosProcesosGerencium
    {
        public int Id { get; set; }
        public string NombreDocumento { get; set; } = null!;
        public byte[] Documento { get; set; } = null!;
        public string? UsuarioInsercion { get; set; }
        public DateTime? FechaInsercion { get; set; }
        public int ProcesosId { get; set; }

        public virtual Proceso Procesos { get; set; } = null!;
    }
}
