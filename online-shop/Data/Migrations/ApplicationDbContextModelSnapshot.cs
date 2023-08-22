﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using online_shop.Data;

#nullable disable

namespace online_shop.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Online_Shop.Models.CommentStatus", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CommentStatus");
                });

            modelBuilder.Entity("online_shop.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsBuyerBoughtProduct")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<byte>("StatusId")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StatusId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("online_shop.Models.Product.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NumberInStock")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("online_shop.Models.Product.Digital.DataStoring.Ssd", b =>
                {
                    b.HasBaseType("online_shop.Models.Product.Product");

                    b.Property<int>("Capacity")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<double>("Height")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("double");

                    b.Property<double>("Length")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("double");

                    b.Property<int>("ReadSpeed")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("double");

                    b.Property<double>("Width")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("double");

                    b.Property<int>("WriteSpeed")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Ssd");
                });

            modelBuilder.Entity("online_shop.Models.Product.Digital.DataStoring.Usb", b =>
                {
                    b.HasBaseType("online_shop.Models.Product.Product");

                    b.Property<int>("Capacity")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<double>("Height")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("double");

                    b.Property<double>("Length")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("double");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Weight")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("double");

                    b.Property<double>("Width")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("double");

                    b.HasDiscriminator().HasValue("Usb");
                });

            modelBuilder.Entity("online_shop.Models.Product.Digital.Pc", b =>
                {
                    b.HasBaseType("online_shop.Models.Product.Product");

                    b.Property<string>("CpuModel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Height")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("double");

                    b.Property<double>("Length")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("double");

                    b.Property<int>("RamCapacity")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("double");

                    b.Property<double>("Width")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("double");

                    b.HasDiscriminator().HasValue("Pc");
                });

            modelBuilder.Entity("online_shop.Models.Comment", b =>
                {
                    b.HasOne("online_shop.Models.Product.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_Shop.Models.CommentStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("online_shop.Models.Product.Product", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}