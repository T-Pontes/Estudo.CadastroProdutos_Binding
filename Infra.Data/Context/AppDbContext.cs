using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context;

/// <summary>
/// Classe responsável por fornecer a base para uma instância de contexto de bando de dados
/// </summary>
/// <param name="optionsBuilder"> Parâmetro que contém as configurações de acesso ao banco de dados </param>
public class AppDbContext(DbContextOptionsBuilder optionsBuilder) : DbContext(optionsBuilder.Options)
{
    /// <summary>
    /// Coleção de objetos de "Category" restreados no contexto
    /// </summary>
    public DbSet<Category> Categories { get; set; }

    /// <summary>
    /// Coleção de objetos de "Product" restreados no contexto
    /// </summary>
    public DbSet<Product> Products { get; set; }
}
