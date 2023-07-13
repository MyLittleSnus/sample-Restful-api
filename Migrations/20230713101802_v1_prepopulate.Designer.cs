﻿// <auto-generated />
using GoodsApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoodsApi.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20230713101802_v1_prepopulate")]
    partial class v1_prepopulate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GoodOrder", b =>
                {
                    b.Property<string>("GoodsId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("OrdersId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("GoodsId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("GoodOrder");
                });

            modelBuilder.Entity("GoodsApi.Models.BaseEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("GoodsApi.Models.Good", b =>
                {
                    b.HasBaseType("GoodsApi.Models.BaseEntity");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<double>("Cost")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.ToTable("goods");

                    b.HasData(
                        new
                        {
                            Id = "46c1ef37-7fc8-4aa0-8d45-a587818021b4",
                            Category = 0,
                            Cost = 20000.0,
                            Name = "TV LG 520"
                        },
                        new
                        {
                            Id = "17493c23-5f61-4fef-8157-1fb98e3d3b42",
                            Category = 0,
                            Cost = 18000.0,
                            Name = "IPhone 11"
                        },
                        new
                        {
                            Id = "662a46d3-dd54-4eee-a85e-4f203d7a6375",
                            Category = 0,
                            Cost = 30000.0,
                            Name = "MacBook Air M1"
                        },
                        new
                        {
                            Id = "ff0de1a4-0ebc-43c4-860d-d4e3cf0f91d6",
                            Category = 0,
                            Cost = 45000.0,
                            Name = "MacBook Air M2"
                        },
                        new
                        {
                            Id = "4c72a1a0-7628-4de0-af15-15359a5dcddd",
                            Category = 0,
                            Cost = 25000.0,
                            Name = "Samsumg S20 Ultra"
                        });
                });

            modelBuilder.Entity("GoodsApi.Models.Order", b =>
                {
                    b.HasBaseType("GoodsApi.Models.BaseEntity");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("GoodOrder", b =>
                {
                    b.HasOne("GoodsApi.Models.Good", null)
                        .WithMany()
                        .HasForeignKey("GoodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoodsApi.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
