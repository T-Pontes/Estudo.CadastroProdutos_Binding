using Core.Entities;

namespace Core.Interfaces.Repositories;

/// <summary>
/// Inteface que define os métodos comuns para todas as classe de repositorios que a implementarem
/// </summary>
public interface IRepository<TEntity> where TEntity : PK
{
    /// <summary>
    /// Salva um objeto na tabela correspondente no banco de dados
    /// </summary>
    /// <remarks>
    /// Este método é responsável por salvar no banco de dados o "obj" passado por parâmentro após as devidas validações 
    /// </remarks>
    /// <param name="obj"> O objeto que será salvo no banco de dados </param>
    /// <returns> Retorna o objeto salvo no banco de dados com seu "Id" </returns>
    Task<TEntity> CreateAsync(TEntity obj);

    /// <summary>
    /// Deleta o objeto da tabela correspondente no banco de dados
    /// </summary>
    /// <remarks>
    /// Este método é responsável por remover um objeto do banco de dados apóes confirmação do executor
    /// </remarks>
    /// <param name="obj"> O objeto que será removido no banco de dados</param>
    Task DeleteAsync(TEntity obj);

    /// <summary>
    /// Lista todos os objetos da tabela correspondente no banco de dados
    /// </summary>
    /// <remarks>
    /// Este método é responsável por retornar todos os registros encontrado no banco de dados da tabela (entidade) especificada
    /// </remarks>
    /// <returns> Retorna uma coleção de objetos</returns>
    Task<ICollection<TEntity>?> GetAllAsync();

    /// <summary>
    /// Obtém um objeto por "Id"
    /// </summary>
    /// <remarks>
    /// Retorna um objeto por "Id" da tabela correspondente no banco de dados
    /// </remarks>
    /// <param name="id"> O "Id" que será utilizado para buscar o objeto no banco de dados </param>
    /// <returns> Retorna o objeto correspondente ao "Id" passado. </returns>
    Task<TEntity?> GetByIdAsync(int id);

    /// <summary>
    /// Atualiza um objeto na tabela correspondente no banco de dados
    /// </summary>
    /// <remarks>
    /// Este método é responsável por atualizar o "obj" passado por parâmetro na tabela correspondente no banco de dados
    /// </remarks>
    /// <param name="obj"> O objeto que será atualizado no banco de dados </param>
    /// <returns> Retorna o objeto atualizado no banco de dados </returns>
    Task<TEntity> UpdateAsync(TEntity obj);
}