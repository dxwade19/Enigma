

public interface IHandlerItem<TID>
{
    TID ID { get; }

    void InitItem();

    void Enable();
    void Disable();
}
