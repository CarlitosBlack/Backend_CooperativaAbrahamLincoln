using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class AsambleaGeneral
    {
        public AsambleaGeneral()
        {
            Asambleas = new HashSet<Asamblea>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int UsuariosId { get; set; }

        public virtual Usuario Usuarios { get; set; } = null!;
        public virtual ICollection<Asamblea> Asambleas { get; set; }
    }
}
