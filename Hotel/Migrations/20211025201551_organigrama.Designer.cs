// <auto-generated />
using System;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hotel.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20211025201551_organigrama")]
    partial class organigrama
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hotel.Models.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AniosAntiguedad")
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AsistenciaEnum")
                        .HasColumnType("int");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Sueldo")
                        .HasColumnType("float");

                    b.Property<int>("TurnoEnum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Hotel.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Hotel.Models.Habitacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<bool>("Mantenimiento")
                        .HasColumnType("bit");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Habitaciones");
                });

            modelBuilder.Entity("Hotel.Models.Organigrama", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("EmpleadosId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadosId");

                    b.ToTable("Organigrama");
                });

            modelBuilder.Entity("Hotel.Models.Telefono", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Telefonos");
                });

            modelBuilder.Entity("Hotel.Models.Empleado", b =>
                {
                    b.HasOne("Hotel.Models.Empresa", null)
                        .WithMany("Empleados")
                        .HasForeignKey("EmpresaId");
                });

            modelBuilder.Entity("Hotel.Models.Habitacion", b =>
                {
                    b.HasOne("Hotel.Models.Empleado", null)
                        .WithMany("Habitaciones")
                        .HasForeignKey("EmpleadoId");

                    b.HasOne("Hotel.Models.Empresa", null)
                        .WithMany("Habitaciones")
                        .HasForeignKey("EmpresaId");
                });

            modelBuilder.Entity("Hotel.Models.Organigrama", b =>
                {
                    b.HasOne("Hotel.Models.Empleado", "Empleados")
                        .WithMany()
                        .HasForeignKey("EmpleadosId");

                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Hotel.Models.Telefono", b =>
                {
                    b.HasOne("Hotel.Models.Empleado", null)
                        .WithMany("Telefonos")
                        .HasForeignKey("EmpleadoId");

                    b.HasOne("Hotel.Models.Empresa", null)
                        .WithMany("Telefonos")
                        .HasForeignKey("EmpresaId");
                });

            modelBuilder.Entity("Hotel.Models.Empleado", b =>
                {
                    b.Navigation("Habitaciones");

                    b.Navigation("Telefonos");
                });

            modelBuilder.Entity("Hotel.Models.Empresa", b =>
                {
                    b.Navigation("Empleados");

                    b.Navigation("Habitaciones");

                    b.Navigation("Telefonos");
                });
#pragma warning restore 612, 618
        }
    }
}
