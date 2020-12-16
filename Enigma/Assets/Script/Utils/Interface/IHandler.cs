using System.Collections.Generic;



public interface IHandler<TID, TItem>  where TItem : IHandlerItem<TID>
{
    Dictionary<TID, TItem> Handler { get; }

    void Add(TItem _toAdd);
    void Remove(TItem _toRemove);
    void Remove(TID _itemToRemoveID);

    TItem Get(TID _itemID);

    bool Exist(TID _itemToCheckID);
    bool Exist(TItem _itemToCheck);

    void Enable(TID _itemID);
    void Disable(TID _itemID);
}
