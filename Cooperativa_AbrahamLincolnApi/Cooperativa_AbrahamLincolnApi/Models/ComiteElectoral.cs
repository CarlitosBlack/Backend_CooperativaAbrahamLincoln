using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class ComiteElectoral
    {
        public ComiteElectoral()
        {
            InfoSocioComiteElectorals = new HashSet<InfoSocioComiteElectoral>();
            ProcesosElectorales = new HashSet<ProcesosElectorale>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int UsuariosId { get; set; }

        public virtual Usuario Usuarios { get; set; } = null!;
        public virtual ICollection<InfoSocioComiteElectoral> InfoSocioComiteElectorals { get; set; }
        public virtual ICollection<ProcesosElectorale> ProcesosElectorales { get; set; }
    }
}
