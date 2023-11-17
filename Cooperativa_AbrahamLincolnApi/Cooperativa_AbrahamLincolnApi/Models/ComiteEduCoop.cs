using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class ComiteEduCoop
    {
        public ComiteEduCoop()
        {
            Conversatorios = new HashSet<Conversatorio>();
            InfoGenerals = new HashSet<InfoGeneral>();
            TalleresInduccions = new HashSet<TalleresInduccion>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int UsuariosId { get; set; }

        public virtual Usuario Usuarios { get; set; } = null!;
        public virtual ICollection<Conversatorio> Conversatorios { get; set; }
        public virtual ICollection<InfoGeneral> InfoGenerals { get; set; }
        public virtual ICollection<TalleresInduccion> TalleresInduccions { get; set; }
    }
}
