using Core.Entities;

namespace Core.Interfaces.Repositories;

/// <summary>
/// Inteface que define os métodos específicos para as classes de repositorio de produtos que a implementarem
/// </summary>
public interface IProductRepository : IRepository<Product> { }
