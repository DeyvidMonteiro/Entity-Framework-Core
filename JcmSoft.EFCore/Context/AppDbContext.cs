using JcmSoft.Domain.Entities;
using JcmSoft.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace JcmSoft.EFCore.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<FuncionarioDetalhe> FuncionarioDetalhes { get; set; }

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


            modelBuilder.Entity<Funcionario>(entity =>
            {

                entity.Property(e => e.Nome).HasMaxLength(100).IsRequired();

                entity.Property(e => e.Cargo).HasMaxLength(100).IsRequired();

                entity.Property(e => e.Salario).HasPrecision(12, 2);

                entity.HasData(
                new
                {
                    FuncionarioId = 1,
                    Nome = "João da Silva",
                    Cargo = "Analista Financeiro",
                    Salario = 5000.00m,
                    DataContratacao = new DateOnly(2025, 9, 11),
                    DepartamentoId = 1
                },
                new
                {
                    FuncionarioId = 2,
                    Nome = "Maria Oliveira",
                    Cargo = "Gestora de Marketing",
                    Salario = 4800.00m,
                    DataContratacao = new DateOnly(2025, 9, 11),
                    DepartamentoId = 2
                },
                new
                {
                    FuncionarioId = 3,
                    Nome = "Carlos Souza",
                    Cargo = "Desenvolvedor Back-end",
                    Salario = 6200.00m,
                    DataContratacao = new DateOnly(2024, 12, 1),
                    DepartamentoId = 2
                });

            });

            modelBuilder.Entity<FuncionarioDetalhe>(entity =>
            {

                entity.Property(e => e.EnderecoResidencial).HasMaxLength(200).IsRequired();

                entity.Property(e => e.Celular).HasMaxLength(50).IsRequired();

                entity.Property(e => e.Foto).HasMaxLength(50).IsRequired();

                entity.Property(e => e.CPF).HasMaxLength(20).IsRequired();

                entity.Property(e => e.Nacionalidade).HasMaxLength(50).IsRequired();

                entity.Property(e => e.Genero).IsRequired();

                entity.Property(e => e.Escolaridade).IsRequired();

                entity.Property(e => e.EstadoCivil).IsRequired();

                entity.HasData(
                    new FuncionarioDetalhe
                    {
                        FuncionarioDetalheId = 1,
                        EnderecoResidencial = "Rua das Flores, 123",
                        DataNascimento = new DateTime(1990, 5, 12),
                        Celular = "(11) 99999-1234",
                        Genero = Genero.Masculino,
                        Foto = "foto1.jpg",
                        EstadoCivil = EstadoCivil.Solteiro,
                        CPF = "12345678901",
                        Nacionalidade = "Brasileiro",
                        Escolaridade = Escolaridade.PosGraduado,
                        FuncionarioId = 1
                    },
                    new FuncionarioDetalhe
                    {
                        FuncionarioDetalheId = 2,
                        EnderecoResidencial = "Av. Central, 456",
                        DataNascimento = new DateTime(1985, 8, 30),
                        Celular = "(21) 98888-5678",
                        Genero = Genero.Feminino,
                        Foto = "foto2.jpg",
                        EstadoCivil = EstadoCivil.Casado,
                        CPF = "98765432100",
                        Nacionalidade = "Brasileira",
                        Escolaridade = Escolaridade.Mestrado,
                        FuncionarioId = 2
                    },
                    new FuncionarioDetalhe
                    {
                        FuncionarioDetalheId = 3,
                        EnderecoResidencial = "Rua da Paz, 789",
                        DataNascimento = new DateTime(1995, 2, 20),
                        Celular = "(31) 97777-9090",
                        Genero = Genero.Masculino,
                        Foto = "foto3.jpg",
                        EstadoCivil = EstadoCivil.Solteiro,
                        CPF = "11122233344",
                        Nacionalidade = "Brasileiro",
                        Escolaridade = Escolaridade.Tecnico,
                        FuncionarioId = 3
                    }
                );

            });
        }
    }
}
