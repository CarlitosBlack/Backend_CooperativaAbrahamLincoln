using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class OperativosProyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal? MontoAutorizado { get; set; }
        public decimal MontoEjecutado { get; set; }
        public string? Situacion { get; set; }
        public string? Observaciones { get; set; }
        public string? UsuarioInsercion { get; set; }
        public DateTime? FechaInsercion { get; set; }
        public int ProyectosId { get; set; }

        public virtual Proyecto Proyectos { get; set; } = null!;
    }
}
