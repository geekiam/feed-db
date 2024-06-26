﻿// <auto-generated />
using System;
using Geekiam.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Geekiam.Persistence.Migrations
{
    [DbContext(typeof(FeedsContext))]
    partial class FeedsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("feeds")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Geekiam.Persistence.Models.OpenGraph", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TimestampTz")
                        .HasColumnName("created");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar")
                        .HasColumnName("description");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("TimestampTz")
                        .HasColumnName("modified");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid")
                        .HasColumnName("post_id");

                    b.Property<string>("SiteName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar")
                        .HasColumnName("site_name");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar")
                        .HasColumnName("title");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("varchar")
                        .HasColumnName("type");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.HasIndex("PostId")
                        .IsUnique();

                    b.ToTable("open_graph", "feeds");
                });

            modelBuilder.Entity("Geekiam.Persistence.Models.Twitter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TimestampTz")
                        .HasColumnName("created");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("varchar")
                        .HasColumnName("creator");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar")
                        .HasColumnName("description");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("TimestampTz")
                        .HasColumnName("modified");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid")
                        .HasColumnName("post_id");

                    b.Property<string>("Site")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar")
                        .HasColumnName("site");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("PostId")
                        .IsUnique();

                    b.ToTable("twitter", "feeds");
                });

            modelBuilder.Entity("Models.Categories", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TimestampTz")
                        .HasColumnName("created");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("TimestampTz")
                        .HasColumnName("modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("categories", "feeds");
                });

            modelBuilder.Entity("Models.Feeds", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TimestampTz")
                        .HasColumnName("created");

                    b.Property<int>("MediaTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("media_type_id");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("TimestampTz")
                        .HasColumnName("modified");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("path");

                    b.Property<Guid>("SourcesId")
                        .HasColumnType("uuid")
                        .HasColumnName("sources_id");

                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1)
                        .HasColumnName("status_id");

                    b.HasKey("Id");

                    b.HasIndex("MediaTypeId");

                    b.HasIndex("SourcesId");

                    b.HasIndex("StatusId");

                    b.ToTable("feeds", "feeds");
                });

            modelBuilder.Entity("Models.MediaTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("media_types", "feeds");
                });

            modelBuilder.Entity("Models.Posts", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TimestampTz")
                        .HasColumnName("created");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar")
                        .HasColumnName("description");

                    b.Property<Guid>("FeedId")
                        .HasColumnType("uuid")
                        .HasColumnName("feed_id");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("TimestampTz")
                        .HasColumnName("modified");

                    b.Property<string>("Permalink")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("permalink");

                    b.Property<DateTime>("Published")
                        .HasColumnType("TimestampTz")
                        .HasColumnName("published");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("summary");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("FeedId");

                    b.HasIndex("Permalink")
                        .IsUnique();

                    b.ToTable("posts", "feeds");
                });

            modelBuilder.Entity("Models.ScheduleTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("schedule_types", "feeds");
                });

            modelBuilder.Entity("Models.Schedules", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TimestampTz")
                        .HasColumnName("created");

                    b.Property<Guid>("FeedId")
                        .HasColumnType("uuid")
                        .HasColumnName("feed_id");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("TimestampTz")
                        .HasColumnName("modified");

                    b.Property<int>("ScheduleTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("schedule_type_id");

                    b.HasKey("Id");

                    b.HasIndex("FeedId");

                    b.HasIndex("ScheduleTypeId", "FeedId")
                        .IsUnique();

                    b.ToTable("schedules", "feeds");
                });

            modelBuilder.Entity("Models.SourceCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TimestampTz")
                        .HasColumnName("created");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("TimestampTz")
                        .HasColumnName("modified");

                    b.Property<Guid>("SourceId")
                        .HasColumnType("uuid")
                        .HasColumnName("source_id");

                    b.HasKey("Id");

                    b.HasIndex("SourceId");

                    b.HasIndex("CategoryId", "SourceId")
                        .IsUnique();

                    b.ToTable("source_category", "feeds");
                });

            modelBuilder.Entity("Models.Sources", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TimestampTz")
                        .HasColumnName("created");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar")
                        .HasColumnName("description");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("domain");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("varchar")
                        .HasColumnName("identifier");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("TimestampTz")
                        .HasColumnName("modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.Property<string>("Protocol")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("varchar")
                        .HasColumnName("protocol");

                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1)
                        .HasColumnName("status_id");

                    b.HasKey("Id");

                    b.HasIndex("Domain")
                        .IsUnique();

                    b.HasIndex("Identifier")
                        .IsUnique();

                    b.HasIndex("StatusId");

                    b.ToTable("sources", "feeds");
                });

            modelBuilder.Entity("Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("status", "feeds");
                });

            modelBuilder.Entity("Geekiam.Persistence.Models.OpenGraph", b =>
                {
                    b.HasOne("Models.Posts", "Post")
                        .WithOne("OpenGraph")
                        .HasForeignKey("Geekiam.Persistence.Models.OpenGraph", "PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Geekiam.Persistence.Models.Twitter", b =>
                {
                    b.HasOne("Models.Posts", "Post")
                        .WithOne("Twitter")
                        .HasForeignKey("Geekiam.Persistence.Models.Twitter", "PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Models.Feeds", b =>
                {
                    b.HasOne("Models.MediaTypes", "MediaType")
                        .WithMany("Feeds")
                        .HasForeignKey("MediaTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Sources", "Source")
                        .WithMany("Feeds")
                        .HasForeignKey("SourcesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Status", "Status")
                        .WithMany("Feeds")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MediaType");

                    b.Navigation("Source");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Models.Posts", b =>
                {
                    b.HasOne("Models.Feeds", "Feed")
                        .WithMany("Posts")
                        .HasForeignKey("FeedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feed");
                });

            modelBuilder.Entity("Models.Schedules", b =>
                {
                    b.HasOne("Models.Feeds", "Feed")
                        .WithMany("Schedules")
                        .HasForeignKey("FeedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.ScheduleTypes", "ScheduleType")
                        .WithMany("Schedules")
                        .HasForeignKey("ScheduleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feed");

                    b.Navigation("ScheduleType");
                });

            modelBuilder.Entity("Models.SourceCategory", b =>
                {
                    b.HasOne("Models.Categories", "Category")
                        .WithMany("Sources")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Sources", "Source")
                        .WithMany("Categories")
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("Models.Sources", b =>
                {
                    b.HasOne("Models.Status", "Status")
                        .WithMany("Sources")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Models.Categories", b =>
                {
                    b.Navigation("Sources");
                });

            modelBuilder.Entity("Models.Feeds", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Models.MediaTypes", b =>
                {
                    b.Navigation("Feeds");
                });

            modelBuilder.Entity("Models.Posts", b =>
                {
                    b.Navigation("OpenGraph")
                        .IsRequired();

                    b.Navigation("Twitter")
                        .IsRequired();
                });

            modelBuilder.Entity("Models.ScheduleTypes", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Models.Sources", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Feeds");
                });

            modelBuilder.Entity("Models.Status", b =>
                {
                    b.Navigation("Feeds");

                    b.Navigation("Sources");
                });
#pragma warning restore 612, 618
        }
    }
}
