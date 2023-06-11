﻿// <auto-generated />
using CodeBytes.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CodeBytes.DAL.Migrations
{
    [DbContext(typeof(CodeByteContext))]
    partial class CodeByteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CodeBytes.DAL.Problems.ProblemEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Difficulty")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("CodeBytes.DAL.Problems.ProblemTagEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Tag")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProblemTags");
                });

            modelBuilder.Entity("ProblemEntityProblemTagEntity", b =>
                {
                    b.Property<int>("ProblemID")
                        .HasColumnType("integer");

                    b.Property<int>("TagsId")
                        .HasColumnType("integer");

                    b.HasKey("ProblemID", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("ProblemEntityProblemTagEntity");
                });

            modelBuilder.Entity("ProblemEntityProblemTagEntity", b =>
                {
                    b.HasOne("CodeBytes.DAL.Problems.ProblemEntity", null)
                        .WithMany()
                        .HasForeignKey("ProblemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeBytes.DAL.Problems.ProblemTagEntity", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
