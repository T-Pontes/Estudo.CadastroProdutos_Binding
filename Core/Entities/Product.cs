using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

/// <summary> Classe que agrupa as propriedades e comportamentos do produto. </summary>
public class Product : PK
{
    #region Constructors

    /// <summary> Construtor padrão. </summary>
    public Product() { }

    /// <summary> Construtor com parâmetros. </summary>
    /// <param name="id"> Parametro opcional com valor padrão igual a "-1". </param>
    /// <param name="productName"> Parâmetro obrigatório sem valor padrão. </param>
    /// <param name="price"> Parâmetro obrigatório sem valor padrão. </param>
    /// <param name="category"> Parâmetro obrigatório sem valor padrão. </param>
    /// <param name="productDescription"> Parâmetro opcional com valor padrão "null". </param>
    /// <param name="productStatus"> Parâmetro opcinal com valor padrão "Ativo". </param>
    public Product(string productName, double price, Category category, string? productDescription = null, EStatus productStatus = EStatus.Active, int id = -1) : base(id)
    {
        ProductName = productName;
        Price = price;
        Category = category;
        ProductDescription = productDescription;
        ProductStatus = productStatus;
    }

    #endregion

    #region Properties

    [Required(ErrorMessage = "O preenchimento do nome do produto é obrigatório.")]
    [StringLength(80, ErrorMessage = "O nome do produto deve ter no máximo 80 caracteres.")]
    public string ProductName { get; private set; } = null!;

    [StringLength(200, ErrorMessage = "A descrição do produto deve ter no máximo 200 caracteres.")]
    public string? ProductDescription { get; private set; }

    [Required(ErrorMessage = "O preenchimento do preço do produto é obrigatório.")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    public double Price { get; private set; }

    [Required(ErrorMessage = "O preenchimento do status da categoria é obrigatório.")]
    public EStatus ProductStatus{ get; private set; }

    [Required(ErrorMessage = "O preenchimento da categoria do produto é obrigatório.")]
    public Category Category { get; private set; } = null!;

    #endregion

    #region Methods

    // Summary configurado na classe pai (PK)
    public override void ObjectActivated(bool option = true)
        => ProductStatus = option ? EStatus.Active : EStatus.Inactive;

    /// <summary> Altera o preço do produto. </summary>
    /// <param name="price"> Parametro obrigatório sem valor padrão. </param>
    public void ChangePrice(double price)
        => Price = price;

    #endregion
}
