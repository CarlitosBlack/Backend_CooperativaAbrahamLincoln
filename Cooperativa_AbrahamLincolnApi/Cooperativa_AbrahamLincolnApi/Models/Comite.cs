using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class Comite
    {
        public Comite()
        {
            Apoyos = new HashSet<Apoyo>();
            Especiales = new HashSet<Especiale>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int UsuariosId { get; set; }

        public virtual Usuario Usuarios { get; set; } = null!;
        public virtual ICollection<Apoyo> Apoyos { get; set; }
        public virtual ICollection<Especiale> Especiales { get; set; }
    }
}
