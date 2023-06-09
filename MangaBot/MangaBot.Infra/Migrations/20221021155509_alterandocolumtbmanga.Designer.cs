﻿// <auto-generated />
using MangaBot.Infra.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MangaBot.Infra.Migrations
{
    [DbContext(typeof(MangaBotContext))]
    [Migration("20221021155509_alterandocolumtbmanga")]
    partial class alterandocolumtbmanga
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MangaBot.Domain.Model.Manga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TotaldeCapitulos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbManga");
                });

            modelBuilder.Entity("MangaBot.Domain.Model.MangaUsuario", b =>
                {
                    b.Property<int>("MangaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasIndex("MangaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tbMangaUsuario", (string)null);
                });

            modelBuilder.Entity("MangaBot.Domain.Model.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nomecompleto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("numero_phone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbUsuario");
                });

            modelBuilder.Entity("MangaBot.Domain.Model.MangaUsuario", b =>
                {
                    b.HasOne("MangaBot.Domain.Model.Manga", "Manga")
                        .WithMany()
                        .HasForeignKey("MangaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MangaBot.Domain.Model.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manga");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
