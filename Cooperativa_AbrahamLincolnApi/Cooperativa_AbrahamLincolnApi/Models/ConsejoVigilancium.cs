using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class ConsejoVigilancium
    {
        public ConsejoVigilancium()
        {
            ActaSesionesVigilancia = new HashSet<ActaSesionesVigilancium>();
            InfoSocioVigilancia = new HashSet<InfoSocioVigilancium>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int UsuariosId { get; set; }

        public virtual Usuario Usuarios { get; set; } = null!;
        public virtual ICollection<ActaSesionesVigilancium> ActaSesionesVigilancia { get; set; }
        public virtual ICollection<InfoSocioVigilancium> InfoSocioVigilancia { get; set; }
    }
}
