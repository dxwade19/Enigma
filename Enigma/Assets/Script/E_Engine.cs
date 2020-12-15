﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class E_Engine : MonoBehaviour
{
    [SerializeField] E_Rotor[] rotors = new E_Rotor[0];


    void Start() => Init();

    void Init()
    {
        GetLetter("A", 0);

    }
    
    string GetLetter(string _letter, int _test)
    {
        if (string.IsNullOrEmpty(_letter)) return null;
        RotateRotor();
        return FindDecodeLetter(_test);
    }

    string FindDecodeLetter(int _pos)
    {
        int _lastPos = _pos;

        for (int i = 0; i < rotors.Length; i++)
            _lastPos = rotors[i].GetLinkPos(_lastPos, true);

        for (int i = rotors.Length - 1; i >= 0; i--)
            _lastPos = rotors[i].GetLinkPos(_lastPos, false);

        return null;
    }

    void RotateRotor()
    {
        if (rotors.Length == 0) return;

        rotors[0].Rotate();
        for (int i = 0; i < rotors.Length; i++)
        {
            if (rotors[i].IsNotch && i != rotors.Length - 1)
                rotors[i + 1].Rotate();
        }
    }
}