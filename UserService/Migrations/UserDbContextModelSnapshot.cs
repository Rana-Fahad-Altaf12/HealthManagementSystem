﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserService.Data;

#nullable disable

namespace UserService.Migrations
{
    [DbContext(typeof(UserDbContext))]
    partial class UserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UserService.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "fahad@gmail.com",
                            Password = "$2a$11$GMmcosZ5SrS9BFvuGjTZCOI54sOt8t4D0q63emHbZPywfBdUd78tq",
                            Username = "fahad"
                        },
                        new
                        {
                            Id = 2,
                            Email = "ali@gmail.com",
                            Password = "$2a$11$a7aAWKFAiLaZ3Ce6XNn6X.SHO1.FZ4IpsPeGxM/cf.XMpyYBR5RUe",
                            Username = "ali"
                        },
                        new
                        {
                            Id = 3,
                            Email = "hamza@gmail.com",
                            Password = "$2a$11$BL8Y.i6AKFjVYrXwk1Ki1OzdCuq0/waM08zEVETK/Miv9whNLD/ui",
                            Username = "hamza"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
