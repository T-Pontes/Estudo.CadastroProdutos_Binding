namespace Infra.Adapters.DTOs;

/// <summary> Classe responsável pela tranferência de valores de propriedades da entidade "Categoria" sem expô-la. </summary>
public class CategoryDTO
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
    public string? CategoryDescription { get; set; }
    public bool CategoryStatus { get; set; }
}
