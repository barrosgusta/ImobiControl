﻿// <auto-generated />
using System;
using ImobiControl.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ImobiControl.Migrations
{
    [DbContext(typeof(ImobiControlContext))]
    [Migration("20240316001514_AddCidadeModel")]
    partial class AddCidadeModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ImobiControl.Models.Cidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("EstadoSigla")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoSigla");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("ImobiControl.Models.Estado", b =>
                {
                    b.Property<string>("Sigla")
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Sigla");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("ImobiControl.Models.Cidade", b =>
                {
                    b.HasOne("ImobiControl.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoSigla")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });
#pragma warning restore 612, 618
        }
    }
}
