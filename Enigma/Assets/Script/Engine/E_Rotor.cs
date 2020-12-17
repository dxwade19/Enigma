using System.Collections.Generic;
using UnityEngine;
using System;

public class E_Rotor : MonoBehaviour
{
    #region Action
    public event Action OnRotateRotor = null;
    #endregion

    #region F/P
    [SerializeField] List<E_Link> allLink = new List<E_Link>();
    [SerializeField] string notche = "";
    [SerializeField] AudioClip rotateSound = null;
    [SerializeField, Range(5, 15)] float TurnRotationZ = 14;

    List<string> allEntry = new List<string>();
    List<string> allExit = new List<string>();
    float rotationZ = 0;

    public bool IsNotch => allEntry[0] == notche;
    #endregion

    #region Methods

    #region UnityMethods
    void Awake()
    {
        OnRotateRotor += UpdateRotorPos;
        OnRotateRotor += RotorMoveRotation;
        OnRotateRotor += PlaySound;
    }
    void Start() => Init();
    private void OnDestroy() => OnRotateRotor = null;
    #endregion

    #region customMethods
    void Init()
    {
        for (int i = 0; i < allLink.Count; i++)
            allEntry.Add(allLink[i].EntryLetter);

        allExit = allEntry;
        rotationZ = transform.rotation.z;
    }

    #region GetLinkPos
    /// <summary>
    /// Get Link Pos
    /// </summary>
    /// <param name="_enterPos"></param>
    /// <param name="_isEnter"></param>
    /// <returns></returns>
    public int GetLinkPos(int _enterPos, bool _isEnter)
    {
        if(_isEnter)
        {
            string _letter = allEntry[_enterPos];
            string _exitLetter = allLink[allEntry.IndexOf(_letter)].ExitLetter;
            return allExit.IndexOf(_exitLetter);
        }
        else
        {
            string _letter = allExit[_enterPos];
            int _linkPos = GetLinkExit(_letter);
            string _entryLetter = allLink[_linkPos].EntryLetter;
            return allEntry.IndexOf(_entryLetter);
        }
    }
    int GetLinkExit(string _letter)
    {
        for (int i = 0; i < allLink.Count; i++)
            if (allLink[i].ExitLetter == _letter) return i;

        return -1;
    }
    #endregion

    #region Rotate
    public void Rotate() => OnRotateRotor?.Invoke();

    /// <summary>
    /// Rotate Rotor pos
    /// </summary>
    void UpdateRotorPos()
    {
        RotateList(allEntry);
        allExit = allEntry;
        RotateList(allLink);
    }
    void RotorMoveRotation()
    {
        rotationZ = rotationZ - TurnRotationZ;
        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, rotationZ);
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



    public string GetEntry(int _pos)
    {
        if (_pos > allEntry.Count - 1 || _pos < 0) return "";
        return allEntry[_pos];
    }
    public int GetExitPos(string _letter) => allExit.IndexOf(_letter);

    void PlaySound()
    {
        if (rotateSound) AudioSource.PlayClipAtPoint(rotateSound, transform.position);
    }
    #endregion

    #endregion
}



//TODO ListClassExtension
//TODO RemoveRotateList
