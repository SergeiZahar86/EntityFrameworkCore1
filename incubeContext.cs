using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Protocols;

namespace EntityFrameworkCore1
{
    public partial class incubeContext : DbContext
    {
        public incubeContext()
        {
        }

        public incubeContext(DbContextOptions<incubeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SpCause> SpCause { get; set; }
        public virtual DbSet<SpContractor> SpContractor { get; set; }
        public virtual DbSet<SpMat> SpMat { get; set; }
        public virtual DbSet<SpUsers> SpUsers { get; set; }
        public virtual DbSet<TbCar> TbCar { get; set; }
        public virtual DbSet<TbPart> TbPart { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=10.90.90.58,1480;Initial Catalog=incube;Persist Security Info=True;User ID=sa;Password=111zzz***;");
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString); // принимает из App.config
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpCause>(entity =>
            {
                entity.HasKey(e => e.CauseId)
                    .HasName("pk_cause_id");

                entity.ToTable("sp_cause");

                entity.Property(e => e.CauseId)
                    .HasColumnName("cause_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<SpContractor>(entity =>
            {
                entity.HasKey(e => e.ContractorId)
                    .HasName("pk_contractor_id");

                entity.ToTable("sp_contractor");

                entity.Property(e => e.ContractorId)
                    .HasColumnName("contractor_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Consigner).HasColumnName("consigner");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Shipper).HasColumnName("shipper");
            });

            modelBuilder.Entity<SpMat>(entity =>
            {
                entity.HasKey(e => e.MatId)
                    .HasName("pk_mat_id");

                entity.ToTable("sp_mat");

                entity.Property(e => e.MatId)
                    .HasColumnName("mat_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SpUsers>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("pk_user_id");

                entity.ToTable("sp_users");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmplId)
                    .HasColumnName("empl_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fio)
                    .IsRequired()
                    .HasColumnName("fio")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCar>(entity =>
            {
                entity.HasKey(e => new { e.PartId, e.CarId })
                    .HasName("pk_tb_car");

                entity.ToTable("tb_car");

                entity.Property(e => e.PartId).HasColumnName("part_id");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.AttCode).HasColumnName("att_code");

                entity.Property(e => e.AttTime)
                    .HasColumnName("att_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Brutto).HasColumnName("brutto");

                entity.Property(e => e.CarryingE).HasColumnName("carrying_e");

                entity.Property(e => e.CauseId).HasColumnName("cause_id");

                entity.Property(e => e.Consigner).HasColumnName("consigner");

                entity.Property(e => e.LeftTruck).HasColumnName("left_truck");

                entity.Property(e => e.Mat).HasColumnName("mat");

                entity.Property(e => e.Netto).HasColumnName("netto");

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.RightTruck).HasColumnName("right_truck");

                entity.Property(e => e.Shipper).HasColumnName("shipper");

                entity.Property(e => e.Tara).HasColumnName("tara");

                entity.Property(e => e.TaraE).HasColumnName("tara_e");

                entity.Property(e => e.WeighingTime)
                    .HasColumnName("weighing_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.ZoneE).HasColumnName("zone_e");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.TbCar)
                    .HasForeignKey(d => d.PartId)
                    .HasConstraintName("fk_tb_car");
            });

            modelBuilder.Entity<TbPart>(entity =>
            {
                entity.HasKey(e => e.PartId)
                    .HasName("pk_tb_part");

                entity.ToTable("tb_part");

                entity.Property(e => e.PartId)
                    .HasColumnName("part_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.NumIzm).HasColumnName("num_izm");

                entity.Property(e => e.NumMetering).HasColumnName("num_metering");

                entity.Property(e => e.Oper)
                    .IsRequired()
                    .HasColumnName("oper")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
