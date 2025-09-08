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
    var departamento = new Departamento
    {
        Name = "Desenvolvimento",
        Descricao = "Desenvolvimento de projetos"
    };

    context.Add(departamento);
    context.SaveChanges();
}