using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class UsuarioControl
    {
        public int IdDescarga { get; set; }
        public string UsuarioDescarga { get; set; } = null!;
        public DateTime FechaDescarga { get; set; }
        public string NombreDocumento { get; set; } = null!;
        public string NombreElemento { get; set; } = null!;
        public int UsuariosId { get; set; }

        public virtual Usuario Usuarios { get; set; } = null!;
    }
}
