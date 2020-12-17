using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class E_Engine : MonoBehaviour
{
    [SerializeField] E_Rotor[] rotors = new E_Rotor[0];
    [SerializeField] E_Reflector reflector = null;
    [SerializeField] List<string> alphabeter = new List<string>();

    public bool IsValid => rotors.Length > 0;

    #region Decode
    public string GetLetter(string _letter)
    {
        if (string.IsNullOrEmpty(_letter) || !IsValid) return "";
        RotateRotor();
        int _letterIndex = alphabeter.IndexOf(_letter);
        return FindDecodeLetter(_letterIndex);
    }
    string FindDecodeLetter(int _letterPos)
    {
        for (int i = 0; i < rotors.Length; i++)
            _letterPos = rotors[i].GetLinkPos(_letterPos, true);

        _letterPos = GetReflectPos(_letterPos);

        for (int i = rotors.Length - 1; i >= 0; i--)
            _letterPos = rotors[i].GetLinkPos(_letterPos, false);

        return alphabeter[_letterPos];
    }
    int GetReflectPos(int _lastPos)
    {
        string _newLetter = reflector.GetPos(rotors[rotors.Length - 1].GetEntry(_lastPos));
        _lastPos = rotors[rotors.Length - 1].GetExitPos(_newLetter);
        return _lastPos;
    }
    #endregion
    
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


    public void ResetEngine()
    {

    }

}

/*
if (rotors[i].IsNotch && i != rotors.Length - 1)
            {
                rotors[i + 1].Rotate();
            }
*/
