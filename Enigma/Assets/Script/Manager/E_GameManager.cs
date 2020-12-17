using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class E_GameManager : SingletonTemplate<E_GameManager>
{
    #region F/P
    [SerializeField, Header("Engine")] E_Engine engine = null;
    [SerializeField, Header("KeyDownClip")] AudioClip clip = null;
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
        AudioSource.PlayClipAtPoint(clip , transform.position);
        return _textToDecode;
    }

    //Remake
    public void ResetGame()
    {
        engine.ResetEngine();
        E_UIManager.Instance?.ResetUI();
    }

    public void ExitGame() => Application.Quit();
    #endregion

    #endregion
}



//TODO ResetEngine
//TODO HDRP


//TODO ListClassExtension
//TODO SoundManager
