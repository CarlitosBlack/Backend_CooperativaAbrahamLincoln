namespace Cooperativa_AbrahamLincolnApi.Entidades
{
    public class IReportes_Financieros
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public string _Fecha { get; set; }
        public string _Nombre { get; set; }
        public byte[] _Documento { get; set; }
    }
}
