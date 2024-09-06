﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransferMarket.Data;

#nullable disable

namespace TransferMarket.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("TransferMarket.Models.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contraseña")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("contraseña");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Nombre")
                        .HasMaxLength(90)
                        .HasColumnType("varchar(90)")
                        .HasColumnName("nombre");

                    b.Property<string>("Usuario")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("usuario");

                    b.HasKey("Id");

                    b.ToTable("administradores");
                });

            modelBuilder.Entity("TransferMarket.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ciudad");

                    b.Property<string>("Estadio")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("estadio");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("clubes");
                });

            modelBuilder.Entity("TransferMarket.Models.Jugador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClubId")
                        .HasColumnType("int");

                    b.Property<string>("Nacionalidad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nacionalidad");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre_completo");

                    b.Property<string>("Posicion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("posicion");

                    b.Property<double>("Valor")
                        .HasColumnType("double")
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("jugadores");
                });

            modelBuilder.Entity("TransferMarket.Models.Jugador", b =>
                {
                    b.HasOne("TransferMarket.Models.Club", null)
                        .WithMany("Jugadores")
                        .HasForeignKey("ClubId");
                });

            modelBuilder.Entity("TransferMarket.Models.Club", b =>
                {
                    b.Navigation("Jugadores");
                });
#pragma warning restore 612, 618
        }
    }
}
