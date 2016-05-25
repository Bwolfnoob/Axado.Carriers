using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Axado.Carriers.Infraestructure.Context;

namespace Axado.Carriers.Infraestructure.Migrations
{
    [DbContext(typeof(AxadoPostgresContext))]
    partial class AxadoPostgresContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901");

            modelBuilder.Entity("Axado.Carriers.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("City");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("District");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Obs");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Axado.Carriers.Domain.Entities.Carrier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressId");

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("WebSite");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Carrier");
                });

            modelBuilder.Entity("Axado.Carriers.Domain.Entities.Rate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<int?>("CarrierId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<int>("Points");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CarrierId");

                    b.HasIndex("UserId");

                    b.ToTable("Rate");
                });

            modelBuilder.Entity("Axado.Carriers.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Axado.Carriers.Domain.Entities.Carrier", b =>
                {
                    b.HasOne("Axado.Carriers.Domain.Entities.Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("Axado.Carriers.Domain.Entities.Rate", b =>
                {
                    b.HasOne("Axado.Carriers.Domain.Entities.Carrier")
                        .WithMany()
                        .HasForeignKey("CarrierId");

                    b.HasOne("Axado.Carriers.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
