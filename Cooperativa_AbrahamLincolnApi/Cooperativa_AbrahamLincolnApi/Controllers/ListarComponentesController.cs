using Cooperativa_AbrahamLincolnApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cooperativa_AbrahamLincolnApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListarComponentesController : ControllerBase
    {
        Cooperativa_AbrahamLincolnContext db = new Cooperativa_AbrahamLincolnContext();


        // ---
        // Categoria Raiz Organización
        [HttpGet("estructura_gobierno")]
        public ActionResult<IEnumerable<EstructuraGobierno>> ListarEstructuraGobierno()
        {
            var query = from x in db.EstructuraGobiernos select x;
            return query.ToList();
        }

        [HttpGet("directivos")]
        public ActionResult<IEnumerable<Directivo>> ListarDirectivos()
        {
            var query = from x in db.Directivos select x;
            return query.ToList();
        }

        // ---
        // Categoria Raiz Organos de Gestion
        [HttpGet("cooperativa")]
        public ActionResult<IEnumerable<Cooperativa>> ListarCooperativa()
        {
            var query = from x in db.Cooperativas select x;
            return query.ToList();
        }

        [HttpGet("colegio")]
        public ActionResult<IEnumerable<Colegio>> ListarColegio()
        {
            var query = from x in db.Colegios select x;
            return query.ToList();
        }

        // ---
        // Categoria Raiz Asamblea General
        [HttpGet("asambleas")]
        public ActionResult<IEnumerable<Asamblea>> ListarAsamblea()
        {
            var query = from x in db.Asambleas select x;
            return query.ToList();
        }

        // ---
        // Categoria Raiz Consejo de Administracion
        [HttpGet("actas_sesiones_administracion")]
        public ActionResult<IEnumerable<ActaSesionesAdministracion>> ListarActasSecionesAdministracion()
        {
            var query = from x in db.ActaSesionesAdministracions select x;
            return query.ToList();
        }

        [HttpGet("informacion_socio_administracion")]
        public ActionResult<IEnumerable<InfoSocioAdministracion>> ListarInfoSocioAdministracion()
        {
            var query = from x in db.InfoSocioAdministracions select x;
            return query.ToList();
        }

        [HttpGet("reportes_financieros")]
        public ActionResult<IEnumerable<ReportesFinanciero>> ListarReportesFinanciero()
        {
            var query = from x in db.ReportesFinancieros select x;
            return query.ToList();
        }

        //subcategoria de Consejo de Administracion : Proyectos
        [HttpGet("infraestructura_proyectos")]
        public ActionResult<IEnumerable<InfraestructuraProyecto>> ListarInfraestructuraProyecto()
        {
            var query = from x in db.InfraestructuraProyectos select x;
            return query.ToList();
        }

        [HttpGet("operativos_proyectos")]
        public ActionResult<IEnumerable<OperativosProyecto>> ListarOperativosProyecto()
        {
            var query = from x in db.OperativosProyectos select x;
            return query.ToList();
        }

        [HttpGet("pedagogicos_proyectos")]
        public ActionResult<IEnumerable<PedagogicosProyecto>> ListarPedagogicosProyecto()
        {
            var query = from x in db.PedagogicosProyectos select x;
            return query.ToList();
        }

        [HttpGet("contratos_adquisiciones")]
        public ActionResult<IEnumerable<ContratosAdquisicione>> ListarContratosAdquisiciones()
        {
            var query = from x in db.ContratosAdquisiciones select x;
            return query.ToList();
        }

        // ---
        // Categoria Raiz Consejo de Vigilancia
        [HttpGet("actas_seciones_vigilancia")]
        public ActionResult<IEnumerable<ActaSesionesVigilancium>> ListarActaSesionesVigilancium()
        {
            var query = from x in db.ActaSesionesVigilancia select x;
            return query.ToList();
        }

        [HttpGet("informacion_socio_vigilancia")]
        public ActionResult<IEnumerable<InfoSocioVigilancium>> ListarInfoSocioVigilancium()
        {
            var query = from x in db.InfoSocioVigilancia select x;
            return query.ToList();
        }

        // ---
        // Categoria Raiz Comite Electoral
        [HttpGet("procesos_electorales")]
        public ActionResult<IEnumerable<ProcesosElectorale>> ListarProcesosElectorales()
        {
            var query = from x in db.ProcesosElectorales select x;
            return query.ToList();
        }

        [HttpGet("informacion_socio_procesos_electorales")]
        public ActionResult<IEnumerable<InfoSocioComiteElectoral>> ListarInfoSocioComiteElectoral()
        {
            var query = from x in db.InfoSocioComiteElectorals select x;
            return query.ToList();
        }

        // ---
        // Categoria Raiz Comite Educacional Coorporativo
        [HttpGet("informacion_general")]
        public ActionResult<IEnumerable<InfoGeneral>> ListarInfoGeneral()
        {
            var query = from x in db.InfoGenerals select x;
            return query.ToList();
        }

        [HttpGet("conversatorios")]
        public ActionResult<IEnumerable<Conversatorio>> ListarConversatorio()
        {
            var query = from x in db.Conversatorios select x;
            return query.ToList();
        }

        [HttpGet("talleres_de_induccion")]
        public ActionResult<IEnumerable<TalleresInduccion>> ListarTalleresInduccion()
        {
            var query = from x in db.TalleresInduccions select x;
            return query.ToList();
        }

        // ---
        // Categoria Raiz Gerencia General
        [HttpGet("informacion_socio_gerencia")]
        public ActionResult<IEnumerable<InfoSocioGerencium>> ListarInfoSocioGerencium()
        {
            var query = from x in db.InfoSocioGerencia select x;
            return query.ToList();
        }

        [HttpGet("procesos")]
        public ActionResult<IEnumerable<Proceso>> ListarProcesos()
        {
            var query = from x in db.Procesos select x;
            return query.ToList();
        }

        // ---
        // Categoria Raiz Comites
        [HttpGet("apoyo")]
        public ActionResult<IEnumerable<Apoyo>> ListarApoyo()
        {
            var query = from x in db.Apoyos select x;
            return query.ToList();
        }

        [HttpGet("especiales")]
        public ActionResult<IEnumerable<Especiale>> ListarEspeciales()
        {
            var query = from x in db.Especiales select x;
            return query.ToList();
        }

        // ETIQUETAS 
        // etiquetas sueltas columna izquierda abajo:
        [HttpGet("revision_estructura")]
        public ActionResult<IEnumerable<RevisionEstructura>> ListarRevisionEstructura()
        {
            var query = from x in db.RevisionEstructuras select x;
            return query.ToList();
        }

        [HttpGet("pabellon_diploma")]
        public ActionResult<IEnumerable<PabellonDiploma>> ListarPabellonDiploma()
        {
            var query = from x in db.PabellonDiplomas select x;
            return query.ToList();
        }

        [HttpGet("comedor")]
        public ActionResult<IEnumerable<Comedor>> ListarComedor()
        {
            var query = from x in db.Comedors select x;
            return query.ToList();
        }


        // pestañas arriba:
        [HttpGet("historia")]
        public ActionResult<IEnumerable<Historium>> ListarHistorium()
        {
            var query = from x in db.Historia select x;
            return query.ToList();
        }

        [HttpGet("normas_internas")]
        public ActionResult<IEnumerable<NormasInterna>> ListarNormasInterna()
        {
            var query = from x in db.NormasInternas select x;
            return query.ToList();
        }

        [HttpGet("normas_externa")]
        public ActionResult<IEnumerable<NormasExterna>> ListarNormasExterna()
        {
            var query = from x in db.NormasExternas select x;
            return query.ToList();
        }

        [HttpGet("seguro_estudiantil")]
        public ActionResult<IEnumerable<SeguroEstudiantil>> ListarSeguroEstudiantil()
        {
            var query = from x in db.SeguroEstudiantils select x;
            return query.ToList();
        }




    }
}
