using JcmSoft.Domain.Entities;
using JcmSoft.Domain.Entities.Enums;
using JcmSoft.EFCore.Context;

using (AppDbContext context = new AppDbContext())
{
    context.Database.EnsureDeleted();
    Console.WriteLine("Criando Banco de dados...\n");
    context.Database.EnsureCreated();

    CriarDepartamento(context);
    InserirFuncionarios(context);
    IncluirFuncionarioAddRelacional(context);
    IncluirFuncionarioAddrangeRelacional(context);
    AddDetalhesParaFuncionarios(context);

    Console.WriteLine("Operações realizadas com uscesso... \n");


    //Console.WriteLine("retornandos todos os departamentos usando toList");
    //var departamentos = context.Departamentos.ToList();

    //foreach (var item in departamentos) Console.WriteLine($"ID :{item.DepartamentoId}, Nome: {item.Nome}");

    //Console.ReadKey();

    //Console.WriteLine("\nretornando apenas um departamento usando FirstOrDefault");
    //var departamento = context.Departamentos.FirstOrDefault(d => d.DepartamentoId == 8);

    //if (departamento != null) Console.WriteLine($"ID :{departamento.DepartamentoId}, Nome: {departamento.Nome}");
    //else Console.WriteLine("Departamento nao encontrado");

}

Console.ReadKey();

void AddDetalhesParaFuncionarios(AppDbContext context)
{
    var funcionarioDetalhe = new FuncionarioDetalhe
    {
        //FuncionarioId = 1,
        EnderecoResidencial = "Rua A, 05",
        DataNascimento = new DateTime(2000, 05, 05),
        Celular = "123654789",
        Genero = Genero.Masculino,
        Foto = "foto1.jpg",
        EstadoCivil = EstadoCivil.Solteiro,
        CPF = "123.456.789-12",
        Nacionalidade = "Brasileiro",
        Escolaridade = Escolaridade.Superior
    };
    //context.FuncionarioDetalhes.Add(funcionarioDetalhe);

    var funcionario = new Funcionario
    {
        Nome = "João Paulo",
        Cargo = "Desenvolvedor",
        Salario = 5000m,
        DataContratacao = new DateOnly(2023, 7, 1),
        DepartamentoId = 6,
        FuncionarioDetalhe = funcionarioDetalhe,
    };

    context.Funcionarios.Add(funcionario);
    context.SaveChanges();
}

void IncluirFuncionarioAddrangeRelacional(AppDbContext context)
{
    var departamento = new Departamento
    {
        Nome = "vendas",
        Descricao = "Vendas e Compras"
    };

    var funcionarios = new List<Funcionario>
    {
        new() {
            Nome = "Beatriz Souza",
            Cargo = "Coordenadora de Compras",
            Salario = 4700.00m,
            DataContratacao = new DateOnly(2025,09,15),
            Departamento = departamento,
        },

        new() {
            Nome = "Julio Souza",
            Cargo = "Vendedor",
            Salario = 3850.00m,
            DataContratacao = new DateOnly(2025,09,15),
            Departamento = departamento,
        }
    };
    context.Funcionarios.AddRange(funcionarios);
    context.SaveChanges();
}

void IncluirFuncionarioAddRelacional(AppDbContext context)
{
    var departamento = new Departamento
    {
        Nome = "TI",
        Descricao = "Tecnologia da informação"
    };
    departamento.Funcionarios.Add(new Funcionario
    {
        Nome = "Ana Costa",
        Cargo = "Programa Senior",
        Salario = 4650.00m,
        DataContratacao = new DateOnly(2024, 3, 5)
    });
    context.Departamentos.Add(departamento);
    context.SaveChanges();
}

void CriarDepartamento(AppDbContext context)
{
    var departamentos = new List<Departamento>
    {
        new Departamento{ Nome = "Finanças", Descricao = "Gestão de Finanças" },
        new Departamento{ Nome = "Marketing", Descricao = "Promoção de produtos" },
        new Departamento{ Nome = "RH", Descricao = "Recursos Humanos" },
    };

    context.Departamentos.AddRange(departamentos);
    context.SaveChanges();
}

void InserirFuncionarios(AppDbContext context)
{
    var funcionario = new Funcionario
    {
        Nome = "João da silva",
        Cargo = "Analista Financeiro",
        Salario = 5000.00m,
        DataContratacao = new DateOnly(2025, 9, 11),
        DepartamentoId = 1
    };

    context.Funcionarios.Add(funcionario);

    var funcionarios = new List<Funcionario>
    {
        new() {
            Nome = "maria da silva",
            Cargo = "gestor de marketing",
            Salario = 4000.00m,
            DataContratacao = new DateOnly(2025, 9, 11),
            DepartamentoId = 2
        },

        new() {
            Nome = "mariana Oliveira",
            Cargo = "Analista de RH",
            Salario = 5000.00m,
            DataContratacao = new DateOnly(2025, 9, 11),
            DepartamentoId = 3
        }
    };

    context.Funcionarios.AddRange(funcionarios);

    context.SaveChanges();
}