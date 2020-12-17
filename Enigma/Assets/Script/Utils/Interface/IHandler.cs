using System.Collections.Generic;



public interface IHandler<TID, TItem>  where TItem : IHandlerItem<TID>
{
    Dictionary<TID, TItem> Handler { get; }

    /// <summary>
    /// Add Item To Handler
    /// </summary>
    /// <param name="_toAdd"></param>
    void Add(TItem _toAdd);

    /// <summary>
    /// Remove Item From Handler
    /// </summary>
    /// <param name="_toRemove"></param>
    void Remove(TItem _toRemove);
    /// <summary>
    /// Remove Item From Handler
    /// </summary>
    /// <param name="_itemToRemoveID"></param>
    void Remove(TID _itemToRemoveID);

    /// <summary>
    /// Get Item With Is ID
    /// </summary>
    /// <param name="_itemID"></param>
    /// <returns></returns>
    TItem Get(TID _itemID);

    /// <summary>
    /// Check If Item Exist
    /// </summary>
    /// <param name="_itemToCheckID"></param>
    /// <returns></returns>
    bool Exist(TID _itemToCheckID);
    /// <summary>
    /// Check If Item Exist
    /// </summary>
    /// <param name="_itemToCheck"></param>
    /// <returns></returns>
    bool Exist(TItem _itemToCheck);

    /// <summary>
    /// Make An Item Enable
    /// </summary>
    /// <param name="_itemID"></param>
    void Enable(TID _itemID);
    /// <summary>
    /// Make An Item Disable
    /// </summary>
    /// <param name="_itemID"></param>
    void Disable(TID _itemID);

}
