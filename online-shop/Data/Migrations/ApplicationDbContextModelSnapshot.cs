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

            modelBuilder.Entity("online_shop.Models.Product.Stationery.PenColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PenColor");
                });

            modelBuilder.Entity("online_shop.Models.Product.Stationery.PencilType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PencilType");
                });

            modelBuilder.Entity("online_shop.Models.Product.Vehicle.BicycleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("BicycleType");
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

            modelBuilder.Entity("online_shop.Models.Product.Stationery.NoteBook", b =>
                {
                    b.HasBaseType("online_shop.Models.Product.Product");

                    b.Property<string>("Country")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("longtext");

                    b.Property<int>("PaperCount")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("NoteBook");
                });

            modelBuilder.Entity("online_shop.Models.Product.Stationery.Pen", b =>
                {
                    b.HasBaseType("online_shop.Models.Product.Product");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("longtext");

                    b.HasIndex("ColorId");

                    b.HasDiscriminator().HasValue("Pen");
                });

            modelBuilder.Entity("online_shop.Models.Product.Stationery.Pencil", b =>
                {
                    b.HasBaseType("online_shop.Models.Product.Product");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("longtext");

                    b.Property<int>("PencilTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PencileTypeId")
                        .HasColumnType("int");

                    b.HasIndex("ColorId");

                    b.HasIndex("PencilTypeId");

                    b.ToTable("Products", t =>
                        {
                            t.Property("ColorId")
                                .HasColumnName("Pencil_ColorId");
                        });

                    b.HasDiscriminator().HasValue("Pencil");
                });

            modelBuilder.Entity("online_shop.Models.Product.Vehicle.Automobile", b =>
                {
                    b.HasBaseType("online_shop.Models.Product.Product");

                    b.Property<string>("Comapny")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAutomate")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("MotorCapacity")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Automobile");
                });

            modelBuilder.Entity("online_shop.Models.Product.Vehicle.Bicycle", b =>
                {
                    b.HasBaseType("online_shop.Models.Product.Product");

                    b.Property<int>("BicycleTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Comapny")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("longtext");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasIndex("BicycleTypeId");

                    b.HasDiscriminator().HasValue("Bicycle");
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

            modelBuilder.Entity("online_shop.Models.Product.Stationery.Pen", b =>
                {
                    b.HasOne("online_shop.Models.Product.Stationery.PenColor", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("online_shop.Models.Product.Stationery.Pencil", b =>
                {
                    b.HasOne("online_shop.Models.Product.Stationery.PenColor", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("online_shop.Models.Product.Stationery.PencilType", "PencilType")
                        .WithMany()
                        .HasForeignKey("PencilTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("PencilType");
                });

            modelBuilder.Entity("online_shop.Models.Product.Vehicle.Bicycle", b =>
                {
                    b.HasOne("online_shop.Models.Product.Vehicle.BicycleType", "BicycleType")
                        .WithMany()
                        .HasForeignKey("BicycleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BicycleType");
                });

            modelBuilder.Entity("online_shop.Models.Product.Product", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
