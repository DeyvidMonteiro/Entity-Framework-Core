namespace JcmSoft.Domain.Entities
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string? Nome{ get; set; }
        public string? Cargo { get; set; }
        public decimal Salario { get; set; }
        public DateOnly DataContratacao { get; set; }

        //propriedade de chave estrangeira 
        public int DepartamentoId { get; set; }

        //propriedade de navegação de referencia
        public Departamento? Departamento { get; set; }
        //propriedade de nagvegaçãp de referencia para funcionarioDetalhe
        public FuncionarioDetalhe? FuncionarioDetalhe { get; set; }

    }
}
