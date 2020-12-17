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
        return rotors[rotors.Length - 1].GetExitPos(_newLetter);
    }
    #endregion
    
    /// <summary>
    /// Rotate Rotor In Engine
    /// </summary>
    void RotateRotor()
    {
        if (rotors.Length == 0) return;

        rotors[0].Rotate();
        if (rotors[0].IsNotch)
        {
            rotors[1].Rotate();
            if (rotors[1].IsNotch) rotors[2].Rotate();
        }
    }
    
    /// <summary>
    /// Reset Rotor In Engine
    /// </summary>
    public void ResetEngine()
    {
        for (int i = 0; i < rotors.Length; i++)
            rotors[i].ResetRotor();
    }

    #endregion
}
