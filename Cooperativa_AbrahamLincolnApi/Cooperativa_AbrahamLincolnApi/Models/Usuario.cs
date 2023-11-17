using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            AsambleaGenerals = new HashSet<AsambleaGeneral>();
            Comedors = new HashSet<Comedor>();
            ComiteEduCoops = new HashSet<ComiteEduCoop>();
            ComiteElectorals = new HashSet<ComiteElectoral>();
            Comites = new HashSet<Comite>();
            ConsejoAdministracions = new HashSet<ConsejoAdministracion>();
            ConsejoVigilancia = new HashSet<ConsejoVigilancium>();
            GerenciaGenerals = new HashSet<GerenciaGeneral>();
            Historia = new HashSet<Historium>();
            NormasLegales = new HashSet<NormasLegale>();
            Organizacions = new HashSet<Organizacion>();
            OrganosGestions = new HashSet<OrganosGestion>();
            PabellonDiplomas = new HashSet<PabellonDiploma>();
            RevisionEstructuras = new HashSet<RevisionEstructura>();
            SeguroEstudiantils = new HashSet<SeguroEstudiantil>();
            UsuarioControls = new HashSet<UsuarioControl>();
        }

        public int Id { get; set; }
        public string Usuario1 { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public byte Estado { get; set; }
        public int RolesIdRoles { get; set; }

        public virtual Role RolesIdRolesNavigation { get; set; } = null!;
        public virtual ICollection<AsambleaGeneral> AsambleaGenerals { get; set; }
        public virtual ICollection<Comedor> Comedors { get; set; }
        public virtual ICollection<ComiteEduCoop> ComiteEduCoops { get; set; }
        public virtual ICollection<ComiteElectoral> ComiteElectorals { get; set; }
        public virtual ICollection<Comite> Comites { get; set; }
        public virtual ICollection<ConsejoAdministracion> ConsejoAdministracions { get; set; }
        public virtual ICollection<ConsejoVigilancium> ConsejoVigilancia { get; set; }
        public virtual ICollection<GerenciaGeneral> GerenciaGenerals { get; set; }
        public virtual ICollection<Historium> Historia { get; set; }
        public virtual ICollection<NormasLegale> NormasLegales { get; set; }
        public virtual ICollection<Organizacion> Organizacions { get; set; }
        public virtual ICollection<OrganosGestion> OrganosGestions { get; set; }
        public virtual ICollection<PabellonDiploma> PabellonDiplomas { get; set; }
        public virtual ICollection<RevisionEstructura> RevisionEstructuras { get; set; }
        public virtual ICollection<SeguroEstudiantil> SeguroEstudiantils { get; set; }
        public virtual ICollection<UsuarioControl> UsuarioControls { get; set; }
    }
}
