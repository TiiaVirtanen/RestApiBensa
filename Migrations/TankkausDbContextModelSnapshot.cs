﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestApiBensas.Models;

#nullable disable

namespace RestApiBensas.Migrations
{
    [DbContext(typeof(TankkausDbContext))]
    partial class TankkausDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestApiBensas.Models.Ajoneuvot", b =>
                {
                    b.Property<int>("AjoneuvoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AjoneuvoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AjoneuvoId"));

                    b.Property<byte[]>("Kuva")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("KäyttäjäId")
                        .HasColumnType("int")
                        .HasColumnName("KäyttäjäId");

                    b.Property<string>("Malli")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Merkki")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Rekisterinumero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("AjoneuvoId")
                        .HasName("PK__Ajoneuvo__E0953F7BCFD8F88B");

                    b.HasIndex("KäyttäjäId");

                    b.HasIndex(new[] { "Rekisterinumero" }, "UQ__Ajoneuvo__7446AE9EE1C4089D")
                        .IsUnique();

                    b.ToTable("Ajoneuvot", (string)null);
                });

            modelBuilder.Entity("RestApiBensas.Models.Käyttäjät", b =>
                {
                    b.Property<int>("KäyttäjäId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KäyttäjäId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KäyttäjäId"));

                    b.Property<string>("Etunimi")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Salasana")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Sukunimi")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Sähköposti")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("KäyttäjäId")
                        .HasName("PK__Käyttäjä__914A7D755076997C");

                    b.HasIndex(new[] { "Sähköposti" }, "UQ__Käyttäjä__2231DE4D40B86914")
                        .IsUnique();

                    b.ToTable("Käyttäjät", (string)null);
                });

            modelBuilder.Entity("RestApiBensas.Models.Tankkaus", b =>
                {
                    b.Property<int>("TankkausId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TankkausId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TankkausId"));

                    b.Property<int?>("Ajokilometrit")
                        .HasColumnType("int");

                    b.Property<int>("AjoneuvoId")
                        .HasColumnType("int")
                        .HasColumnName("AjoneuvoId");

                    b.Property<decimal?>("Euroa")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("Litraa")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<DateOnly?>("Päivämäärä")
                        .HasColumnType("date");

                    b.HasKey("TankkausId")
                        .HasName("PK__Tankkaus__4354D1A48414621C");

                    b.HasIndex("AjoneuvoId");

                    b.ToTable("Tankkaus");
                });

            modelBuilder.Entity("RestApiBensas.Models.Ajoneuvot", b =>
                {
                    b.HasOne("RestApiBensas.Models.Käyttäjät", "Käyttäjä")
                        .WithMany("Ajoneuvots")
                        .HasForeignKey("KäyttäjäId")
                        .HasConstraintName("FK__Ajoneuvot__Käytt__60A75C0F");

                    b.Navigation("Käyttäjä");
                });

            modelBuilder.Entity("RestApiBensas.Models.Tankkaus", b =>
                {
                    b.HasOne("RestApiBensas.Models.Ajoneuvot", "Ajoneuvo")
                        .WithMany("Tankkaus")
                        .HasForeignKey("AjoneuvoId")
                        .IsRequired()
                        .HasConstraintName("FK__Tankkaus__Ajoneu__6383C8BA");

                    b.Navigation("Ajoneuvo");
                });

            modelBuilder.Entity("RestApiBensas.Models.Ajoneuvot", b =>
                {
                    b.Navigation("Tankkaus");
                });

            modelBuilder.Entity("RestApiBensas.Models.Käyttäjät", b =>
                {
                    b.Navigation("Ajoneuvots");
                });
#pragma warning restore 612, 618
        }
    }
}
