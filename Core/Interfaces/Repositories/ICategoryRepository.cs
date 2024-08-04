using Core.Entities;

namespace Core.Interfaces.Repositories;

/// <summary>
/// Inteface que define os métodos específicos para as classes de repositorio de categorias que a implementarem
/// </summary>
public interface ICategoryRepository : IRepository<Category>
{
    /// <summary>
    /// Lista os produtos da categoria
    /// </summary>
    /// <remarks> Este método é responsável por listar os produtos da categoria passada por parâmetro e os classificam por ordem alfabética </remarks>
    /// <param name="category"> Catedoria que terá seus produtos listados</param>
    /// <returns> Retorna uma coleção de produtos da categoria </returns>
    Task<ICollection<Product>?> GetProductsByCategory(Category category);
}
