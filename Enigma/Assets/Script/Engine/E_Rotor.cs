using System.Collections.Generic;
using UnityEngine;
using System;

public class E_Rotor : MonoBehaviour
{
    #region Action
    public event Action OnRotateRotor = null;
    #endregion

    #region F/P
    [SerializeField, Header("Rotor Link")] List<E_Link> allLink = new List<E_Link>();
    [SerializeField, Header("Rotor Begin Position")] string BasePosition = "A";
    [SerializeField, Header("Notch Letter")] string notche = "";
    [SerializeField, Header("Turn Rotation Movement") ,Range(5, 15)] float TurnRotationZ = 14;

    List<string> allEntry = new List<string>();
    List<string> allExit = new List<string>();
    float rotationZ = 0;

    bool IsValid => allEntry.Contains(BasePosition);
    public bool IsNotch => allEntry[0] == notche;
    #endregion

    #region Methods

    #region UnityMethods
    void Awake()
    {
        OnRotateRotor += UpdateRotorList;
        OnRotateRotor += RotorMoveRotation;
        OnRotateRotor += () => E_SoundManager.Instance?.PlaySoundAtPosition(SoundType.rotateSound, transform.position);
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

    /// <summary>
    /// Get Position Link To Enter Position
    /// </summary>
    /// <param name="_enterPos"></param>
    /// <param name="_isEntryLetter"></param>
    /// <returns></returns>
    public int GetLinkPos(int _enterPos, bool _isEntryLetter)
    {
        if(_isEntryLetter)
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

    /// <summary>
    /// Get Link Position Of This Exit Letter
    /// </summary>
    /// <param name="_letter"></param>
    /// <returns></returns>
    int GetLinkExit(string _letter)
    {
        for (int i = 0; i < allLink.Count; i++)
            if (allLink[i].ExitLetter == _letter) return i;

        return -1;
    }
    #endregion

    #region Rotate

    /// <summary>
    /// Call Action On Rotation
    /// </summary>
    public void Rotate() => OnRotateRotor?.Invoke();

    /// <summary>
    /// Update List When OnRotation is Invoke
    /// </summary>
    void UpdateRotorList()
    {
        allEntry.Rotate();
        allExit = allEntry;
        allLink.Rotate();
    }

    /// <summary>
    /// Update Rotor Rotation In Space When Rotation Is Invoke
    /// </summary>
    void RotorMoveRotation()
    {
        rotationZ = rotationZ - TurnRotationZ;
        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, rotationZ);
    }
    #endregion

    #region Reset

    /// <summary>
    /// Reset Rotor To Base Position
    /// </summary>
    public void ResetRotor()
    {
        if (!IsValid) return;

        while (allLink[0].EntryLetter != BasePosition.ToUpper())
            OnRotateRotor?.Invoke();
    }
    #endregion

    #region GetEntry / Exit

    /// <summary>
    /// Get Entry Character At Position
    /// </summary>
    /// <param name="_pos"></param>
    /// <returns></returns>
    public string GetEntryCharacter(int _pos)
    {
        if (_pos > allEntry.Count - 1 || _pos < 0) return "";
        return allEntry[_pos];
    }

    /// <summary>
    /// Get Exit Position Of a letter
    /// </summary>
    /// <param name="_letter"></param>
    /// <returns></returns>
    public int GetExitPos(string _letter) => allExit.IndexOf(_letter);
    #endregion

    #endregion

    #endregion
}
