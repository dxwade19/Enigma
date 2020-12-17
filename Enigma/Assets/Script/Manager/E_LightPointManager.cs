using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class E_LightPointManager : SingletonTemplate<E_LightPointManager>, IHandler<string, E_LightLetterPoint>
{
    #region F/P

    Dictionary<string, E_LightLetterPoint> handler = new Dictionary<string, E_LightLetterPoint>();
    public Dictionary<string, E_LightLetterPoint> Handler => handler;
    #endregion

    #region Methods

    #region Add/Remove
    public void Add(E_LightLetterPoint _toAdd)
    {
        if(Exist(_toAdd))
        {
            Debug.LogError($"{_toAdd.ID} already exist");
            return;
        }
        _toAdd.name += "[MANAGE]";
        handler.Add(_toAdd.ID, _toAdd);
    }

    public void Remove(E_LightLetterPoint _toRemove)
    {
        if(!Exist(_toRemove))
        {
            Debug.LogError($"{_toRemove.ID} dont exist");
            return;
        }
        handler.Remove(_toRemove.ID);
    }
    public void Remove(string _itemToRemoveID)
    {
        if(!Exist(_itemToRemoveID))
        {
            Debug.LogError($"{_itemToRemoveID} dont exist");
            return;
        }
        handler.Remove(_itemToRemoveID);
    }
    #endregion
    
    #region Enable/Disable
    public void Enable(string _itemID)
    {
        if(!Exist(_itemID)) return;
        handler[_itemID].Enable();
    }
    public void Disable(string _itemID)
    {
        if (!Exist(_itemID))
        {
            Debug.LogError($"{_itemID} dont exist");
            return;
        }
        handler[_itemID].Disable();
    }
    #endregion

    #region Exist
    public bool Exist(string _itemToCheckID) => handler.ContainsKey(_itemToCheckID);
    public bool Exist(E_LightLetterPoint _itemToCheck) => handler.ContainsKey(_itemToCheck.ID);
    #endregion

    #region Get
    public E_LightLetterPoint Get(string _itemID)
    {
        if (!Exist(_itemID)) return null;
        return handler[_itemID];
    }
    #endregion

    #endregion
}
