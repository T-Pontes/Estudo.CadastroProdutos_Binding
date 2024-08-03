namespace Infra.Adapters.DTOs;

/// <summary> Classe responsável pela tranferência de valores de propriedades da entidade "Produto" sem expô-la. </summary>
public class ProductDTO
{
    public int Id { get; set; }
    public string ProductName { get; set; } = null!;
    public string? ProductDescription { get; set; }
    public string Price { get; set; } = null!;
    public bool ProductStatus { get; set; }

    public CategoryDTO Category { get; set; } = null!;
}
