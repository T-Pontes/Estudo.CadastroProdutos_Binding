using Core.Entities;
using Core.Interfaces.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

/// <summary>
/// Classe responsável por implementar o repositório de <see cref="Product"/>
/// </summary>
public class ProductRepository(AppDbContext context) : IProductRepository
{
    /// <summary>
    /// Incluir objeto na tabela correspondente
    /// </summary>
    /// <remarks>
    /// Este método é responsável pela inclusão de um(a) novo(a) <see cref="Product"/> no banco de dados
    /// </remarks>
    /// <param name="obj"> Objeto que será incluído no banco de dados </param>
    /// <returns> Retorna o objeto recém incluído no banco de dados </returns>
    /// <exception cref="OperationCanceledException"/>
    /// <exception cref="DbUpdateConcurrencyException"/>
    /// <exception cref="DbUpdateException"/>
    public async Task<Product> CreateAsync(Product obj)
    {
        try
        {
            await context.Products.AddAsync(obj);
            context.Entry(obj).State = EntityState.Added;
            await context.SaveChangesAsync();
            return obj;
        }
        catch (OperationCanceledException ex)
        {
            throw new OperationCanceledException($"Erro: {ex.Message} {Environment.NewLine}" +
                                                 $"StackTrace: {ex.StackTrace}");
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new DbUpdateConcurrencyException($"Erro: {ex.Message} {Environment.NewLine}" +
                                                   $"StackTrace: {ex.StackTrace}");
        }
        catch (DbUpdateException ex)
        {
            throw new DbUpdateException($"Erro: {ex.Message} {Environment.NewLine}" +
                                        $"StackTrace: {ex.StackTrace}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro: {ex.Message} {Environment.NewLine}" +
                                $"StackTrace: {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Excluir objeto da tabela correspondente
    /// </summary>
    /// <remarks>
    /// Este método é responsável pela exclusão de um(a) <see cref="Product"/> no banco de dados
    /// </remarks>
    /// <param name="obj"> Objeto que será excluído no banco de dados </param>
    /// <exception cref="OperationCanceledException"/>
    /// <exception cref="DbUpdateConcurrencyException"/>
    /// <exception cref="DbUpdateException"/>
    public async Task DeleteAsync(Product obj)
    {
        try
        {
            context.Products.Remove(obj);
            context.Entry(obj).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
        catch (OperationCanceledException ex)
        {
            throw new OperationCanceledException($"Erro: {ex.Message} {Environment.NewLine}" +
                                                 $"StackTrace: {ex.StackTrace}");
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new DbUpdateConcurrencyException($"Erro: {ex.Message} {Environment.NewLine}" +
                                                   $"StackTrace: {ex.StackTrace}");
        }
        catch (DbUpdateException ex)
        {
            throw new DbUpdateException($"Erro: {ex.Message} {Environment.NewLine}" +
                                        $"StackTrace: {ex.StackTrace}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro: {ex.Message} {Environment.NewLine}" +
                                $"StackTrace: {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Lista todos os objetos da tabela correspondente
    /// </summary>
    /// <remarks>
    /// Este método é responsável por listar todos(as) os(as) <see cref="Product">Products</see> do banco de dados
    /// </remarks>
    /// <returns> Retorna uma coleção de objetos do banco de dados </returns>
    /// <exception cref="OperationCanceledException"/>
    /// <exception cref="ArgumentNullException"/>
    public async Task<ICollection<Product>?> GetAllAsync()
    {
        try
        {
            return await context.Products.ToListAsync();
        }
        catch (OperationCanceledException ex)
        {
            throw new OperationCanceledException($"Erro: {ex.Message} {Environment.NewLine}" +
                                                 $"StackTrace: {ex.StackTrace}");
        }
        catch (ArgumentNullException ex)
        {
            throw new ArgumentNullException($"Erro: {ex.Message} {Environment.NewLine}" +
                                            $"StackTrace: {ex.StackTrace}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro: {ex.Message} {Environment.NewLine}" +
                                $"StackTrace: {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Retorna um objeto pelo "Id" na tabela correspondente
    /// </summary>
    /// <remarks>
    /// Este método é responsável pelo retorno de um(a) <see cref="Product"/> por "Id" do banco de dados
    /// </remarks>
    /// <param name="obj"> Identificador do objeto no banco de dados </param>
    /// <returns> Retorna o objeto com base em seu "Id" no banco de dados </returns>
    /// <exception cref="OperationCanceledException"/>
    /// <exception cref="ArgumentNullException"/>
    public async Task<Product?> GetByIdAsync(int id)
    {
        try
        {
            return await context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (OperationCanceledException ex)
        {
            throw new OperationCanceledException($"Erro: {ex.Message} {Environment.NewLine}" +
                                                 $"StackTrace: {ex.StackTrace}");
        }
        catch (ArgumentNullException ex)
        {
            throw new ArgumentNullException($"Erro: {ex.Message} {Environment.NewLine}" +
                                            $"StackTrace: {ex.StackTrace}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro: {ex.Message} {Environment.NewLine}" +
                                $"StackTrace: {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Atualizar objeto na tabela correspondente
    /// </summary>
    /// <remarks>
    /// Este método é responsável pela atualização de um(a) <see cref="Product"/> no banco de dados
    /// </remarks>
    /// <param name="obj"> Objeto que será atualizado no banco de dados </param>
    /// <returns> Retorna o objeto atualizado do banco de dados </returns>
    /// <exception cref="OperationCanceledException"></exception>
    /// <exception cref="DbUpdateConcurrencyException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    public async Task<Product> UpdateAsync(Product obj)
    {
        try
        {
            context.Products.Update(obj);
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
        catch (OperationCanceledException ex)
        {
            throw new OperationCanceledException($"Erro: {ex.Message} {Environment.NewLine}" +
                                                 $"StackTrace: {ex.StackTrace}");
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new DbUpdateConcurrencyException($"Erro: {ex.Message} {Environment.NewLine}" +
                                                   $"StackTrace: {ex.StackTrace}");
        }
        catch (DbUpdateException ex)
        {
            throw new DbUpdateException($"Erro: {ex.Message} {Environment.NewLine}" +
                                        $"StackTrace: {ex.StackTrace}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro: {ex.Message} {Environment.NewLine}" +
                                $"StackTrace: {ex.StackTrace}");
        }
    }
}
