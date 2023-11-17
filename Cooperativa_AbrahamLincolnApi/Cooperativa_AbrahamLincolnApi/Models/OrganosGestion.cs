using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class OrganosGestion
    {
        public OrganosGestion()
        {
            Colegios = new HashSet<Colegio>();
            Cooperativas = new HashSet<Cooperativa>();
        }

        public int Id { get; set; }
        public int Descripcion { get; set; }
        public int UsuariosId { get; set; }

        public virtual Usuario Usuarios { get; set; } = null!;
        public virtual ICollection<Colegio> Colegios { get; set; }
        public virtual ICollection<Cooperativa> Cooperativas { get; set; }
    }
}
