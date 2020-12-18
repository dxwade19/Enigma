using UnityEngine;
using TMPro;


public class E_UIManager : SingletonTemplate<E_UIManager>
{ 
    #region F/P
    [SerializeField, Header("Input Field :")] TMP_InputField inputField = null;
    [SerializeField, Header("Encoded text :")] TMP_Text Encodedtext = null;
    [SerializeField, Header("Encoded Line Text Size"), Range(5, 30)] int lineRange = 20;
    [SerializeField, Header("Config Text")] TMP_Text configText = null;

    [SerializeField, Header("Default Encoded value :")] string EncodedValue  = "ENCODED : ";
    [SerializeField, Header("Text Before Config :")] string textBeforeConfig = "CONFIG : ";
    string originalValue = "";
    int rotorToChange = 0;

    public bool IsValid => inputField && Encodedtext;
    #endregion

    #region Methods

    #region Unity Methods
    void Start() => originalValue = EncodedValue;
    #endregion

    #region Custom Methods

    #region Change Text
    /// <summary>
    /// Update Encoded Text
    /// </summary>
    public void ChangeUnCodedText()
    {
        if (!IsValid) return;

        string _toDecode = inputField.text.ToUpper();
        inputField.text = "";
        EncodedValue = EncodedValue + E_GameManager.Instance?.GetDecodeLetterWithEngine(_toDecode);
        EncodedValue = EncodedValue.CreatWhitSpace(lineRange);
        Encodedtext.text = EncodedValue;
    }
    

    /// <summary>
    /// Update Config Text
    /// </summary>
    public void ChangeConfigText(string _rotorValue)
    {
        if (!configText) return;
        configText.text = "";
        configText.text = textBeforeConfig + _rotorValue;
    }
    #endregion

    #region Reset

    /// <summary>
    /// Reset UI And Delete Text
    /// </summary>
    public void ResetUI()
    {
        if (!IsValid) return;

        inputField.text = "";
        Encodedtext.text = originalValue;
        EncodedValue = originalValue;
    }
    #endregion
    
    #region Config
    
    /// <summary>
    /// Change Rotor Config of rotor to Change
    /// </summary>
    /// <param name="_inputField"></param>
    public void ChangeConfig(TMP_InputField _inputField)
    {
        string _letter = _inputField.text;
        E_GameManager.Instance?.ChangeBaseRotor(_letter, rotorToChange);
        _inputField.text = _letter.ToUpper();
    }

    /// <summary>
    /// Change Rotor To Change In Change Config
    /// </summary>
    /// <param name="_toChange"></param>
    public void RotorToChange(int _toChange) => rotorToChange = _toChange;
    #endregion

    #endregion

    #endregion

}


/*
    string CreatWhithSpace(string _toClean)
    {
        int _size = 0;
        for (int i = 0; i < _toClean.Length; i++)
        {
            _size++;
            if(_size == range)
            {
                if (_toClean[i] != ' ')
                    _toClean = _toClean.Insert(i, " ");
                _size = 0;
            }
        }
        return _toClean;
    }
    */
