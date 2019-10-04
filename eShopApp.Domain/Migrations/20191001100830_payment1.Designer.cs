﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eShopApp.Domain.Data;

namespace eShopApp.Domain.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20191001100830_payment1")]
    partial class payment1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eShopApp.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<int>("CusId");

                    b.Property<int>("Id");

                    b.Property<decimal>("Price");

                    b.Property<string>("name");

                    b.Property<int>("quantity");

                    b.HasKey("CartId");

                    b.HasIndex("CusId");

                    b.HasIndex("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("eShopApp.Models.Category", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CatNamr")
                        .IsRequired();

                    b.HasKey("CatId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("eShopApp.Models.Customer", b =>
                {
                    b.Property<int>("CusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("PhoneNumber");

                    b.Property<string>("role");

                    b.HasKey("CusId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("eShopApp.Models.OrderPlace", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<int>("CusId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FullName")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.HasKey("OrderId");

                    b.HasIndex("CusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("eShopApp.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CVV");

                    b.Property<string>("CardNumber");

                    b.Property<int>("CusId");

                    b.Property<string>("CustomerName");

                    b.Property<string>("ExpMonth");

                    b.Property<string>("ExpYear");

                    b.HasKey("PaymentId");

                    b.HasIndex("CusId");

                    b.ToTable("payments");
                });

            modelBuilder.Entity("eShopApp.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CatId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("DsicountPrice");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("ProImage")
                        .IsRequired();

                    b.Property<int>("Quantity");

                    b.Property<string>("discount")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CatId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("eShopApp.Models.Cart", b =>
                {
                    b.HasOne("eShopApp.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eShopApp.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eShopApp.Models.OrderPlace", b =>
                {
                    b.HasOne("eShopApp.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eShopApp.Models.Payment", b =>
                {
                    b.HasOne("eShopApp.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eShopApp.Models.Product", b =>
                {
                    b.HasOne("eShopApp.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
