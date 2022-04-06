﻿// <auto-generated />
using System;
using BookExchange.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookExchange.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("BookExchange.Core.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Availability")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("YearOfPublication")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookExchange.Core.Models.BorrowedBook", b =>
                {
                    b.Property<Guid>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BookId1")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BorrowerId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("TEXT");

                    b.HasKey("BookId");

                    b.HasIndex("BookId1");

                    b.HasIndex("BorrowerId");

                    b.ToTable("BorrowedBooks");
                });

            modelBuilder.Entity("BookExchange.Core.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BookExchange.Core.Models.Request", b =>
                {
                    b.Property<Guid>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ApprovalDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ApproverId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BookId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CurrentDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RequesterId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ResponseStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("TEXT");

                    b.HasKey("RequestId");

                    b.HasIndex("ApproverId");

                    b.HasIndex("BookId");

                    b.HasIndex("RequesterId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("BookExchange.Core.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("TEXT");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookExchange.Core.Models.Book", b =>
                {
                    b.HasOne("BookExchange.Core.Models.Category", "Category")
                        .WithMany("Book")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookExchange.Core.Models.User", "Owner")
                        .WithMany("Books")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("BookExchange.Core.Models.BorrowedBook", b =>
                {
                    b.HasOne("BookExchange.Core.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookExchange.Core.Models.User", "Borrower")
                        .WithMany()
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Borrower");
                });

            modelBuilder.Entity("BookExchange.Core.Models.Request", b =>
                {
                    b.HasOne("BookExchange.Core.Models.User", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookExchange.Core.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookExchange.Core.Models.User", "Requester")
                        .WithMany()
                        .HasForeignKey("RequesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Approver");

                    b.Navigation("Book");

                    b.Navigation("Requester");
                });

            modelBuilder.Entity("BookExchange.Core.Models.Category", b =>
                {
                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookExchange.Core.Models.User", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
