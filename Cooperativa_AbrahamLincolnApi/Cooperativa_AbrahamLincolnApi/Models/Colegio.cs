using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class Colegio
    {
        public int Id { get; set; }
        public string NombreCargo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public int Anexo { get; set; }
        public string? UsuarioInsercion { get; set; }
        public DateTime? FechaInsercion { get; set; }
        public int OrganosGestionId { get; set; }

        public virtual OrganosGestion OrganosGestion { get; set; } = null!;
    }
}
