﻿using System.Collections.Generic;
using UnityEngine;


public class E_Rotor : MonoBehaviour
{
    #region F:P
    [SerializeField] List<E_Link> allLink = new List<E_Link>();
    [SerializeField] string notche = "";

    List<string> allEntry = new List<string>();
    List<string> allExit = new List<string>();

    public bool IsNotch => allEntry[0] == notche;
    #endregion


    #region Methods

    void Awake() => Init();

    #region customMethods
    void Init()
    {
        for (int i = 0; i < allLink.Count; i++)
            allEntry.Add(allLink[i].EntryLetter);

        allExit = allEntry;
    }

    /// <summary>
    /// Get Exit Pos
    /// </summary>
    /// <param name="_enterPos"></param>
    /// <returns></returns>
    public int GetLinkPos(int _enterPos, bool _isEnter)
    {
        if(_isEnter)
        {
            string _letter = allEntry[_enterPos];
            string _exitLetter = allLink[allEntry.IndexOf(_letter)].ExitLetter;
            Debug.Log($"{allEntry[_enterPos]} - {allExit[allExit.IndexOf(_exitLetter)]}");
            return allExit.IndexOf(_exitLetter);
        }
        else
        {
            string _letter = allLink[_enterPos].ExitLetter;
            string _enterLetter = allLink[allExit.IndexOf(_letter)].EntryLetter;
            Debug.Log($"{allExit[_enterPos]} - {allEntry[allEntry.IndexOf(_enterLetter)]}");
            return allEntry.IndexOf(_enterLetter);
        }
    }


    #region Rotate

    /// <summary>
    /// Rotate Rotor pos
    /// </summary>
    public void Rotate()
    {
        RotateList(allEntry);
        allExit = allEntry;
        RotateList(allLink);
    }
    void RotateList(List<string> _toRotate)
    {
        if (_toRotate.Count == 0) return;

        string _first = _toRotate[0];
        for (int i = 0; i < _toRotate.Count; i++)
        {
            if (i != _toRotate.Count -1)
                _toRotate[i] = _toRotate[i + 1];
                
        }
        _toRotate[_toRotate.Count - 1] = _first;
    }
    //TOREMOVE
    void RotateList(List<E_Link> _toRotate)
    {
        if (_toRotate.Count == 0) return;

        E_Link _first = _toRotate[0];
        for (int i = 0; i < _toRotate.Count; i++)
        {
            if (i != _toRotate.Count - 1)
                _toRotate[i] = _toRotate[i + 1];

        }
        _toRotate[_toRotate.Count - 1] = _first;
    }

    #endregion

    #endregion


    #endregion
}

//TODO ListClassExtension