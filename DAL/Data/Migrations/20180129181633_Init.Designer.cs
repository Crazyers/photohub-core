﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PhotoHub.DAL.Data;
using System;

namespace PhotoHub.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180129181633_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("photohub.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Avatar");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("photohub.Models.BlackList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlockedUserId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BlockedUserId");

                    b.HasIndex("UserId");

                    b.ToTable("BlackLists");
                });

            modelBuilder.Entity("photohub.Models.BlackListGiveaway", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlockedGiveawayId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BlockedGiveawayId");

                    b.HasIndex("UserId");

                    b.ToTable("BlackListsGiveaway");
                });

            modelBuilder.Entity("photohub.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("OwnerId");

                    b.Property<int>("PhotoId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PhotoId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("photohub.Models.Confirmed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdminId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("UserId");

                    b.ToTable("Confirmed");
                });

            modelBuilder.Entity("photohub.Models.Filter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Filters");
                });

            modelBuilder.Entity("photohub.Models.Following", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FollowedUserId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("FollowedUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Followings");
                });

            modelBuilder.Entity("photohub.Models.Giveaway", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About");

                    b.Property<string>("Avatar");

                    b.Property<DateTime>("DateEnd");

                    b.Property<DateTime>("DateStart");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Giveaways");
                });

            modelBuilder.Entity("photohub.Models.GiveawayOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GiveawayId");

                    b.Property<string>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("GiveawayId");

                    b.HasIndex("OwnerId");

                    b.ToTable("GiveawayOwners");
                });

            modelBuilder.Entity("photohub.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("OwnerId");

                    b.Property<int>("PhotoId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PhotoId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("photohub.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GiveawayId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GiveawayId");

                    b.HasIndex("UserId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("photohub.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("FilterId");

                    b.Property<int?>("GiveawayId");

                    b.Property<string>("OwnerId");

                    b.Property<string>("Path");

                    b.Property<int>("PhotoViewId");

                    b.HasKey("Id");

                    b.HasIndex("FilterId");

                    b.HasIndex("GiveawayId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PhotoViewId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("photohub.Models.PhotoView", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.HasKey("Id");

                    b.ToTable("PhotoViews");
                });

            modelBuilder.Entity("photohub.Models.Winner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GiveawayId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GiveawayId");

                    b.HasIndex("UserId");

                    b.ToTable("Winners");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("photohub.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("photohub.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("photohub.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("photohub.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("photohub.Models.BlackList", b =>
                {
                    b.HasOne("photohub.Models.ApplicationUser", "BlockedUser")
                        .WithMany()
                        .HasForeignKey("BlockedUserId");

                    b.HasOne("photohub.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("photohub.Models.BlackListGiveaway", b =>
                {
                    b.HasOne("photohub.Models.Giveaway", "BlockedGiveaway")
                        .WithMany()
                        .HasForeignKey("BlockedGiveawayId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("photohub.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("photohub.Models.Comment", b =>
                {
                    b.HasOne("photohub.Models.ApplicationUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.HasOne("photohub.Models.Photo", "Photo")
                        .WithMany("Comments")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("photohub.Models.Confirmed", b =>
                {
                    b.HasOne("photohub.Models.ApplicationUser", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId");

                    b.HasOne("photohub.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("photohub.Models.Following", b =>
                {
                    b.HasOne("photohub.Models.ApplicationUser", "FollowedUser")
                        .WithMany()
                        .HasForeignKey("FollowedUserId");

                    b.HasOne("photohub.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("photohub.Models.GiveawayOwner", b =>
                {
                    b.HasOne("photohub.Models.Giveaway", "Giveaway")
                        .WithMany("Owners")
                        .HasForeignKey("GiveawayId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("photohub.Models.ApplicationUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("photohub.Models.Like", b =>
                {
                    b.HasOne("photohub.Models.ApplicationUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.HasOne("photohub.Models.Photo", "Photo")
                        .WithMany("Likes")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("photohub.Models.Participant", b =>
                {
                    b.HasOne("photohub.Models.Giveaway", "Giveaway")
                        .WithMany("Participants")
                        .HasForeignKey("GiveawayId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("photohub.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("photohub.Models.Photo", b =>
                {
                    b.HasOne("photohub.Models.Filter", "Filter")
                        .WithMany("Photos")
                        .HasForeignKey("FilterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("photohub.Models.Giveaway")
                        .WithMany("Photos")
                        .HasForeignKey("GiveawayId");

                    b.HasOne("photohub.Models.ApplicationUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.HasOne("photohub.Models.PhotoView", "PhotoView")
                        .WithMany()
                        .HasForeignKey("PhotoViewId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("photohub.Models.Winner", b =>
                {
                    b.HasOne("photohub.Models.Giveaway", "Giveaway")
                        .WithMany("Winners")
                        .HasForeignKey("GiveawayId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("photohub.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}