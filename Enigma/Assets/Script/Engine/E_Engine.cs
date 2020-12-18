using System.Collections.Generic;
using UnityEngine;


public class E_Engine : MonoBehaviour
{
    #region F/P
    [SerializeField] E_Rotor[] rotors = new E_Rotor[0];
    [SerializeField] E_Reflector reflector = null;
    [SerializeField] List<string> alphabeter = new List<string>();

    public bool IsValid => rotors.Length > 0 && reflector;
    #endregion

    #region Methods

    #region Unity Methods
    void Start() => ChangeConfigTextUI();
    #endregion

    #region Custom Methods

    #region Decode

    /// <summary>
    /// Get Letter After Decode
    /// </summary>
    /// <param name="_letter"></param>
    /// <returns></returns>
    public string GetDocodeLetter(string _letter)
    {
        if (!IsValid || !alphabeter.Contains(_letter)) return "";

        RotateRotor();
        int _letterIndex = alphabeter.IndexOf(_letter);
        return FindDecodeLetter(_letterIndex);
    }

    /// <summary>
    /// Decrypt Letter At Letter Position In Alphabeter
    /// </summary>
    /// <param name="_letterPos"></param>
    /// <returns></returns>
    string FindDecodeLetter(int _letterPos)
    {
        for (int i = 0; i < rotors.Length; i++)
            _letterPos = rotors[i].GetLinkPos(_letterPos, true);

        _letterPos = GetReflectPos(_letterPos);

        for (int i = rotors.Length - 1; i >= 0; i--)
            _letterPos = rotors[i].GetLinkPos(_letterPos, false);

        return alphabeter[_letterPos];
    }

    /// <summary>
    /// Get Letter Position After Reflector
    /// </summary>
    /// <param name="_lastPos"></param>
    /// <returns></returns>
    int GetReflectPos(int _lastPos)
    {
        string _newLetter = reflector.GetReflectCharacter(rotors[rotors.Length - 1].GetEntryCharacter(_lastPos));
        int _letterPos = alphabeter.IndexOf(_newLetter);
        string _letterfinal = rotors[rotors.Length - 1].GetExitCharacter(_letterPos);
        return rotors[rotors.Length-1].GetExitPos(_letterfinal);
    }
    #endregion

    #region Rotate Engine Rotor

    /// <summary>
    /// Rotate Rotor In Engine
    /// </summary>
    void RotateRotor()
    {
        if (!IsValid && rotors.Length == 3) return;

        rotors[0].Rotate();
        if (rotors[0].IsNotch)
        {
            rotors[1].Rotate();
            if (rotors[1].IsNotch) rotors[2].Rotate();
        }
        ChangeConfigTextUI();
    }
    #endregion

    #region Reset

    /// <summary>
    /// Reset Rotor In Engine
    /// </summary>
    public void ResetEngine()
    {
        for (int i = 0; i < rotors.Length; i++)
            rotors[i].ResetRotor();
    }

    /// <summary>
    /// Change Base Position Of Rotor Pos
    /// </summary>
    /// <param name="_newRotorPos"></param>
    /// <param name="_rotorPosition"></param>
    public void ChangeRotorBasePosition(string _newRotorPos, int _rotorPosition)
    {
        if (_rotorPosition > rotors.Length - 1 || _rotorPosition < 0) return;
        rotors[_rotorPosition].ChangeBasePosition(_newRotorPos);
        ChangeConfigTextUI();
    }
    #endregion

    #region Change Text

    /// <summary>
    /// Change Config Text In UI
    /// </summary>
    void ChangeConfigTextUI()
    {
        string _newConfigText = "";

        for (int i = 0; i < rotors.Length; i++)
            _newConfigText = _newConfigText + $"{rotors[i].GetEntryCharacter(0)} ";

        E_UIManager.Instance?.ChangeConfigText(_newConfigText);
    }
    #endregion

    #endregion

    #endregion
}
