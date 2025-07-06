using System;
using System.Collections.Generic;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Configurations;

public partial class StandContext : DbContext
{
    public StandContext()
    {
    }

    public StandContext(DbContextOptions<StandContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MicrogridParametersChangeable> MicrogridParametersChangeables { get; set; }

    public virtual DbSet<MicrogridParametersMeasure> MicrogridParametersMeasures { get; set; }

    public virtual DbSet<MicrogridParametersMeasureChangeable> MicrogridParametersMeasureChangeables { get; set; }

    public virtual DbSet<ParametersChangeable> ParametersChangeables { get; set; }

    public virtual DbSet<ParametersMeasure> ParametersMeasure { get; set; }

    public virtual DbSet<ParametersMeasureChangeable> ParametersMeasureChangeables { get; set; }

    public virtual DbSet<StandPart> StandParts { get; set; }
    public virtual DbSet<Instructions> Instructions { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlite("Data Source=C:\\\\\\\\workspace\\\\\\\\Stand.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Instructions>(entity =>
        {
            entity.HasKey(e => e.InstructionID);

            entity.ToTable("Instructions");

            entity.Property(e => e.InstructionID).HasColumnName("InstructionID");
            
        });
        modelBuilder.Entity<MicrogridParametersChangeable>(entity =>
        {
            
            entity.HasKey(e => e.BlockId);

            entity.ToTable("MicrogridParametersChangeable");

            entity.Property(e => e.BlockId).HasColumnName("BlockID");
            entity.Property(e => e.StandId).HasColumnName("StandID");

            entity.HasOne(d => d.Stand).WithMany(p => p.MicrogridParametersChangeables).HasForeignKey(d => d.StandId);
        });

        modelBuilder.Entity<MicrogridParametersMeasure>(entity =>
        {
            entity.HasKey(e => e.BlockId);

            entity.ToTable("MicrogridParametersMeasure");

            entity.Property(e => e.BlockId).HasColumnName("BlockID");
            entity.Property(e => e.StandId).HasColumnName("StandID");

            entity.HasOne(d => d.Stand).WithMany(p => p.MicrogridParametersMeasures).HasForeignKey(d => d.StandId);
        });

        modelBuilder.Entity<MicrogridParametersMeasureChangeable>(entity =>
        {
            entity.HasKey(e => e.BlockId);

            entity.ToTable("MicrogridParameters_MeasureChangeable");

            entity.Property(e => e.BlockId).HasColumnName("BlockID");
            entity.Property(e => e.StandId).HasColumnName("StandID");

            entity.HasOne(d => d.Stand).WithMany(p => p.MicrogridParametersMeasureChangeables).HasForeignKey(d => d.StandId);
        });

        modelBuilder.Entity<ParametersChangeable>(entity =>
        {
            entity.ToTable("ParametersChangeable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BlockId).HasColumnName("BlockID");

            entity.HasOne(d => d.Block).WithMany(p => p.ParametersChangeables).HasForeignKey(d => d.BlockId);
        });

        modelBuilder.Entity<ParametersMeasure>(entity =>
        {
            entity.ToTable("ParametersMeasure");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BlockId).HasColumnName("BlockID");

            entity.HasOne(d => d.Block).WithMany(p => p.ParametersMeasures).HasForeignKey(d => d.BlockId);
        });

        modelBuilder.Entity<ParametersMeasureChangeable>(entity =>
        {
            entity.ToTable("Parameters_MeasureChangeable");

            entity.HasIndex(e => e.Id, "IX_Parameters_MeasureChangeable_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BlockId).HasColumnName("BlockID");
        });

        modelBuilder.Entity<StandPart>(entity =>
        {
            entity.HasKey(e => e.StandId);

            entity.ToTable("StandPart");

            entity.Property(e => e.StandId).HasColumnName("StandID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
