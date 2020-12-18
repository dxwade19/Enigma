using UnityEngine;



public class E_GameManager : SingletonTemplate<E_GameManager>
{
    #region F/P
    [SerializeField, Header("Engine")] E_Engine engine = null;
    [SerializeField, Header("Main Camera ID")] int mainCamID = 0;
    [SerializeField, Header("Rotor Camera ID")] int rotorCamID = 1;
    int actualCamID = 0;

    public bool IsValid => engine;
    #endregion

    #region Methods

    #region UnityMethods

    void Start()
    {
        actualCamID = rotorCamID;
        SwitchCam();
    }

    #endregion

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
    /// Change Game Camera
    /// </summary>
    public void SwitchCam()
    {
        if (actualCamID == rotorCamID)
        {
            E_CameraManager.Instance?.Enable(mainCamID);
            actualCamID = mainCamID;
        }
        else
        {
            E_CameraManager.Instance?.Enable(rotorCamID);
            actualCamID = rotorCamID;
        }
    }

    /// <summary>
    /// Reset Game Engine and UI
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

    /// <summary>
    /// Change Default Rotation At Pos
    /// </summary>
    /// <param name="_letter"></param>
    /// <param name="_pos"></param>
    public void ChangeBaseRotor(string _letter, int _pos) => engine.ChangeRotorBasePosition(_letter, _pos);

    #endregion
}
