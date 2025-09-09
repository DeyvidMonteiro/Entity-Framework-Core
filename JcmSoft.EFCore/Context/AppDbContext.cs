using JcmSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JcmSoft.EFCore.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optnBuilder)
        {
            optnBuilder.UseSqlServer(AppConfig.GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //para sobrescrever a convenção padrao

            modelBuilder.HasDefaultSchema("jcmsoft");

            modelBuilder.Entity<Departamento>()
                .HasKey(x => x.DepartamentoId);

            modelBuilder.Entity<Departamento>()
                .Property(x => x.Descricao)
                .HasColumnName("Descricao_Departamento")
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Departamento>()
                .Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Departamento>()
                .Property(x => x.DataCriacao)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Departamento>()
                .HasData(new Departamento { DepartamentoId = 1, Nome = "Treinamento", Descricao = "Treinamento de Pessoal" },
                         new Departamento { DepartamentoId = 2, Nome = "Desenvolvimento", Descricao = "Desenvolvimento de projetos" });

        }
    }
}
