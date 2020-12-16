using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class E_GameManager : SingletonTemplate<E_GameManager>
{
    [SerializeField, Header("Engine")] E_Engine engine = null;
    E_Engine defaultEngine = null;

    public bool IsValid => engine;

    void Start() => Init();
    void Init()
    {
        defaultEngine = engine;
    }


    public string DecodeLetter(string _textToDecode)
    {
        if (!IsValid) return "";
        _textToDecode = engine.GetLetter(_textToDecode);
        E_LightPointManager.Instance?.Enable(_textToDecode);
        return _textToDecode;
    }

    public void ResetEngine()
    {
        engine = defaultEngine;
        E_UIManager.Instance?.ResetUI();
    }

}
