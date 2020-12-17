

public interface IHandlerItem<TID>
{
    TID ID { get; }

    /// <summary>
    /// Add Item On Manager
    /// </summary>
    void InitItem();

    /// <summary>
    /// Make An Item Enable
    /// </summary>
    void Enable();

    /// <summary>
    /// Make An Item Disable
    /// </summary>
    void Disable();
}
