using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Models;

namespace UsersAPI.Data;

public partial class UsersdbContext : DbContext
{
    public UsersdbContext()
    {
    }

    public UsersdbContext(DbContextOptions<UsersdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Usergroup> Usergroups { get; set; }

    public virtual DbSet<Userstate> Userstates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Userid)
                .ValueGeneratedNever()
                .HasColumnName("userid");
            entity.Property(e => e.Createddate).HasColumnName("createddate");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Usergroudid).HasColumnName("usergroudid");
            entity.Property(e => e.Userstateid).HasColumnName("userstateid");

            entity.HasOne(d => d.Usergroud).WithMany(p => p.Users)
                .HasForeignKey(d => d.Usergroudid)
                .HasConstraintName("usergroup");

            entity.HasOne(d => d.Userstate).WithMany(p => p.Users)
                .HasForeignKey(d => d.Userstateid)
                .HasConstraintName("userstate");
        });

        modelBuilder.Entity<Usergroup>(entity =>
        {
            entity.HasKey(e => e.Usergroupid).HasName("usergroups_pkey");

            entity.ToTable("usergroups");

            entity.Property(e => e.Usergroupid)
                .ValueGeneratedNever()
                .HasColumnName("usergroupid");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<Userstate>(entity =>
        {
            entity.HasKey(e => e.Userstateid).HasName("userstates_pkey");

            entity.ToTable("userstates");

            entity.Property(e => e.Userstateid)
                .ValueGeneratedNever()
                .HasColumnName("userstateid");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
