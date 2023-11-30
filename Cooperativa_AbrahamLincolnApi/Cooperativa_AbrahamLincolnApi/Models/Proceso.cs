using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class Proceso
    {
        public Proceso()
        {
            DocumentosProcesosGerencia = new HashSet<DocumentosProcesosGerencium>();
        }

        public int Id { get; set; }
        public string Categoria { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string NombreProceso { get; set; } = null!;
        //public byte[]? Documento { get; set; } = null!;
        public string? UsuarioInsercion { get; set; }
        public DateTime? FechaInsercion { get; set; }
        public int GerenciaGeneralId { get; set; }

        public virtual GerenciaGeneral GerenciaGeneral { get; set; } = null!;
        public virtual ICollection<DocumentosProcesosGerencium> DocumentosProcesosGerencia { get; set; }
    }
}
