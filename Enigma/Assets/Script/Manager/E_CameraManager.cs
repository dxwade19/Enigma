using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class E_CameraManager : SingletonTemplate<E_CameraManager>, IHandler<int, E_CameraBehaviour>
{
    #region F/P
    Dictionary<int, E_CameraBehaviour> handler = new Dictionary<int, E_CameraBehaviour>();
    public Dictionary<int, E_CameraBehaviour> Handler => handler;
    #endregion

    #region Methods

    #region IHandlerItem

    #region Add / Remove

    public void Add(E_CameraBehaviour _toAdd)
    {
        if (Exist(_toAdd)) return;
        handler.Add(_toAdd.ID, _toAdd);
        _toAdd.name += "[MANAGE]";
    }

    public void Remove(E_CameraBehaviour _toRemove)
    {
        if (!Exist(_toRemove)) return;
        handler.Remove(_toRemove.ID);
    }
    public void Remove(int _itemToRemoveID)
    {
        if (!Exist(_itemToRemoveID)) return;
        handler.Remove(_itemToRemoveID);
    }
    #endregion

    #region Enable / Disable

    public void Enable(int _itemID)
    {
        if (!Exist(_itemID)) return;
        DisableAll();
        handler[_itemID].Enable();
    }
    public void Disable(int _itemID)
    {
        if (!Exist(_itemID)) return;
        handler[_itemID].Disable();
    }
    #endregion

    #region Get

    public E_CameraBehaviour Get(int _itemID)
    {
        if (Exist(_itemID)) return handler[_itemID];
        return null;
    }
    #endregion

    #region Exist
    public bool Exist(int _itemToCheckID) => handler.ContainsKey(_itemToCheckID);
    public bool Exist(E_CameraBehaviour _itemToCheck) => handler.ContainsKey(_itemToCheck.ID);
    #endregion

    #endregion

    #region Custom
    public void DisableAll()
    {
        foreach (KeyValuePair<int, E_CameraBehaviour> _item in handler)
            _item.Value.Disable();
    }
    #endregion

    #endregion
}
