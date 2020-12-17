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
    [SerializeField] string BaseRotation = "A";
    [SerializeField] string notche = "";
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
        OnRotateRotor += () => E_SoundManager.Instance?.PlaySoundAtPoint(SoundType.rotateSound, transform.position);
    }
    void Start() => Init();
    void OnDestroy() => OnRotateRotor = null;
    #endregion

    #region customMethods
    void Init()
    {
        for (int i = 0; i < allLink.Count; i++)
            allEntry.Add(allLink[i].EntryLetter);

        allExit = allEntry;
        rotationZ = transform.rotation.z;

        ResetRotor();
    }

    #region GetLinkPos
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
    void UpdateRotorPos()
    {
        allEntry.Rotate<string>();
        allExit = allEntry;
        allLink.Rotate<E_Link>();
    }
    void RotorMoveRotation()
    {
        rotationZ = rotationZ - TurnRotationZ;
        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, rotationZ);
    }
    #endregion

    #region Reset
    public void ResetRotor()
    {
        while (allLink[0].EntryLetter != BaseRotation.ToUpper())
            OnRotateRotor?.Invoke();
    }
    #endregion

    public string GetEntry(int _pos)
    {
        if (_pos > allEntry.Count - 1 || _pos < 0) return "";
        return allEntry[_pos];
    }
    public int GetExitPos(string _letter) => allExit.IndexOf(_letter);
    #endregion

    #endregion
}
