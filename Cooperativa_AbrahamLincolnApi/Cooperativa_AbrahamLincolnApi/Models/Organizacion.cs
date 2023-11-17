using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class Organizacion
    {
        public Organizacion()
        {
            Directivos = new HashSet<Directivo>();
            EstructuraGobiernos = new HashSet<EstructuraGobierno>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int UsuariosId { get; set; }

        public virtual Usuario Usuarios { get; set; } = null!;
        public virtual ICollection<Directivo> Directivos { get; set; }
        public virtual ICollection<EstructuraGobierno> EstructuraGobiernos { get; set; }
    }
}
