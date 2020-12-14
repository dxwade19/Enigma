using System.Collections.Generic;
using UnityEngine;


public class E_Rotor : MonoBehaviour
{
    #region F:P
    [SerializeField] List<E_Link> allLink = new List<E_Link>();
    [SerializeField] string notche = "";

    List<string> allEntry = new List<string>();
    List<string> allExit = new List<string>();
    #endregion

    #region Methods

    void Start() => Init();

    #region customMethods
    void Init()
    {
        for (int i = 0; i < allLink.Count; i++)
            allEntry.Add(allLink[i].FirstLetter);

        allExit = allEntry;
    }

    /// <summary>
    /// GetNextPos
    /// </summary>
    /// <param name="_pos"></param>
    /// <returns></returns>
    public int GetLinkPos(int _pos)
    {
        string _letter = allEntry[_pos];
        string exitLetter = allLink[allEntry.IndexOf(_letter)].SecondLetter;
        return allExit.IndexOf(exitLetter);
    }

    /// <summary>
    /// Rotate Rotor pos
    /// </summary>
    public void Rotate()
    {
        RotateList(allEntry);
        RotateList(allExit);
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
    #endregion

    #endregion
}
