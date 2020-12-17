using System.Collections.Generic;
using UnityEngine;


public class E_Reflector : MonoBehaviour
{
    [SerializeField] List<E_Link> links = new List<E_Link>();

    public string GetReflectPos(string _letter)
    {
        for (int i = 0; i < links.Count; i++)
        {
            E_Link link = links[i];

            if (link.EntryLetter == _letter) return link.ExitLetter;
            else if (link.ExitLetter == _letter) return link.EntryLetter;
        }
        return "";
    }
}
