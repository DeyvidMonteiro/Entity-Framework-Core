using JcmSoft.Domain.Entities;
using JcmSoft.EFCore.Context;

using (AppDbContext context = new AppDbContext())
{
    context.Database.EnsureDeleted();
    Console.WriteLine("Criando Banco de dados...\n");
    context.Database.EnsureCreated();

    Console.WriteLine("Criando um departamento...\n");
    CriarDepartamento(context);
    Console.WriteLine("Departamento criado... \n");


    Console.WriteLine("retornandos todos os departamentos usando toList");
    var departamentos = context.Departamentos.ToList();

    foreach (var item in departamentos) Console.WriteLine($"ID :{item.DepartamentoId}, Nome: {item.Nome}");

    Console.ReadKey();

    Console.WriteLine("\nretornando apenas um departamento usando FirstOrDefault");
    var departamento = context.Departamentos.FirstOrDefault(d => d.DepartamentoId == 8);

    if (departamento != null) Console.WriteLine($"ID :{departamento.DepartamentoId}, Nome: {departamento.Nome}");
    else Console.WriteLine("Departamento nao encontrado");

}

Console.ReadKey();
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