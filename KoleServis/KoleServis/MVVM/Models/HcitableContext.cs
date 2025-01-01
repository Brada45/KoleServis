using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace KoleServis.MVVM.Models;

public partial class HcitableContext : DbContext
{
    public HcitableContext()
    {
    }

    public HcitableContext(DbContextOptions<HcitableContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dio> Dios { get; set; }

    public virtual DbSet<Jezik> Jeziks { get; set; }

    public virtual DbSet<Kategorija> Kategorijas { get; set; }

    public virtual DbSet<Kupac> Kupacs { get; set; }

    public virtual DbSet<Osoba> Osobas { get; set; }

    public virtual DbSet<Racun> Racuns { get; set; }

    public virtual DbSet<Radnja> Radnjas { get; set; }

    public virtual DbSet<StavkaDio> StavkaDios { get; set; }

    public virtual DbSet<StavkaUsluga> StavkaUslugas { get; set; }

    public virtual DbSet<Tema> Temas { get; set; }

    public virtual DbSet<Tip> Tips { get; set; }

    public virtual DbSet<Usluga> Uslugas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("Resources/appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 37)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Dio>(entity =>
        {
            entity.HasKey(e => e.IdDio).HasName("PRIMARY");

            entity.ToTable("dio");

            entity.HasIndex(e => e.KategorijaIdKategorija, "fk_Dio_Kategorija1_idx");

            entity.HasIndex(e => e.RadnjaIdRadnja, "fk_Dio_Radnja1_idx");

            entity.Property(e => e.IdDio)
                .HasColumnType("int(11)")
                .HasColumnName("id_dio");
            entity.Property(e => e.Cijena)
                .HasPrecision(5, 2)
                .HasColumnName("cijena");
            entity.Property(e => e.KategorijaIdKategorija)
                .HasColumnType("int(11)")
                .HasColumnName("Kategorija_id_kategorija");
            entity.Property(e => e.Kolicina)
                .HasColumnType("int(11)")
                .HasColumnName("kolicina");
            entity.Property(e => e.Naziv).HasMaxLength(45);
            entity.Property(e => e.Obrisano)
                .HasColumnType("tinyint(4)")
                .HasColumnName("obrisano");
            entity.Property(e => e.RadnjaIdRadnja)
                .HasMaxLength(17)
                .HasColumnName("Radnja_id_radnja");
            entity.Property(e => e.Slika)
                .HasColumnType("mediumblob")
                .HasColumnName("slika");

            entity.HasOne(d => d.KategorijaIdKategorijaNavigation).WithMany(p => p.Dios)
                .HasForeignKey(d => d.KategorijaIdKategorija)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Dio_Kategorija1");

            entity.HasOne(d => d.RadnjaIdRadnjaNavigation).WithMany(p => p.Dios)
                .HasForeignKey(d => d.RadnjaIdRadnja)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Dio_Radnja1");
        });

        modelBuilder.Entity<Jezik>(entity =>
        {
            entity.HasKey(e => e.IdJezik).HasName("PRIMARY");

            entity.ToTable("jezik");

            entity.Property(e => e.IdJezik)
                .HasColumnType("int(11)")
                .HasColumnName("id_jezik");
            entity.Property(e => e.Naziv)
                .HasMaxLength(45)
                .HasColumnName("naziv");
        });

        modelBuilder.Entity<Kategorija>(entity =>
        {
            entity.HasKey(e => e.IdKategorija).HasName("PRIMARY");

            entity.ToTable("kategorija");

            entity.Property(e => e.IdKategorija)
                .HasColumnType("int(11)")
                .HasColumnName("id_kategorija");
            entity.Property(e => e.Naziv)
                .HasMaxLength(45)
                .HasColumnName("naziv");
        });

        modelBuilder.Entity<Kupac>(entity =>
        {
            entity.HasKey(e => e.IdKupac).HasName("PRIMARY");

            entity.ToTable("kupac");

            entity.Property(e => e.IdKupac)
                .HasColumnType("int(11)")
                .HasColumnName("id_kupac");
            entity.Property(e => e.Naziv)
                .HasMaxLength(45)
                .HasColumnName("naziv");
            entity.Property(e => e.Rabat)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("rabat");
        });

        modelBuilder.Entity<Osoba>(entity =>
        {
            entity.HasKey(e => e.KorisnickoIme).HasName("PRIMARY");

            entity.ToTable("osoba");

            entity.HasIndex(e => e.JezikIdJezik, "fk_Osoba_Jezik1_idx");

            entity.HasIndex(e => e.TemaIdTema, "fk_Osoba_Tema1_idx");

            entity.HasIndex(e => e.TipIdTip, "fk_Osoba_Tip1_idx");

            entity.Property(e => e.KorisnickoIme)
                .HasMaxLength(50)
                .HasColumnName("Korisnicko ime");
            entity.Property(e => e.Ime).HasMaxLength(45);
            entity.Property(e => e.JezikIdJezik)
                .HasColumnType("int(11)")
                .HasColumnName("Jezik_id_jezik");
            entity.Property(e => e.Obrisan).HasColumnType("tinyint(4)");
            entity.Property(e => e.Prezime).HasMaxLength(45);
            entity.Property(e => e.Sifra)
                .HasMaxLength(45)
                .HasColumnName("sifra");
            entity.Property(e => e.TemaIdTema)
                .HasColumnType("int(11)")
                .HasColumnName("Tema_id_tema");
            entity.Property(e => e.TipIdTip)
                .HasColumnType("int(11)")
                .HasColumnName("Tip_id_tip");

            entity.HasOne(d => d.JezikIdJezikNavigation).WithMany(p => p.Osobas)
                .HasForeignKey(d => d.JezikIdJezik)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Osoba_Jezik1");

            entity.HasOne(d => d.TemaIdTemaNavigation).WithMany(p => p.Osobas)
                .HasForeignKey(d => d.TemaIdTema)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Osoba_Tema1");

            entity.HasOne(d => d.TipIdTipNavigation).WithMany(p => p.Osobas)
                .HasForeignKey(d => d.TipIdTip)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Osoba_Tip1");
        });

        modelBuilder.Entity<Racun>(entity =>
        {
            entity.HasKey(e => e.IdRacun).HasName("PRIMARY");

            entity.ToTable("racun");

            entity.HasIndex(e => e.KupacIdKupac, "fk_Racun_Kupac1_idx");

            entity.HasIndex(e => e.RadnikOsobaKorisnickoIme, "fk_Racun_Radnik1_idx");

            entity.HasIndex(e => e.RadnjaIdRadnja, "fk_Racun_Radnja1_idx");

            entity.Property(e => e.IdRacun)
                .HasColumnType("int(11)")
                .HasColumnName("id_racun");
            entity.Property(e => e.Cijena)
                .HasPrecision(5, 2)
                .HasColumnName("cijena");
            entity.Property(e => e.Datum)
                .HasColumnType("datetime")
                .HasColumnName("datum");
            entity.Property(e => e.KupacIdKupac)
                .HasColumnType("int(11)")
                .HasColumnName("Kupac_id_kupac");
            entity.Property(e => e.RadnikOsobaKorisnickoIme)
                .HasMaxLength(50)
                .HasColumnName("Radnik_Osoba_Korisnicko ime");
            entity.Property(e => e.RadnjaIdRadnja)
                .HasMaxLength(17)
                .HasColumnName("Radnja_id_radnja");

            entity.HasOne(d => d.KupacIdKupacNavigation).WithMany(p => p.Racuns)
                .HasForeignKey(d => d.KupacIdKupac)
                .HasConstraintName("fk_Racun_Kupac1");

            entity.HasOne(d => d.RadnjaIdRadnjaNavigation).WithMany(p => p.Racuns)
                .HasForeignKey(d => d.RadnjaIdRadnja)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Racun_Radnja1");
        });

        modelBuilder.Entity<Radnja>(entity =>
        {
            entity.HasKey(e => e.IdRadnja).HasName("PRIMARY");

            entity.ToTable("radnja");

            entity.Property(e => e.IdRadnja)
                .HasMaxLength(17)
                .HasColumnName("id_radnja");
            entity.Property(e => e.Naziv).HasMaxLength(45);

            entity.HasMany(d => d.OsobaKorisnickoImes).WithMany(p => p.RadnjaIdRadnjas)
                .UsingEntity<Dictionary<string, object>>(
                    "Menadzer",
                    r => r.HasOne<Osoba>().WithMany()
                        .HasForeignKey("OsobaKorisnickoIme")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Menadzer_Osoba1"),
                    l => l.HasOne<Radnja>().WithMany()
                        .HasForeignKey("RadnjaIdRadnja")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Osoba_has_Radnja_Radnja2"),
                    j =>
                    {
                        j.HasKey("RadnjaIdRadnja", "OsobaKorisnickoIme")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("menadzer");
                        j.HasIndex(new[] { "OsobaKorisnickoIme" }, "fk_Menadzer_Osoba1_idx");
                        j.HasIndex(new[] { "RadnjaIdRadnja" }, "fk_Osoba_has_Radnja_Radnja2_idx");
                        j.IndexerProperty<string>("RadnjaIdRadnja")
                            .HasMaxLength(17)
                            .HasColumnName("Radnja_id_radnja");
                        j.IndexerProperty<string>("OsobaKorisnickoIme")
                            .HasMaxLength(50)
                            .HasColumnName("Osoba_Korisnicko ime");
                    });

            entity.HasMany(d => d.OsobaKorisnickoImesNavigation).WithMany(p => p.RadnjaJibs)
                .UsingEntity<Dictionary<string, object>>(
                    "Radnik",
                    r => r.HasOne<Osoba>().WithMany()
                        .HasForeignKey("OsobaKorisnickoIme")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Radnik_Osoba1"),
                    l => l.HasOne<Radnja>().WithMany()
                        .HasForeignKey("RadnjaJib")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Osoba_has_Radnja_Radnja1"),
                    j =>
                    {
                        j.HasKey("RadnjaJib", "OsobaKorisnickoIme")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("radnik");
                        j.HasIndex(new[] { "RadnjaJib" }, "fk_Osoba_has_Radnja_Radnja1_idx");
                        j.HasIndex(new[] { "OsobaKorisnickoIme" }, "fk_Radnik_Osoba1_idx");
                        j.IndexerProperty<string>("RadnjaJib")
                            .HasMaxLength(17)
                            .HasColumnName("Radnja_JIB");
                        j.IndexerProperty<string>("OsobaKorisnickoIme")
                            .HasMaxLength(50)
                            .HasColumnName("Osoba_Korisnicko ime");
                    });
        });

        modelBuilder.Entity<StavkaDio>(entity =>
        {
            entity.HasKey(e => new { e.DioIdDio, e.RacunIdRacun })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("stavka_dio");

            entity.HasIndex(e => e.DioIdDio, "fk_Stavka_Dio_Dio1_idx");

            entity.HasIndex(e => e.RacunIdRacun, "fk_Stavka_Dio_Racun1_idx");

            entity.Property(e => e.DioIdDio)
                .HasColumnType("int(11)")
                .HasColumnName("Dio_id_dio");
            entity.Property(e => e.RacunIdRacun)
                .HasColumnType("int(11)")
                .HasColumnName("Racun_id_racun");
            entity.Property(e => e.CijenaKomad)
                .HasPrecision(5, 2)
                .HasColumnName("cijena komad");
            entity.Property(e => e.CijenaUkupno)
                .HasPrecision(5, 2)
                .HasColumnName("cijena ukupno");
            entity.Property(e => e.Kolicina)
                .HasColumnType("int(11)")
                .HasColumnName("kolicina");

            entity.HasOne(d => d.DioIdDioNavigation).WithMany(p => p.StavkaDios)
                .HasForeignKey(d => d.DioIdDio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Stavka_Dio_Dio1");

            entity.HasOne(d => d.RacunIdRacunNavigation).WithMany(p => p.StavkaDios)
                .HasForeignKey(d => d.RacunIdRacun)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Stavka_Dio_Racun1");
        });

        modelBuilder.Entity<StavkaUsluga>(entity =>
        {
            entity.HasKey(e => new { e.UslugaIdUsluga, e.RadnikOsobaKorisnickoIme, e.RacunIdRacun })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("stavka_usluga");

            entity.HasIndex(e => e.UslugaIdUsluga, "fk_Racun_has_Usluga_Usluga1_idx");

            entity.HasIndex(e => e.RacunIdRacun, "fk_Stavka_Usluga_Racun1_idx");

            entity.HasIndex(e => e.RadnikOsobaKorisnickoIme, "fk_Stavka_Usluga_Radnik1_idx");

            entity.Property(e => e.UslugaIdUsluga)
                .HasColumnType("int(11)")
                .HasColumnName("Usluga_id_usluga");
            entity.Property(e => e.RadnikOsobaKorisnickoIme)
                .HasMaxLength(50)
                .HasColumnName("Radnik_Osoba_Korisnicko ime");
            entity.Property(e => e.RacunIdRacun)
                .HasColumnType("int(11)")
                .HasColumnName("Racun_id_racun");
            entity.Property(e => e.CijenaKomad)
                .HasPrecision(5, 2)
                .HasColumnName("cijena komad");
            entity.Property(e => e.CijenaUkupno)
                .HasPrecision(5, 2)
                .HasColumnName("cijena ukupno");
            entity.Property(e => e.Kolicina)
                .HasColumnType("int(11)")
                .HasColumnName("kolicina");

            entity.HasOne(d => d.RacunIdRacunNavigation).WithMany(p => p.StavkaUslugas)
                .HasForeignKey(d => d.RacunIdRacun)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Stavka_Usluga_Racun1");

            entity.HasOne(d => d.UslugaIdUslugaNavigation).WithMany(p => p.StavkaUslugas)
                .HasForeignKey(d => d.UslugaIdUsluga)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Racun_has_Usluga_Usluga1");
        });

        modelBuilder.Entity<Tema>(entity =>
        {
            entity.HasKey(e => e.IdTema).HasName("PRIMARY");

            entity.ToTable("tema");

            entity.Property(e => e.IdTema)
                .HasColumnType("int(11)")
                .HasColumnName("id_tema");
            entity.Property(e => e.Boja)
                .HasMaxLength(45)
                .HasColumnName("boja");
            entity.Property(e => e.Bold)
                .HasColumnType("tinyint(4)")
                .HasColumnName("bold");
            entity.Property(e => e.Font)
                .HasMaxLength(45)
                .HasColumnName("font");
            entity.Property(e => e.Italic)
                .HasColumnType("tinyint(4)")
                .HasColumnName("italic");
            entity.Property(e => e.Velicina)
                .HasColumnType("int(11)")
                .HasColumnName("velicina");
        });

        modelBuilder.Entity<Tip>(entity =>
        {
            entity.HasKey(e => e.IdTip).HasName("PRIMARY");

            entity.ToTable("tip");

            entity.Property(e => e.IdTip)
                .HasColumnType("int(11)")
                .HasColumnName("id_tip");
            entity.Property(e => e.Naziv)
                .HasMaxLength(45)
                .HasColumnName("naziv");
        });

        modelBuilder.Entity<Usluga>(entity =>
        {
            entity.HasKey(e => e.IdUsluga).HasName("PRIMARY");

            entity.ToTable("usluga");

            entity.HasIndex(e => e.MenadzerOsobaKorisnickoIme, "fk_Usluga_Menadzer1_idx");

            entity.HasIndex(e => e.RadnjaIdRadnja, "fk_Usluga_Radnja1_idx");

            entity.Property(e => e.IdUsluga)
                .HasColumnType("int(11)")
                .HasColumnName("id_usluga");
            entity.Property(e => e.Cijena)
                .HasPrecision(5, 2)
                .HasColumnName("cijena");
            entity.Property(e => e.MenadzerOsobaKorisnickoIme)
                .HasMaxLength(50)
                .HasColumnName("Menadzer_Osoba_Korisnicko ime");
            entity.Property(e => e.Naziv).HasMaxLength(45);
            entity.Property(e => e.Obrisano)
                .HasColumnType("tinyint(4)")
                .HasColumnName("obrisano");
            entity.Property(e => e.RadnjaIdRadnja)
                .HasMaxLength(17)
                .HasColumnName("Radnja_id_radnja");

            entity.HasOne(d => d.RadnjaIdRadnjaNavigation).WithMany(p => p.Uslugas)
                .HasForeignKey(d => d.RadnjaIdRadnja)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Usluga_Radnja1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
