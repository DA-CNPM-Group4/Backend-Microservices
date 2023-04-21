﻿// <auto-generated />
using System;
using AuthenticationService.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AuthenticationService.Migrations
{
    [DbContext(typeof(AuthenticationDbContext))]
    partial class AuthenticationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AuthenticationService.Models.AuthenticationInfo", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsThirdPartyAccount")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsValidated")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RefreshTokenExpiredDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ResetPasswordString")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ValidateEmailString")
                        .HasColumnType("text");

                    b.HasKey("AccountId");

                    b.ToTable("AuthenticationInfo", "public");
                });

            modelBuilder.Entity("Helper.Models.EmailSender", b =>
                {
                    b.Property<string>("usr")
                        .HasColumnType("text");

                    b.Property<int>("EmailSended")
                        .HasColumnType("integer");

                    b.Property<string>("pwd")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("usr");

                    b.ToTable("EmailSender", "dbo");
                });
#pragma warning restore 612, 618
        }
    }
}
