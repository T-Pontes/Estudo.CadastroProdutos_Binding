using Core.Entities;
using Core.Enums;
using Infra.Adapters.DTOs;

namespace Infra.Adapters.Mappings;

public class ProductMapping
{
    /// <summary> Método de mapeamento de "Entidades" para "DTOs". </summary>
    /// /// <param name="obj"> Parametro obrigatório sem valor padrão. </param>
    public static ProductDTO EntityToDTO(Product obj)
    {
        return new ProductDTO()
        {
            Id = obj.Id,
            ProductName = obj.ProductName,
            ProductDescription = obj.ProductDescription,
            Price = obj.Price.ToString(),
            Category = CategoryMapping.EntityToDTO(obj.Category),
        };
    }

    /// <summary> Método de mapeamento de "DTOs" para "Entidades". </summary>
    /// /// <param name="obj"> Parametro obrigatório sem valor padrão. </param>
    public static Product DTOToEntity(ProductDTO obj)
    {
        return new Product(
            obj.ProductName,
            Convert.ToDouble(obj.Price),
            CategoryMapping.DTOToEntity(obj.Category),
            obj.ProductDescription,
            obj.ProductStatus == true ? EStatus.Active : EStatus.Inactive,
            obj.Id
            );
    }
}
