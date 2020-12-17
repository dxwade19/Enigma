using UnityEngine;



public class E_GameManager : SingletonTemplate<E_GameManager>
{
    #region F/P
    [SerializeField, Header("Engine")] E_Engine engine = null;

    public bool IsValid => engine;
    #endregion

    #region Methods

    #region CustomMethods

    /// <summary>
    /// Give Decoded Letter With Engine
    /// </summary>
    /// <param name="_letterToDecode"></param>
    /// <returns></returns>
    public string GetDecodeLetterWithEngine(string _letterToDecode)
    {
        if (!IsValid) return "";

        E_SoundManager.Instance?.PlaySoundAtPosition(SoundType.KeyDown, transform.position);
        _letterToDecode = engine.GetDocodeLetter(_letterToDecode);
        E_LightPointManager.Instance?.Enable(_letterToDecode);

        return _letterToDecode;
    }
    

    /// <summary>
    /// Reset Game Engine
    /// </summary>
    public void ResetGame()
    {
        engine.ResetEngine();
        E_UIManager.Instance?.ResetUI();
    }

    /// <summary>
    /// Quit Game
    /// </summary>
    public void ExitGame() => Application.Quit();
    #endregion

    #endregion
}
