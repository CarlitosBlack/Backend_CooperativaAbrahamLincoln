﻿namespace Cooperativa_AbrahamLincolnApi.Entidades
{
    public class IPedagogicos_Proyecto
    {
        public int Id { get; set; }
        public string _Nombre { get; set; }
        public decimal? MontoAutorizado { get; set; }
        public decimal MontoEjecutado { get; set; }
        public string? Situacion { get; set; }
        public string? Observaciones { get; set; }
    }
}
