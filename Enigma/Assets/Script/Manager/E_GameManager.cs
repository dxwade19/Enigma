using UnityEngine;



public class E_GameManager : SingletonTemplate<E_GameManager>
{
    #region F/P
    [SerializeField, Header("Engine")] E_Engine engine = null;

    public bool IsValid => engine;
    #endregion

    #region Methods

    #region CustomMethods
    public string GetDecodeLetter(string _letterToDecode)
    {
        if (!IsValid) return "";

        E_SoundManager.Instance?.PlaySoundAtPoint(SoundType.KeyDown, transform.position);
        _letterToDecode = engine.GetDocodeLetter(_letterToDecode);
        E_LightPointManager.Instance?.Enable(_letterToDecode);

        return _letterToDecode;
    }
    
    public void ResetGame()
    {
        engine.ResetEngine();
        E_UIManager.Instance?.ResetUI();
    }

    public void ExitGame() => Application.Quit();
    #endregion

    #endregion
}



//TODO RemakeResetEngine

//TODO ListClassExtension
