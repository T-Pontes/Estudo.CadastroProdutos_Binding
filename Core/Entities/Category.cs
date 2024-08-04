using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

/// <summary> Classe que agrupa as propriedades e comportamentos da categoria dos produtos vinculados. </summary>
public class Category : PK
{
    #region Constructors

    /// <summary> Construtor padrão. </summary>
    public Category() { }

    /// <summary> Construtor com parâmetros. </summary>
    /// <param name="id"> Parametro opcional com valor padrão igual a "-1". </param>
    /// <param name="categoryName"> Parâmetro obrigatório sem valor padrão. </param>
    /// <param name="categoryDescription"> Parâmetro opcional com valor padrão "null". </param>
    /// <param name="categoryStatus"> Parâmetro opcinal com valor padrão "Ativo". </param>
    public Category(string categoryName, string? categoryDescription = null, EStatus categoryStatus = EStatus.Active, int id = -1) : base(id)
    {
        CategoryName = categoryName;
        CategoryDescription = categoryDescription;
        CategoryStatus = categoryStatus;
    }

    #endregion

    #region Properties

    [Required(ErrorMessage = "O preenchimento do nome da categoria é obrigatório.")]
    [StringLength(80, ErrorMessage = "O nome da catagoria deve ter no máximo 80 caracteres.")]
    public string CategoryName { get; private set; } = null!;

    [StringLength(200, ErrorMessage = "A descrição da catagoria deve ter no máximo 200 caracteres.")]
    public string? CategoryDescription { get; private set; }

    [Required(ErrorMessage = "O preenchimento do status da categoria é obrigatório.")]
    public EStatus CategoryStatus { get; private set; }

    public List<Product> Products { get; private set; } = [];

    #endregion

    #region Methods

    // Summary configurado na classe pai (PK)
    public override void ObjectActivated(bool option = true)
        => CategoryStatus = option ? EStatus.Active : EStatus.Inactive;
    #endregion
}
