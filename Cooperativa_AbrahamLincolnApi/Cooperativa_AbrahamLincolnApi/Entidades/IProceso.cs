namespace Cooperativa_AbrahamLincolnApi.Entidades
{
    public class IProceso
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public string _Fecha { get; set; }
        public string _Nombre_Proceso { get; set; }

        public byte[] _Documento { get; set; }
        public string _Nombre_Documento { get; set; }
    }
}
