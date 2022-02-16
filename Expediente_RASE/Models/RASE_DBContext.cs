using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Expediente_RASE.Models
{
    public partial class RASE_DBContext : DbContext
    {
        public RASE_DBContext()
        {
        }

        public RASE_DBContext(DbContextOptions<RASE_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AntAler> AntAlers { get; set; }
        public virtual DbSet<AntHer> AntHers { get; set; }
        public virtual DbSet<AntNoPat> AntNoPats { get; set; }
        public virtual DbSet<AntOb> AntObs { get; set; }
        public virtual DbSet<AntPat> AntPats { get; set; }
        public virtual DbSet<AntPsi> AntPsis { get; set; }
        public virtual DbSet<AntQui> AntQuis { get; set; }
        public virtual DbSet<CAnt> CAnts { get; set; }
        public virtual DbSet<CEsp> CEsps { get; set; }
        public virtual DbSet<CSuc> CSucs { get; set; }
        public virtual DbSet<TConsulta> TConsulta { get; set; }
        public virtual DbSet<TDoctore> TDoctores { get; set; }
        public virtual DbSet<TInsMed> TInsMeds { get; set; }
        public virtual DbSet<TMedicina> TMedicinas { get; set; }
        public virtual DbSet<TPac> TPacs { get; set; }
        public virtual DbSet<TUsuario> TUsuarios { get; set; }
        public virtual DbSet<TratActivo> TratActivos { get; set; }
       
        private readonly IConfiguration _configuration;
        private noplisnoApplicationDbContext oContext;
        public RASE_DBContext(noplisnoApplicationDbContext context, IConfiguration configuration) //Inyeccion de una dependencia
        {
            this.oContext = context;
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Sucursal1"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<AntAler>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ANT_ALER");

                entity.Property(e => e.DescAler)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESC_ALER");

                entity.Property(e => e.IdPac).HasColumnName("ID_PAC");

                entity.Property(e => e.RegAler)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REG_ALER")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdPacNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPac)
                    .HasConstraintName("FK_ID_PAC_ANT_ALER");
            });

            modelBuilder.Entity<AntHer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ANT_HER");

                entity.Property(e => e.AnHer)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("AN_HER")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdAnt).HasColumnName("ID_ANT");

                entity.Property(e => e.IdPac).HasColumnName("ID_PAC");

                entity.Property(e => e.RegHer)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REG_HER")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdAntNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAnt)
                    .HasConstraintName("FK_ID_ANT_HER");

                entity.HasOne(d => d.IdPacNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPac)
                    .HasConstraintName("FK_ID_PAC_ANT_HER");
            });

            modelBuilder.Entity<AntNoPat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ANT_NO_PAT");

                entity.Property(e => e.AnNPat)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("AN_N_PAT")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdAnt).HasColumnName("ID_ANT");

                entity.Property(e => e.IdPac).HasColumnName("ID_PAC");

                entity.Property(e => e.RegNPat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REG_N_PAT")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdAntNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAnt)
                    .HasConstraintName("FK_ID_ANT_N_PAT");

                entity.HasOne(d => d.IdPacNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPac)
                    .HasConstraintName("FK_ID_PAC_ANT_N_PAT");
            });

            modelBuilder.Entity<AntOb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ANT_OBS");

                entity.Property(e => e.AnPsi)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("AN_PSI")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdAnt).HasColumnName("ID_ANT");

                entity.Property(e => e.IdPac).HasColumnName("ID_PAC");

                entity.HasOne(d => d.IdAntNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAnt)
                    .HasConstraintName("FK_ID_ANT_OBS");

                entity.HasOne(d => d.IdPacNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPac)
                    .HasConstraintName("FK_ID_PAC_ANT_OBS");
            });

            modelBuilder.Entity<AntPat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ANT_PAT");

                entity.Property(e => e.AnPat)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("AN_PAT")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdAnt).HasColumnName("ID_ANT");

                entity.Property(e => e.IdPac).HasColumnName("ID_PAC");

                entity.Property(e => e.RegPat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REG_PAT")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdAntNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAnt)
                    .HasConstraintName("FK_ID_ANT_PAT");

                entity.HasOne(d => d.IdPacNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPac)
                    .HasConstraintName("FK_ID_PAC_ANT_PAT");
            });

            modelBuilder.Entity<AntPsi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ANT_PSI");

                entity.Property(e => e.AnPsi)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("AN_PSI")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdAnt).HasColumnName("ID_ANT");

                entity.Property(e => e.IdPac).HasColumnName("ID_PAC");

                entity.Property(e => e.RegPsi)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REG_PSI")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdAntNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAnt)
                    .HasConstraintName("FK_ID_ANT_PSI");

                entity.HasOne(d => d.IdPacNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPac)
                    .HasConstraintName("FK_ID_PAC_ANT_PSI");
            });

            modelBuilder.Entity<AntQui>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ANT_QUI");

                entity.Property(e => e.EdadQ).HasColumnName("EDAD_Q");

                entity.Property(e => e.IdPac).HasColumnName("ID_PAC");

                entity.Property(e => e.RegQui)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REG_QUI")
                    .IsFixedLength(true);

                entity.Property(e => e.TipoQ)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_Q");

                entity.HasOne(d => d.IdPacNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPac)
                    .HasConstraintName("FK_ID_PAC_ANT_QUI");
            });

            modelBuilder.Entity<CAnt>(entity =>
            {
                entity.HasKey(e => e.IdAnt)
                    .HasName("PK__C_ANT__2A7D64511DB60CCE");

                entity.ToTable("C_ANT");

                entity.Property(e => e.IdAnt)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_ANT");

                entity.Property(e => e.NAnt)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("N_ANT");
            });

            modelBuilder.Entity<CEsp>(entity =>
            {
                entity.HasKey(e => e.IdEsp)
                    .HasName("PK__C_ESP__2D4DED3728CEB3FB");

                entity.ToTable("C_ESP");

                entity.Property(e => e.IdEsp)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_ESP");

                entity.Property(e => e.NEsp)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("N_ESP");
            });

            modelBuilder.Entity<CSuc>(entity =>
            {
                entity.HasKey(e => e.IdSuc)
                    .HasName("PK__C_SUC__27F99A817495928B");

                entity.ToTable("C_SUC");

                entity.Property(e => e.IdSuc)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_SUC");

                entity.Property(e => e.DirSuc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DIR_SUC");

                entity.Property(e => e.NomSuc)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NOM_SUC");
            });

            modelBuilder.Entity<TConsulta>(entity =>
            {
                entity.HasKey(e => e.IdCon)
                    .HasName("PK__T_CONSUL__2BF968CCB382FC5C");

                entity.ToTable("T_CONSULTA");

                entity.Property(e => e.IdCon)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_CON");

                entity.Property(e => e.Diagnostico)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("DIAGNOSTICO");

                entity.Property(e => e.Estatura).HasColumnName("ESTATURA");

                entity.Property(e => e.FechaCon)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_CON");

                entity.Property(e => e.FrecCar).HasColumnName("FREC_CAR");

                entity.Property(e => e.FrecResp).HasColumnName("FREC_RESP");

                entity.Property(e => e.GrasaCorp).HasColumnName("GRASA_CORP");

                entity.Property(e => e.IdDoc).HasColumnName("ID_DOC");

                entity.Property(e => e.IdPac).HasColumnName("ID_PAC");

                entity.Property(e => e.IdSuc).HasColumnName("ID_SUC");

                entity.Property(e => e.MasaCorp).HasColumnName("MASA_CORP");

                entity.Property(e => e.MasaMusc).HasColumnName("MASA_MUSC");

                entity.Property(e => e.Motivo)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("MOTIVO");

                entity.Property(e => e.Peso).HasColumnName("PESO");

                entity.Property(e => e.PresArt).HasColumnName("PRES_ART");

                entity.Property(e => e.SatOxigeno).HasColumnName("SAT_OXIGENO");

                entity.Property(e => e.Temperatura).HasColumnName("TEMPERATURA");

                entity.HasOne(d => d.IdDocNavigation)
                    .WithMany(p => p.TConsulta)
                    .HasForeignKey(d => d.IdDoc)
                    .HasConstraintName("FK_ID_DOC");

                entity.HasOne(d => d.IdPacNavigation)
                    .WithMany(p => p.TConsulta)
                    .HasForeignKey(d => d.IdPac)
                    .HasConstraintName("FK_ID_PAC");

                entity.HasOne(d => d.IdSucNavigation)
                    .WithMany(p => p.TConsulta)
                    .HasForeignKey(d => d.IdSuc)
                    .HasConstraintName("FK_ID_SUC");
            });

            modelBuilder.Entity<TDoctore>(entity =>
            {
                entity.HasKey(e => e.IdDoc)
                    .HasName("PK__T_DOCTOR__2BBF72881D2877F3");

                entity.ToTable("T_DOCTORES");

                entity.Property(e => e.IdDoc)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_DOC");

                entity.Property(e => e.ApMatDoc)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("AP_MAT_DOC");

                entity.Property(e => e.ApPatDoc)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("AP_PAT_DOC");

                entity.Property(e => e.CedP)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CED_P");

                entity.Property(e => e.CorreoDoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CORREO_DOC");

                entity.Property(e => e.CurpDoc)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("CURP_DOC");

                entity.Property(e => e.IdEsp).HasColumnName("ID_ESP");

                entity.Property(e => e.NomDoc)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("NOM_DOC");

                entity.Property(e => e.RecDis).HasColumnName("REC_DIS");

                entity.Property(e => e.TelDoc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TEL_DOC");

                entity.HasOne(d => d.IdEspNavigation)
                    .WithMany(p => p.TDoctores)
                    .HasForeignKey(d => d.IdEsp)
                    .HasConstraintName("FK_ID_ESP");
            });

            modelBuilder.Entity<TInsMed>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_INS_MED");

                entity.Property(e => e.Duracion)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("DURACION");

                entity.Property(e => e.Frecuencia)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FRECUENCIA");

                entity.Property(e => e.IdCon).HasColumnName("ID_CON");

                entity.Property(e => e.IdMed).HasColumnName("ID_MED");

                entity.Property(e => e.Indicaciones)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("INDICACIONES");

                entity.Property(e => e.NotasIns)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NOTAS_INS");

                entity.HasOne(d => d.IdConNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCon)
                    .HasConstraintName("FK_ID_CON");

                entity.HasOne(d => d.IdMedNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdMed)
                    .HasConstraintName("FK_ID_MED");
            });

            modelBuilder.Entity<TMedicina>(entity =>
            {
                entity.HasKey(e => e.IdMed)
                    .HasName("PK__T_MEDICI__276D18CB4F407F07");

                entity.ToTable("T_MEDICINA");

                entity.Property(e => e.IdMed)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_MED");

                entity.Property(e => e.DescMed)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESC_MED");

                entity.Property(e => e.NomMed)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NOM_MED");
            });

            modelBuilder.Entity<TPac>(entity =>
            {
                entity.HasKey(e => e.IdPac)
                    .HasName("PK__T_PAC__20AF02C4A64BECF8");

                entity.ToTable("T_PAC");

                entity.Property(e => e.IdPac)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_PAC");

                entity.Property(e => e.ApMatPac)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("AP_MAT_PAC");

                entity.Property(e => e.ApPatPac)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("AP_PAT_PAC");

                entity.Property(e => e.ArchPac)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ARCH_PAC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorreoPac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CORREO_PAC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CurpPac)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("CURP_PAC");

                entity.Property(e => e.EstCivPac)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EST_CIV_PAC");

                entity.Property(e => e.FecNacPac)
                    .HasColumnType("date")
                    .HasColumnName("FEC_NAC_PAC");

                entity.Property(e => e.NomPac)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("NOM_PAC");

                entity.Property(e => e.NotasPac)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOTAS_PAC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OcupacionPac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OCUPACION_PAC");

                entity.Property(e => e.SexoPac)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("SEXO_PAC");

                entity.Property(e => e.TSangrePac)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T_SANGRE_PAC")
                    .IsFixedLength(true);

                entity.Property(e => e.TelPac)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TEL_PAC");
            });

            modelBuilder.Entity<TUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__T_USUARI__95F48440E94A473D");

                entity.ToTable("T_USUARIOS");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_USER");

                entity.Property(e => e.CargoU)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CARGO_U");

                entity.Property(e => e.ContraU)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CONTRA_U");

                entity.Property(e => e.CorreoU)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CORREO_U");
            });

            modelBuilder.Entity<TratActivo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TRAT_ACTIVO");

                entity.Property(e => e.IdPac).HasColumnName("ID_PAC");

                entity.Property(e => e.Medic)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("MEDIC");

                entity.Property(e => e.TipoTrat)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_TRAT");

                entity.HasOne(d => d.IdPacNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPac)
                    .HasConstraintName("FK_ID_PAC_TRAT_ACT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
