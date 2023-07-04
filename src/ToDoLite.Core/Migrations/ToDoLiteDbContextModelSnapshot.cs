﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoLite.Core.Persistence;

#nullable disable

namespace ToDoLite.Core.Migrations
{
    [DbContext(typeof(ToDoLiteDbContext))]
    partial class ToDoLiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("TagToDoItem", b =>
                {
                    b.Property<Guid>("TagsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ToDoItemsId")
                        .HasColumnType("TEXT");

                    b.HasKey("TagsId", "ToDoItemsId");

                    b.HasIndex("ToDoItemsId");

                    b.ToTable("TagToDoItem");
                });

            modelBuilder.Entity("ToDoLite.Core.DataModel.ImageData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Bytes")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<Guid>("ToDoItemId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ToDoItemId");

                    b.ToTable("ImageData");
                });

            modelBuilder.Entity("ToDoLite.Core.DataModel.Setting", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("ValueBoolean")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ValueDateTime")
                        .HasColumnType("TEXT");

                    b.Property<double?>("ValueDouble")
                        .HasColumnType("REAL");

                    b.Property<int?>("ValueInteger")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ValueString")
                        .HasColumnType("TEXT");

                    b.HasKey("Key");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("ToDoLite.Core.DataModel.Tags", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ToDoLite.Core.DataModel.ToDoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ActiveWindowTitle")
                        .HasColumnType("TEXT");

                    b.Property<int>("CapturedDataType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CompletedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlainText")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RawData")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.ToTable("ToDoItems");
                });

            modelBuilder.Entity("TagToDoItem", b =>
                {
                    b.HasOne("ToDoLite.Core.DataModel.Tags", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoLite.Core.DataModel.ToDoItem", null)
                        .WithMany()
                        .HasForeignKey("ToDoItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToDoLite.Core.DataModel.ImageData", b =>
                {
                    b.HasOne("ToDoLite.Core.DataModel.ToDoItem", "ToDoItem")
                        .WithMany("Images")
                        .HasForeignKey("ToDoItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ToDoItem");
                });

            modelBuilder.Entity("ToDoLite.Core.DataModel.ToDoItem", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
