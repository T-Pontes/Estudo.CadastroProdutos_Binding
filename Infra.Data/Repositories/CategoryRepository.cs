using Core.Entities;
using Core.Interfaces.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

/// <summary>
/// Classe responsável por implementar o repositório de <see cref="Category"/>
/// </summary>
public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    /// <summary>
    /// Incluir objeto na tabela correspondente
    /// </summary>
    /// <remarks>
    /// Este método é responsável pela inclusão de um(a) novo(a) <see cref="Category"/> no banco de dados
    /// </remarks>
    /// <param name="obj"> Objeto que será incluído no banco de dados </param>
    /// <returns> Retorna o objeto recém incluído no banco de dados </returns>
    /// <exception cref="OperationCanceledException"/>
    /// <exception cref="DbUpdateConcurrencyException"/>
    /// <exception cref="DbUpdateException"/>
    public async Task<Category> CreateAsync(Category obj)
    {
        try
        {
            await context.Categories.AddAsync(obj);
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
    /// Este método é responsável pela exclusão de um(a) <see cref="Category"/> no banco de dados
    /// </remarks>
    /// <param name="obj"> Objeto que será excluído no banco de dados </param>
    /// <exception cref="OperationCanceledException"/>
    /// <exception cref="DbUpdateConcurrencyException"/>
    /// <exception cref="DbUpdateException"/>
    public async Task DeleteAsync(Category obj)
    {
        try
        {
            context.Categories.Remove(obj);
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
    /// Este método é responsável por listar todos(as) os(as) <see cref="Category">Categories</see> do banco de dados
    /// </remarks>
    /// <returns> Retorna uma coleção de objetos do banco de dados </returns>
    /// <exception cref="OperationCanceledException"/>
    /// <exception cref="ArgumentNullException"/>
    public async Task<ICollection<Category>?> GetAllAsync()
    {
        try
        {
            return await context.Categories.ToListAsync();
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
    /// Este método é responsável pelo retorno de um(a) <see cref="Category"/> por "Id" do banco de dados
    /// </remarks>
    /// <param name="obj"> Identificador do objeto no banco de dados </param>
    /// <returns> Retorna o objeto com base em seu "Id" no banco de dados </returns>
    /// <exception cref="OperationCanceledException"/>
    /// <exception cref="ArgumentNullException"/>
    public async Task<Category?> GetByIdAsync(int id)
    {
        try
        {
            return await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
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
    /// Retorna uma coleção de objetos pelo parâmetro na tabela correspondente
    /// </summary>
    /// <remarks>
    /// Este método é responsável por listar todos(as) os(as) <see cref="Product"/> do(a) <see cref="Category"/> passada como parâmetro
    /// </remarks>
    /// <param name="category"> Objeto para retorno da coleção </param>
    /// <returns> Retorna uma coleção de objetos do banco de dados </returns>
    /// <exception cref="OperationCanceledException"/>
    /// <exception cref="ArgumentNullException"/>
    public async Task<ICollection<Product>?> GetProductsByCategory(Category category)
    {
        try
        {
            return await context.Products.Where(x => x.Category == category).ToListAsync();
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
    /// Este método é responsável pela atualização de um(a) <see cref="Category"/> no banco de dados
    /// </remarks>
    /// <param name="obj"> Objeto que será atualizado no banco de dados </param>
    /// <returns> Retorna o objeto atualizado do banco de dados </returns>
    /// <exception cref="OperationCanceledException"></exception>
    /// <exception cref="DbUpdateConcurrencyException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    public async Task<Category> UpdateAsync(Category obj)
    {
        try
        {
            context.Categories.Update(obj);
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