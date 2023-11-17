using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class GerenciaGeneral
    {
        public GerenciaGeneral()
        {
            InfoSocioGerencia = new HashSet<InfoSocioGerencium>();
            Procesos = new HashSet<Proceso>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int UsuariosId { get; set; }

        public virtual Usuario Usuarios { get; set; } = null!;
        public virtual ICollection<InfoSocioGerencium> InfoSocioGerencia { get; set; }
        public virtual ICollection<Proceso> Procesos { get; set; }
    }
}
