namespace Core.Entities;

/// <summary> Classe responsável por gerar as chaves primárias  e fornecer os métodos
///           gerais para as entidades que a herdarem. </summary>
public abstract class PK
{
    #region Constuctors

    /// <summary> Fornece a chave primária para a entidade. </summary>
    public PK(int id = -1)
    {
        Id = id;
    }

    #endregion

    #region Properties

    public int Id { get; init; }
    public DateTime CreatedDate { get; private set; } = DateTime.Now;

    #endregion

    #region Methods

    /// <summary> Altera o status da entidade. </summary>
    /// <remarks> O parâmentro "option" carrega "true" por padrão, sendo este parametro opcional caso esta seja a opção escolhida.
    ///           Para inativar a entidade basta passar "false" como parâmetro do método. </remarks>
    /// <param name="option"> Parametro opcional com valor padrão "true". </param>
    public virtual void ObjectActivated(bool option = true) { }

    #endregion
}
