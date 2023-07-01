namespace HR.Domain.Common;

/// <summary>
/// The Base Type that represents an Entity with Identifier of type <typeparamref name="T"/>
/// </summary>
/// <typeparam name="T">Data type of Identifier</typeparam>
public abstract class BaseEntity<T>
{
    public T ID { get; set; } = default!;
}
