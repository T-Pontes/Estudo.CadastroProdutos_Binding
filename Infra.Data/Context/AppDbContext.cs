using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context;

/// <summary>
/// Classe responsável por fornecer a base para uma instância de contexto de bando de dados
/// </summary>
/// <param name="optionsBuilder"> Parâmetro que contém as configurações de acesso ao banco de dados </param>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Este método é responsável por configurar a instância do contexto para representar o banco de dados
    /// </summary>
    /// <param name="optionsBuilder"> Parâmentros de configuração do contexto</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // A configuraçao da string de conexão deverá ser alocada em arquivo de configuração com essa finalidade
        optionsBuilder.UseSqlServer("Data Source=LAPTOP-H21GT0EC\\SQLEXPRESS;Initial Catalog=CadProdDB;Integrated Security=True;Trust Server Certificate=True");
    }

    /// <summary>
    /// Coleção de objetos de "Category" restreados no contexto
    /// </summary>
    public DbSet<Category> Categories { get; set; }

    /// <summary>
    /// Coleção de objetos de "Product" restreados no contexto
    /// </summary>
    public DbSet<Product> Products { get; set; }
}
