using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            InfraestructuraProyectos = new HashSet<InfraestructuraProyecto>();
            OperativosProyectos = new HashSet<OperativosProyecto>();
            PedagogicosProyectos = new HashSet<PedagogicosProyecto>();
        }

        public int Id { get; set; }
        public int ConsejoAdministracionId { get; set; }

        public virtual ConsejoAdministracion ConsejoAdministracion { get; set; } = null!;
        public virtual ICollection<InfraestructuraProyecto> InfraestructuraProyectos { get; set; }
        public virtual ICollection<OperativosProyecto> OperativosProyectos { get; set; }
        public virtual ICollection<PedagogicosProyecto> PedagogicosProyectos { get; set; }
    }
}
