using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class Comedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public byte[] Documento { get; set; } = null!;
        public string? UsuarioInsercion { get; set; }
        public DateTime? FechaInsercion { get; set; }
        public int UsuariosId { get; set; }

        public virtual Usuario Usuarios { get; set; } = null!;
    }
}
