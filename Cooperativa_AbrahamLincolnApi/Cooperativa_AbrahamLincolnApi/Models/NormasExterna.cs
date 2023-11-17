﻿using System;
using System.Collections.Generic;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class NormasExterna
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public byte[] Documento { get; set; } = null!;
        public string? UsuarioInsercion { get; set; }
        public DateTime? FechaInsercion { get; set; }
        public int NormasLegalesId { get; set; }

        public virtual NormasLegale NormasLegales { get; set; } = null!;
    }
}
