﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PrimaryDbPostgreSql;

#nullable disable

namespace PrimaryDbPostgreSql.Migrations
{
    [DbContext(typeof(PrimaryDbPostgreSqlContext))]
    partial class PrimaryDbPostgreSqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Application.Domain.Entities.Folder", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<Guid?>("RootFolderId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SpaceId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("RootFolderId");

                    b.HasIndex("SpaceId");

                    b.HasIndex("Name", "RootFolderId")
                        .IsUnique();

                    b.HasIndex("Name", "SpaceId")
                        .IsUnique();

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("Application.Domain.Entities.Space", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<string>("OwnerUserId")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<short>("Type")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Spaces");
                });

            modelBuilder.Entity("Application.Domain.Entities.Folder", b =>
                {
                    b.HasOne("Application.Domain.Entities.Folder", "RootFolder")
                        .WithMany("SubFolderList")
                        .HasForeignKey("RootFolderId");

                    b.HasOne("Application.Domain.Entities.Space", "Space")
                        .WithMany("FolderList")
                        .HasForeignKey("SpaceId");

                    b.Navigation("RootFolder");

                    b.Navigation("Space");
                });

            modelBuilder.Entity("Application.Domain.Entities.Folder", b =>
                {
                    b.Navigation("SubFolderList");
                });

            modelBuilder.Entity("Application.Domain.Entities.Space", b =>
                {
                    b.Navigation("FolderList");
                });
#pragma warning restore 612, 618
        }
    }
}