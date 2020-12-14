using System;
using UnityEngine;


[Serializable]
public struct E_Link
{
    [SerializeField] string firstLetter;
    [SerializeField] string secondLetter;

    public string FirstLetter => firstLetter;
    public string SecondLetter => secondLetter;
}
