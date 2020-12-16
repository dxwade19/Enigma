using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class E_GameManager : SingletonTemplate<E_GameManager>
{
    #region F/P
    [SerializeField, Header("Engine")] E_Engine engine = null;
    E_Engine defaultEngine = null;

    public bool IsValid => engine;
    #endregion

    #region Methods

    void Start() => Init();

    #region CustomMethods
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

    //Remake
    public void ResetEngine()
    {
        engine = defaultEngine;
        E_UIManager.Instance?.ResetUI();
    }

    #endregion

    #endregion
}


//TODO Sound
//TODO Rotate
//TODO HDRP

//TODO CorLetterAfterRotate
//TODO ListClassExtension

//TODO Event KeyPressed
