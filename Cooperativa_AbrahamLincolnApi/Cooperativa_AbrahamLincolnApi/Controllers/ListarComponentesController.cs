using Cooperativa_AbrahamLincolnApi.Entidades;
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


        // --------------------------------------------------------------
        // Categoria Raiz Organización
        [HttpGet("estructura_gobierno")]
        public ActionResult<IEnumerable<IEstructura_Gobierno>> ListarEstructuraGobierno()
        {
            //var query = from x in db.EstructuraGobiernos select x;
            var query = from x in db.EstructuraGobiernos select new IEstructura_Gobierno
            { Id = x.Id, Nombre_doc = x.NombreDocumento, Documentos = x.Documento};
            return query.ToList();
        }

        [HttpGet("directivos")]
        public ActionResult<IEnumerable<IDirectivos>> ListarDirectivos()
        {
            //var query = from x in db.Directivos select x;
            var query = from x in db.Directivos select new IDirectivos
            { Id = x.Id, Tipo_Equipo = x.TipoEquipo, _Nombre = x.Nombre, _Cargo = x.Cargo};
            return query.ToList();
        }

        // --------------------------------------------------------------
        // Categoria Raiz Organos de Gestion
        [HttpGet("cooperativa")]
        public ActionResult<IEnumerable<ICooperativa>> ListarCooperativa()
        {
            //var query = from x in db.Cooperativas select x;
            var query = from x in db.Cooperativas select new ICooperativa
            { Id = x.Id, Nombre_Cargo = x.NombreCargo, _Nombre = x.Nombre, _Correo = x.Correo, _Anexo = x.Anexo };
            return query.ToList();
        }

        [HttpGet("colegio")]
        public ActionResult<IEnumerable<IColegio>> ListarColegio()
        {
            //var query = from x in db.Colegios select x;
            var query = from x in db.Cooperativas
                        select new IColegio
                        { Id = x.Id, Nombre_Cargo = x.NombreCargo, _Nombre = x.Nombre, _Correo = x.Correo, _Anexo = x.Anexo };
            return query.ToList();
        }

        // ---
        // Categoria Raiz Asamblea General
        [HttpGet("asambleas")]
        public ActionResult<IEnumerable<IAsambleas>> ListarAsamblea()
        {
            //var query = from x in db.Asambleas select x;
            var query = from x in db.Asambleas select new IAsambleas
            { Id = x.Id, _Nombre = x.Nombre , _Fecha = x.Fecha.ToShortDateString(), _Convocatoria = x.Convocatoria, _Actas = x.Actas, _Anexos = x.Anexos, _Acuerdos = x.Acuerdos };
            return query.ToList();
        }

        // ---
        // Categoria Raiz Consejo de Administracion
        [HttpGet("actas_sesiones_administracion")]
        public ActionResult<IEnumerable<IActas_Sesiones_Administracion>> ListarActasSecionesAdministracion()
        {
            var query = from x in db.ActaSesionesAdministracions select new IActas_Sesiones_Administracion
                        { Id = x.Id, _AnioActas=x.AnioActas, _Documento=x.Documento, _Nombre=x.Nombre  } ;
            return query.ToList();
        }

        [HttpGet("informacion_socio_administracion")]
        public ActionResult<IEnumerable<IInfo_Socio_Administracion>> ListarInfoSocioAdministracion()
        {
            //var query = from x in db.InfoSocioAdministracions select x;
            var query = from x in db.InfoSocioAdministracions
                        select new IInfo_Socio_Administracion
                        { Id = x.Id, Categoria = x.Categoria, _Fecha = x.Fecha.ToShortDateString(), _Documento = x.Documento, _Nombre = x.Nombre };
            return query.ToList();
        }

        [HttpGet("reportes_financieros")]
        public ActionResult<IEnumerable<IReportes_Financieros>> ListarReportesFinanciero()
        {
            //var query = from x in db.ReportesFinancieros select x;
            var query = from x in db.ReportesFinancieros
                        select new IReportes_Financieros
                        { Id = x.Id, Categoria = x.Categoria, _Fecha = x.Fecha.ToShortDateString(), _Documento = x.Document, _Nombre = x.Name };
            return query.ToList();
        }

        //subcategoria de Consejo de Administracion : Proyectos
        [HttpGet("infraestructura_proyectos")]
        public ActionResult<IEnumerable<IInfraestructura_Proyecto>> ListarInfraestructuraProyecto()
        {
            var query = from x in db.InfraestructuraProyectos select new IInfraestructura_Proyecto
            { Id=x.Id, _Nombre=x.Nombre, MontoAutorizado=x.MontoAutorizado, MontoEjecutado=x.MontoEjecutado, Situacion=x.Situacion, Observaciones=x.Observaciones  };
            return query.ToList();
        }

        [HttpGet("operativos_proyectos")]
        public ActionResult<IEnumerable<IOperativos_Proyecto>> ListarOperativosProyecto()
        {
            var query = from x in db.OperativosProyectos select new IOperativos_Proyecto
            { Id = x.Id, _Nombre = x.Nombre, MontoAutorizado = x.MontoAutorizado, MontoEjecutado = x.MontoEjecutado, Situacion = x.Situacion, Observaciones = x.Observaciones  };
            return query.ToList();
        }

        [HttpGet("pedagogicos_proyectos")]
        public ActionResult<IEnumerable<IPedagogicos_Proyecto>> ListarPedagogicosProyecto()
        {
            var query = from x in db.PedagogicosProyectos select new IPedagogicos_Proyecto
            { Id = x.Id, _Nombre = x.Nombre, MontoAutorizado = x.MontoAutorizado, MontoEjecutado = x.MontoEjecutado, Situacion = x.Situacion, Observaciones = x.Observaciones  };
            return query.ToList();
        }

        [HttpGet("contratos_adquisiciones")]
        public ActionResult<IEnumerable<IContratos_Adquisiciones>> ListarContratosAdquisiciones()
        {
            var query = from x in db.ContratosAdquisiciones select new IContratos_Adquisiciones
            { Id = x.Id, Categoria = x.Categoria, _Documento = x.Document, _Nombre = x.Nombre };
            return query.ToList();
        }

        // ---
        // Categoria Raiz Consejo de Vigilancia
        [HttpGet("actas_sesiones_vigilancia")]
        public ActionResult<IEnumerable<IActa_Sesiones_Vigilancia>> ListarActaSesionesVigilancium()
        {
            var query = from x in db.ActaSesionesVigilancia select new IActa_Sesiones_Vigilancia
            { Id = x.Id, _Nombre = x.Nombre, _Fecha = x.Fecha.ToShortDateString(), _Documento = x.Documento  };
            return query.ToList();
        }

        [HttpGet("informacion_socio_vigilancia")]
        public ActionResult<IEnumerable<IInfo_Socio_Vigilancia>> ListarInfoSocioVigilancium()
        {
            var query = from x in db.InfoSocioVigilancia select new IInfo_Socio_Vigilancia
            { Id = x.Id, _Nombre = x.Nombre, _Fecha = x.Fecha.ToShortDateString(), _Documento = x.Documento  };
            return query.ToList();
        }

        // ---
        // Categoria Raiz Comite Electoral
        [HttpGet("procesos_electorales")]
        public ActionResult<IEnumerable<IProcesos_Electorale>> ListarProcesosElectorales()
        {
            var query = from x in db.ProcesosElectorales select new IProcesos_Electorale
            { Id = x.Id, _Fecha = x.Fecha.ToShortDateString(), _Nombre = x.Nombre,  _Documento = x.Document  };
            return query.ToList();
        }

        [HttpGet("informacion_socio_procesos_electorales")]
        public ActionResult<IEnumerable<IInfo_Socio_Comite_Electoral>> ListarInfoSocioComiteElectoral()
        {
            var query = from x in db.InfoSocioComiteElectorals select new IInfo_Socio_Comite_Electoral
            { Id = x.Id, Categoria=x.Categoria, _Nombre = x.Nombre, _Fecha = x.Fecha.ToShortDateString(), _Documento = x.Documento  };
            return query.ToList();
        }

        // ---
        // Categoria Raiz Comite Educacional Coorporativo
        [HttpGet("informacion_general")]
        public ActionResult<IEnumerable<IInfo_General>> ListarInfoGeneral()
        {
            var query = from x in db.InfoGenerals select new IInfo_General
            { Id = x.Id,  _Nombre = x.Nombre, _Fecha = x.Fecha.ToShortDateString(), _Documento = x.Documento };
            return query.ToList();
        }

        [HttpGet("conversatorios")]
        public ActionResult<IEnumerable<IConversatorio>> ListarConversatorio()
        {
            var query = from x in db.Conversatorios select new IConversatorio
            { Id = x.Id,  _Nombre = x.Nombre, _Fecha = x.Fecha.ToShortDateString(), _Documento = x.Documento };
            return query.ToList();
        }

        [HttpGet("talleres_de_induccion")]
        public ActionResult<IEnumerable<ITalleres_Induccion>> ListarTalleresInduccion()
        {
            var query = from x in db.TalleresInduccions select new ITalleres_Induccion
            { Id = x.Id, _Nombre = x.Nombre, _Fecha = x.Fecha.ToShortDateString(), _Documento = x.Documento };
            return query.ToList();
        }

        // ---
        // Categoria Raiz Gerencia General
        [HttpGet("informacion_socio_gerencia")]
        public ActionResult<IEnumerable<IInfo_Socio_Gerencia>> ListarInfoSocioGerencium()
        {
            var query = from x in db.InfoSocioGerencia select new IInfo_Socio_Gerencia
            { Id = x.Id, Categoria = x.Categoria, _Fecha = x.Fecha.ToShortDateString(), _Nombre = x.Nombre,  _Documento = x.Documento  };
            return query.ToList();
        }

        [HttpGet("procesos")]
        public ActionResult<IEnumerable<IProceso>> ListarProcesos()
        {
            var query = from x in db.Procesos join y in db.DocumentosProcesosGerencia on x.Id equals y.Id
                        select new IProceso
            { Id = x.Id, Categoria = x.Categoria, _Fecha = x.Fecha.ToShortDateString(), _Nombre_Proceso = x.NombreProceso, _Nombre_Documento= y.NombreDocumento, _Documento = y.Documento  };
            return query.ToList();
        }

        // ---
        // Categoria Raiz Comites
        [HttpGet("apoyo")]
        public ActionResult<IEnumerable<IApoyo>> ListarApoyo()
        {
            var query = from x in db.Apoyos select new IApoyo
            { Id = x.Id, _Nombre = x.Nombre,  _Documento = x.Documento };
            return query.ToList();
        }

        [HttpGet("especiales")]
        public ActionResult<IEnumerable<IEspeciales>> ListarEspeciales()
        {
            var query = from x in db.Especiales select new IEspeciales
            { Id = x.Id, _Nombre = x.Nombre,  _Documento = x.Documento };
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
