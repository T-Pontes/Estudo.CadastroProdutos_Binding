using Core.Entities;
using Core.Enums;
using Infra.Adapters.DTOs;

namespace Infra.Adapters.Mappings;

/// <summary>
/// Classe responsável por prover o mapeamento da entitidade categoria para seu respectivo DTO e vice-versa 
/// </summary>
public static class CategoryMapping
{
    /// <summary> Método de mapeamento de "Entidades" para "DTOs". </summary>
    /// /// <param name="obj"> Parametro obrigatório sem valor padrão. </param>
    public static CategoryDTO EntityToDTO(Category obj)
    {
        return new CategoryDTO()
        {
            Id = obj.Id,
            CategoryName = obj.CategoryName,
            CategoryDescription = obj.CategoryDescription,
            CategoryStatus = obj.CategoryStatus == EStatus.Active ? true : false,
        };
    }

    /// <summary> Método de mapeamento de "DTOs" para "Entidades". </summary>
    /// /// <param name="obj"> Parametro obrigatório sem valor padrão. </param>
    public static Category DTOToEntity(CategoryDTO obj)
    {
        return new Category(
            obj.CategoryName,
            obj.CategoryDescription,
            obj.CategoryStatus == true ? EStatus.Active : EStatus.Inactive,
            obj.Id
            );
    }
}
