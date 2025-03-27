using System;
using System.Collections.Generic;
using Examen_AlvaroReyes.DB.Examen.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examen_AlvaroReyes.DB.Examen;

public partial class ExamenEntities : DbContext
{
    public ExamenEntities()
    {
    }

    public ExamenEntities(DbContextOptions<ExamenEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<TblTask> TblTasks { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:SupabaseDb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
            .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
            .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
            .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn", "phone" })
            .HasPostgresEnum("auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" })
            .HasPostgresEnum("pgsodium", "key_status", new[] { "default", "valid", "invalid", "expired" })
            .HasPostgresEnum("pgsodium", "key_type", new[] { "aead-ietf", "aead-det", "hmacsha512", "hmacsha256", "auth", "shorthash", "generichash", "kdf", "secretbox", "secretstream", "stream_xchacha20" })
            .HasPostgresEnum("realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" })
            .HasPostgresEnum("realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in" })
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "pgjwt")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("graphql", "pg_graphql")
            .HasPostgresExtension("pgsodium", "pgsodium")
            .HasPostgresExtension("vault", "supabase_vault");

        modelBuilder.Entity<TblTask>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("tbl_tasks_pkey");

            entity.ToTable("tbl_tasks");

            entity.Property(e => e.TaskId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("task_id");
            entity.Property(e => e.TaskActive)
                .HasDefaultValue(true)
                .HasColumnName("task_active");
            entity.Property(e => e.TaskCreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("task_created_at");
            entity.Property(e => e.TaskDelete)
                .HasDefaultValue(false)
                .HasColumnName("task_delete");
            entity.Property(e => e.TaskDescription).HasColumnName("task_description");
            entity.Property(e => e.TaskName).HasColumnName("task_name");
            entity.Property(e => e.TaskUpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("task_updated_at");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("tbl_users_pkey");

            entity.ToTable("tbl_users");

            entity.Property(e => e.UserId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("user_id");
            entity.Property(e => e.UserActive)
                .HasDefaultValue(true)
                .HasColumnName("user_active");
            entity.Property(e => e.UserCreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("user_created_at");
            entity.Property(e => e.UserDelete)
                .HasDefaultValue(false)
                .HasColumnName("user_delete");
            entity.Property(e => e.UserEmail).HasColumnName("user_email");
            entity.Property(e => e.UserName).HasColumnName("user_name");
            entity.Property(e => e.UserPassword).HasColumnName("user_password");
            entity.Property(e => e.UserUpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("user_updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
