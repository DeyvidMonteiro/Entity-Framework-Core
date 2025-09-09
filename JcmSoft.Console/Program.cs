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