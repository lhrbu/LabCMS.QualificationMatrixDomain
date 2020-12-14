using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabCMS.QualificationMatrixDomain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace LabCMS.QualificationMatrixDomain.Server.Repositories
{
    public class QualificationMatrixRepository:DbContext
    {
        public QualificationMatrixRepository(DbContextOptions<QualificationMatrixRepository> options)
            : base(options) { }
        public DbSet<SkillDomain> SkillDomains => Set<SkillDomain>();
        public DbSet<Skill> Skills => Set<Skill>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<PositionRequirementScore> PositionRequirementScores => Set<PositionRequirementScore>();
        public DbSet<EmployeeEvaluationScore> EmployeeEvaluationScores => Set<EmployeeEvaluationScore>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasIndex(item => item.Name);
            modelBuilder.Entity<Skill>()
                .HasIndex(item => item.Name);

            modelBuilder.Entity<EmployeeEvaluationScore>()
                .HasKey(item => new { item.EmployeeId, item.SkillId });
            modelBuilder.Entity<EmployeeEvaluationScore>()
                .HasIndex(item => item.EmployeeId);
            modelBuilder.Entity<EmployeeEvaluationScore>()
                .HasIndex(item => item.SkillId);

            modelBuilder.Entity<PositionRequirementScore>()
                .HasKey(item => new { item.PositionId, item.SkillId });
            modelBuilder.Entity<PositionRequirementScore>()
                .HasIndex(item => item.PositionId);
            modelBuilder.Entity<PositionRequirementScore>()
                .HasIndex(item => item.SkillId);
        }
    }
}
