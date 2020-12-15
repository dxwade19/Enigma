﻿using System;
using UnityEngine;


[Serializable]
public struct E_Link
{
    [SerializeField] string entryLetter;
    [SerializeField] string exitLetter;

    public string EntryLetter => entryLetter.ToUpper();
    public string ExitLetter => exitLetter.ToUpper();
}
