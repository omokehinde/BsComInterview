using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BsComInterview.Models;

namespace BsComInterview.Migrations
{
    [DbContext(typeof(UserDocContext))]
    partial class UserDocContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BsComInterview.Models.Document", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("File")
                        .IsRequired();

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("BsComInterview.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(65);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(65);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(65);

                    b.Property<int>("TransactionNumber");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BsComInterview.Models.Document", b =>
                {
                    b.HasOne("BsComInterview.Models.User", "User")
                        .WithMany("Documents")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
