using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class ConsejoAdministracion
    {
        public ConsejoAdministracion()
        {
            ActaSesionesAdministracions = new HashSet<ActaSesionesAdministracion>();
            ContratosAdquisiciones = new HashSet<ContratosAdquisicione>();
            InfoSocioAdministracions = new HashSet<InfoSocioAdministracion>();
            Proyectos = new HashSet<Proyecto>();
            ReportesFinancieros = new HashSet<ReportesFinanciero>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int UsuariosId { get; set; }

        public virtual Usuario Usuarios { get; set; } = null!;
        public virtual ICollection<ActaSesionesAdministracion> ActaSesionesAdministracions { get; set; }
        public virtual ICollection<ContratosAdquisicione> ContratosAdquisiciones { get; set; }
        public virtual ICollection<InfoSocioAdministracion> InfoSocioAdministracions { get; set; }
        public virtual ICollection<Proyecto> Proyectos { get; set; }
        public virtual ICollection<ReportesFinanciero> ReportesFinancieros { get; set; }
    }
}
