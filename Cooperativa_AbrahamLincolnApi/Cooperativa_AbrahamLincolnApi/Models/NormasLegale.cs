using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class NormasLegale
    {
        public NormasLegale()
        {
            NormasExternas = new HashSet<NormasExterna>();
            NormasInternas = new HashSet<NormasInterna>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int UsuariosId { get; set; }

        public virtual Usuario Usuarios { get; set; } = null!;
        public virtual ICollection<NormasExterna> NormasExternas { get; set; }
        public virtual ICollection<NormasInterna> NormasInternas { get; set; }
    }
}
