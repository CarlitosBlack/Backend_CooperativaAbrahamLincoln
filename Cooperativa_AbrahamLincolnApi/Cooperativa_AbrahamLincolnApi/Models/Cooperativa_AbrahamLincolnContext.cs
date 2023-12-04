using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cooperativa_AbrahamLincolnApi.Models
{
    public partial class Cooperativa_AbrahamLincolnContext : DbContext
    {
        public Cooperativa_AbrahamLincolnContext()
        {
        }

        public Cooperativa_AbrahamLincolnContext(DbContextOptions<Cooperativa_AbrahamLincolnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActaSesionesAdministracion> ActaSesionesAdministracions { get; set; } = null!;
        public virtual DbSet<ActaSesionesVigilancium> ActaSesionesVigilancia { get; set; } = null!;
        public virtual DbSet<Apoyo> Apoyos { get; set; } = null!;
        public virtual DbSet<Asamblea> Asambleas { get; set; } = null!;
        public virtual DbSet<AsambleaGeneral> AsambleaGenerals { get; set; } = null!;
        public virtual DbSet<Colegio> Colegios { get; set; } = null!;
        public virtual DbSet<Comedor> Comedors { get; set; } = null!;
        public virtual DbSet<Comite> Comites { get; set; } = null!;
        public virtual DbSet<ComiteEduCoop> ComiteEduCoops { get; set; } = null!;
        public virtual DbSet<ComiteElectoral> ComiteElectorals { get; set; } = null!;
        public virtual DbSet<ConsejoAdministracion> ConsejoAdministracions { get; set; } = null!;
        public virtual DbSet<ConsejoVigilancium> ConsejoVigilancia { get; set; } = null!;
        public virtual DbSet<ContratosAdquisicione> ContratosAdquisiciones { get; set; } = null!;
        public virtual DbSet<Conversatorio> Conversatorios { get; set; } = null!;
        public virtual DbSet<Cooperativa> Cooperativas { get; set; } = null!;
        public virtual DbSet<Directivo> Directivos { get; set; } = null!;
        public virtual DbSet<DocumentosProcesosGerencium> DocumentosProcesosGerencia { get; set; } = null!;
        public virtual DbSet<Especiale> Especiales { get; set; } = null!;
        public virtual DbSet<EstructuraGobierno> EstructuraGobiernos { get; set; } = null!;
        public virtual DbSet<GerenciaGeneral> GerenciaGenerals { get; set; } = null!;
        public virtual DbSet<Historium> Historia { get; set; } = null!;
        public virtual DbSet<InfoGeneral> InfoGenerals { get; set; } = null!;
        public virtual DbSet<InfoSocioAdministracion> InfoSocioAdministracions { get; set; } = null!;
        public virtual DbSet<InfoSocioComiteElectoral> InfoSocioComiteElectorals { get; set; } = null!;
        public virtual DbSet<InfoSocioGerencium> InfoSocioGerencia { get; set; } = null!;
        public virtual DbSet<InfoSocioVigilancium> InfoSocioVigilancia { get; set; } = null!;
        public virtual DbSet<InfraestructuraProyecto> InfraestructuraProyectos { get; set; } = null!;
        public virtual DbSet<NormasExterna> NormasExternas { get; set; } = null!;
        public virtual DbSet<NormasInterna> NormasInternas { get; set; } = null!;
        public virtual DbSet<NormasLegale> NormasLegales { get; set; } = null!;
        public virtual DbSet<OperativosProyecto> OperativosProyectos { get; set; } = null!;
        public virtual DbSet<Organizacion> Organizacions { get; set; } = null!;
        public virtual DbSet<OrganosGestion> OrganosGestions { get; set; } = null!;
        public virtual DbSet<PabellonDiploma> PabellonDiplomas { get; set; } = null!;
        public virtual DbSet<PedagogicosProyecto> PedagogicosProyectos { get; set; } = null!;
        public virtual DbSet<Proceso> Procesos { get; set; } = null!;
        public virtual DbSet<ProcesosElectorale> ProcesosElectorales { get; set; } = null!;
        public virtual DbSet<Proyecto> Proyectos { get; set; } = null!;
        public virtual DbSet<ReportesFinanciero> ReportesFinancieros { get; set; } = null!;
        public virtual DbSet<RevisionEstructura> RevisionEstructuras { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<SeguroEstudiantil> SeguroEstudiantils { get; set; } = null!;
        public virtual DbSet<TalleresInduccion> TalleresInduccions { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<UsuarioControl> UsuarioControls { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Cooperativa_AbrahamLincoln;Integrated Security=SSPI; User ID=sa;Password=;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActaSesionesAdministracion>(entity =>
            {
                entity.ToTable("acta_sesiones_administracion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConsejoAdministracionId).HasColumnName("consejo_administracion_id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.AnioActas)
                    .HasMaxLength(30)
                    .HasColumnName("anio_actas");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.ConsejoAdministracion)
                    .WithMany(p => p.ActaSesionesAdministracions)
                    .HasForeignKey(d => d.ConsejoAdministracionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("acta_sesiones_consejo_administracion");
            });

            modelBuilder.Entity<ActaSesionesVigilancium>(entity =>
            {
                entity.ToTable("acta_sesiones_vigilancia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConsejoVigilanciaId).HasColumnName("consejo_vigilancia_id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.ConsejoVigilancia)
                    .WithMany(p => p.ActaSesionesVigilancia)
                    .HasForeignKey(d => d.ConsejoVigilanciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Copy_of_acta_sesiones_consejo_vigilancia");
            });

            modelBuilder.Entity<Apoyo>(entity =>
            {
                entity.ToTable("apoyo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ComitesId).HasColumnName("comites_id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.Comites)
                    .WithMany(p => p.Apoyos)
                    .HasForeignKey(d => d.ComitesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("apoyo_comites");
            });

            modelBuilder.Entity<Asamblea>(entity =>
            {
                entity.ToTable("asambleas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Actas).HasColumnName("actas");

                entity.Property(e => e.Acuerdos).HasColumnName("acuerdos");

                entity.Property(e => e.Anexos).HasColumnName("anexos");

                entity.Property(e => e.AsambleaGeneralId).HasColumnName("asamblea_general_id");

                entity.Property(e => e.Convocatoria).HasColumnName("convocatoria");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.AsambleaGeneral)
                    .WithMany(p => p.Asambleas)
                    .HasForeignKey(d => d.AsambleaGeneralId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("asamblea_asamblea_general");
            });

            modelBuilder.Entity<AsambleaGeneral>(entity =>
            {
                entity.ToTable("asamblea_general");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_id");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.AsambleaGenerals)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("asamblea_general_usuarios");
            });

            modelBuilder.Entity<Colegio>(entity =>
            {
                entity.ToTable("colegio");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Anexo).HasColumnName("anexo");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NombreCargo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_cargo");

                entity.Property(e => e.OrganosGestionId).HasColumnName("organos_gestion_id");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.OrganosGestion)
                    .WithMany(p => p.Colegios)
                    .HasForeignKey(d => d.OrganosGestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("colegio_organos_gestion");
            });

            modelBuilder.Entity<Comedor>(entity =>
            {
                entity.ToTable("comedor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_id");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.Comedors)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_50_usuarios");
            });

            modelBuilder.Entity<Comite>(entity =>
            {
                entity.ToTable("comites");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_id");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.Comites)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comites_usuarios");
            });

            modelBuilder.Entity<ComiteEduCoop>(entity =>
            {
                entity.ToTable("comite_edu_coop");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_id");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.ComiteEduCoops)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comite_edu_coop_usuarios");
            });

            modelBuilder.Entity<ComiteElectoral>(entity =>
            {
                entity.ToTable("comite_electoral");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_id");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.ComiteElectorals)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comite_electoral_usuarios");
            });

            modelBuilder.Entity<ConsejoAdministracion>(entity =>
            {
                entity.ToTable("consejo_administracion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_id");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.ConsejoAdministracions)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("consejo_administracion_usuarios");
            });

            modelBuilder.Entity<ConsejoVigilancium>(entity =>
            {
                entity.ToTable("consejo_vigilancia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_id");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.ConsejoVigilancia)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("consejo_vigilancia_usuarios");
            });

            modelBuilder.Entity<ContratosAdquisicione>(entity =>
            {
                entity.ToTable("contratos_adquisiciones");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                entity.Property(e => e.ConsejoAdministracionId).HasColumnName("consejo_administracion_id");

                entity.Property(e => e.Document).HasColumnName("document");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.ConsejoAdministracion)
                    .WithMany(p => p.ContratosAdquisiciones)
                    .HasForeignKey(d => d.ConsejoAdministracionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contratos_adquisiciones_consejo_administracion");
            });

            modelBuilder.Entity<Conversatorio>(entity =>
            {
                entity.ToTable("conversatorios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ComiteEduCoopId).HasColumnName("comite_edu_coop_id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.ComiteEduCoop)
                    .WithMany(p => p.Conversatorios)
                    .HasForeignKey(d => d.ComiteEduCoopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("conversatorios_comite_edu_coop");
            });

            modelBuilder.Entity<Cooperativa>(entity =>
            {
                entity.ToTable("cooperativa");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Anexo).HasColumnName("anexo");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NombreCargo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_cargo");

                entity.Property(e => e.OrganosGestionId).HasColumnName("organos_gestion_id");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.OrganosGestion)
                    .WithMany(p => p.Cooperativas)
                    .HasForeignKey(d => d.OrganosGestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cooperativa_organos_gestion");
            });

            modelBuilder.Entity<Directivo>(entity =>
            {
                entity.ToTable("directivos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cargo");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.OrganizacionId).HasColumnName("organizacion_id");

                entity.Property(e => e.TipoEquipo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipo_equipo");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.Organizacion)
                    .WithMany(p => p.Directivos)
                    .HasForeignKey(d => d.OrganizacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("directivos_organizacion");
            });

            modelBuilder.Entity<DocumentosProcesosGerencium>(entity =>
            {
                entity.ToTable("documentos_procesos_gerencia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.NombreDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_documento");

                entity.Property(e => e.ProcesosId).HasColumnName("procesos_id");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.Procesos)
                    .WithMany(p => p.DocumentosProcesosGerencia)
                    .HasForeignKey(d => d.ProcesosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("documentos_procesos_gerencia_procesos");
            });

            modelBuilder.Entity<Especiale>(entity =>
            {
                entity.ToTable("especiales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ComitesId).HasColumnName("comites_id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.Comites)
                    .WithMany(p => p.Especiales)
                    .HasForeignKey(d => d.ComitesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("especiales_comites");
            });

            modelBuilder.Entity<EstructuraGobierno>(entity =>
            {
                entity.ToTable("estructura_gobierno");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.NombreDocumento)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_documento");

                entity.Property(e => e.OrganizacionId).HasColumnName("organizacion_id");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.Organizacion)
                    .WithMany(p => p.EstructuraGobiernos)
                    .HasForeignKey(d => d.OrganizacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estructura_gobierno_organizacion");
            });

            modelBuilder.Entity<GerenciaGeneral>(entity =>
            {
                entity.ToTable("gerencia_general");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_id");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.GerenciaGenerals)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gerencia_general_usuarios");
            });

            modelBuilder.Entity<Historium>(entity =>
            {
                entity.ToTable("historia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_id");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.Historia)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("historia_usuarios");
            });

            modelBuilder.Entity<InfoGeneral>(entity =>
            {
                entity.ToTable("info_general");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ComiteEduCoopId).HasColumnName("comite_edu_coop_id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.ComiteEduCoop)
                    .WithMany(p => p.InfoGenerals)
                    .HasForeignKey(d => d.ComiteEduCoopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("info_general_comite_edu_coop");
            });

            modelBuilder.Entity<InfoSocioAdministracion>(entity =>
            {
                entity.ToTable("info_socio_administracion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                entity.Property(e => e.ConsejoAdministracionId).HasColumnName("consejo_administracion_id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.ConsejoAdministracion)
                    .WithMany(p => p.InfoSocioAdministracions)
                    .HasForeignKey(d => d.ConsejoAdministracionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("info_socio_consejo_administracion");
            });

            modelBuilder.Entity<InfoSocioComiteElectoral>(entity =>
            {
                entity.ToTable("info_socio_comite_electoral");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                entity.Property(e => e.ComiteElectoralId).HasColumnName("comite_electoral_id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.ComiteElectoral)
                    .WithMany(p => p.InfoSocioComiteElectorals)
                    .HasForeignKey(d => d.ComiteElectoralId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Copy_of_acta_sesiones_comite_electoral");
            });

            modelBuilder.Entity<InfoSocioGerencium>(entity =>
            {
                entity.ToTable("info_socio_gerencia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.GerenciaGeneralId).HasColumnName("gerencia_general_id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.GerenciaGeneral)
                    .WithMany(p => p.InfoSocioGerencia)
                    .HasForeignKey(d => d.GerenciaGeneralId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("info_socio_gerencia_general");
            });

            modelBuilder.Entity<InfoSocioVigilancium>(entity =>
            {
                entity.ToTable("info_socio_vigilancia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                entity.Property(e => e.ConsejoVigilanciaId).HasColumnName("consejo_vigilancia_id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.ConsejoVigilancia)
                    .WithMany(p => p.InfoSocioVigilancia)
                    .HasForeignKey(d => d.ConsejoVigilanciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Copy_of_info_socio_consejo_vigilancia");
            });

            modelBuilder.Entity<InfraestructuraProyecto>(entity =>
            {
                entity.ToTable("infraestructura_proyectos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.MontoAutorizado)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("monto_autorizado");

                entity.Property(e => e.MontoEjecutado)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("monto_ejecutado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("observaciones");

                entity.Property(e => e.ProyectosId).HasColumnName("proyectos_id");

                entity.Property(e => e.Situacion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("situacion");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.Proyectos)
                    .WithMany(p => p.InfraestructuraProyectos)
                    .HasForeignKey(d => d.ProyectosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("infraestructura_proyectos_proyectos");
            });

            modelBuilder.Entity<NormasExterna>(entity =>
            {
                entity.ToTable("normas_externas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NormasLegalesId).HasColumnName("normas_legales_id");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.NormasLegales)
                    .WithMany(p => p.NormasExternas)
                    .HasForeignKey(d => d.NormasLegalesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("normas_externas_normas_legales");
            });

            modelBuilder.Entity<NormasInterna>(entity =>
            {
                entity.ToTable("normas_internas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NormasLegalesId).HasColumnName("normas_legales_id");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.NormasLegales)
                    .WithMany(p => p.NormasInternas)
                    .HasForeignKey(d => d.NormasLegalesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("normas_internas_normas_legales");
            });

            modelBuilder.Entity<NormasLegale>(entity =>
            {
                entity.ToTable("normas_legales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_id");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.NormasLegales)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("normas_legales_usuarios");
            });

            modelBuilder.Entity<OperativosProyecto>(entity =>
            {
                entity.ToTable("operativos_proyectos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.MontoAutorizado)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("monto_autorizado");

                entity.Property(e => e.MontoEjecutado)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("monto_ejecutado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("observaciones");

                entity.Property(e => e.ProyectosId).HasColumnName("proyectos_id");

                entity.Property(e => e.Situacion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("situacion");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.Proyectos)
                    .WithMany(p => p.OperativosProyectos)
                    .HasForeignKey(d => d.ProyectosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("operativos_proyectos_proyectos");
            });

            modelBuilder.Entity<Organizacion>(entity =>
            {
                entity.ToTable("organizacion");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_id");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.Organizacions)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("organizacion_usuarios");
            });

            modelBuilder.Entity<OrganosGestion>(entity =>
            {
                entity.ToTable("organos_gestion");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_id");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.OrganosGestions)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("organos_gestion_usuarios");
            });

            modelBuilder.Entity<PabellonDiploma>(entity =>
            {
                entity.ToTable("pabellon_diploma");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_id");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.PabellonDiplomas)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("procesos_anteriores_usuarios");
            });

            modelBuilder.Entity<PedagogicosProyecto>(entity =>
            {
                entity.ToTable("pedagogicos_proyectos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.MontoAutorizado)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("monto_autorizado");

                entity.Property(e => e.MontoEjecutado)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("monto_ejecutado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("observaciones");

                entity.Property(e => e.ProyectosId).HasColumnName("proyectos_id");

                entity.Property(e => e.Situacion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("situacion");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.Proyectos)
                    .WithMany(p => p.PedagogicosProyectos)
                    .HasForeignKey(d => d.ProyectosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pedagogicos_proyectos_proyectos");
            });

            modelBuilder.Entity<Proceso>(entity =>
            {
                entity.ToTable("procesos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                //entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.GerenciaGeneralId).HasColumnName("gerencia_general_id");

                entity.Property(e => e.NombreProceso)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombre_proceso");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.GerenciaGeneral)
                    .WithMany(p => p.Procesos)
                    .HasForeignKey(d => d.GerenciaGeneralId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("procesos_gerencia_general");
            });

            modelBuilder.Entity<ProcesosElectorale>(entity =>
            {
                entity.ToTable("procesos_electorales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ComiteElectoralId).HasColumnName("comite_electoral_id");

                entity.Property(e => e.Document).HasColumnName("document");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.ComiteElectoral)
                    .WithMany(p => p.ProcesosElectorales)
                    .HasForeignKey(d => d.ComiteElectoralId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("procesos_electorales_comite_electoral");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.ToTable("proyectos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConsejoAdministracionId).HasColumnName("consejo_administracion_id");

                entity.HasOne(d => d.ConsejoAdministracion)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.ConsejoAdministracionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("proyectos_consejo_administracion");
            });

            modelBuilder.Entity<ReportesFinanciero>(entity =>
            {
                entity.ToTable("reportes_financieros");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                entity.Property(e => e.ConsejoAdministracionId).HasColumnName("consejo_administracion_id");

                entity.Property(e => e.Document).HasColumnName("document");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.ConsejoAdministracion)
                    .WithMany(p => p.ReportesFinancieros)
                    .HasForeignKey(d => d.ConsejoAdministracionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reportes_financieros_consejo_administracion");
            });

            modelBuilder.Entity<RevisionEstructura>(entity =>
            {
                entity.ToTable("revision_estructura");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_id");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.RevisionEstructuras)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("procesos_usuarios");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRoles)
                    .HasName("roles_pk");

                entity.ToTable("roles");

                entity.Property(e => e.IdRoles).HasColumnName("id_roles");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<SeguroEstudiantil>(entity =>
            {
                entity.ToTable("seguro_estudiantil");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_id");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.SeguroEstudiantils)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("seguro_estudiantil_usuarios");
            });

            modelBuilder.Entity<TalleresInduccion>(entity =>
            {
                entity.ToTable("talleres_induccion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ComiteEduCoopId).HasColumnName("comite_edu_coop_id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaInsercion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_insercion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioInsercion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_insercion");

                entity.HasOne(d => d.ComiteEduCoop)
                    .WithMany(p => p.TalleresInduccions)
                    .HasForeignKey(d => d.ComiteEduCoopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("talleres_induccion_comite_edu_coop");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("contrasena");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.RolesIdRoles).HasColumnName("roles_id_roles");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.RolesIdRolesNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RolesIdRoles)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_roles");
            });

            modelBuilder.Entity<UsuarioControl>(entity =>
            {
                entity.HasKey(e => e.IdDescarga)
                    .HasName("usuario_control_pk");

                entity.ToTable("usuario_control");

                entity.Property(e => e.IdDescarga).HasColumnName("id_descarga");

                entity.Property(e => e.FechaDescarga)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_descarga");

                entity.Property(e => e.NombreDocumento)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_documento");

                entity.Property(e => e.NombreElemento)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_elemento");

                entity.Property(e => e.UsuarioDescarga)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("usuario_descarga");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_id");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.UsuarioControls)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_control_usuarios");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
