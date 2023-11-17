using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class Role
    {
        public Role()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdRoles { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
