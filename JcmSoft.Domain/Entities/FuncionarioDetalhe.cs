using JcmSoft.Domain.Entities.Enums;

namespace JcmSoft.Domain.Entities;

public class FuncionarioDetalhe
{
    public int FuncionarioDetalheId { get; set; }
    public string EnderecoResidencial { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string Celular { get; set; } = string.Empty;
    public Genero? Genero { get; set; }
    public string Foto { get; set; } = string.Empty;
    public EstadoCivil? EstadoCivil { get; set; }
    public string CPF { get; set; } = string.Empty;
    public string Nacionalidade { get; set; } = string.Empty;
    public Escolaridade? Escolaridade { get; set; }

    //propriedade de chave estrangeira
    public int FuncionarioId { get; set; }
    //propriedade de navegação de referencia para funcionario
    public Funcionario? Funcionario { get; set; }
}
