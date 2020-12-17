using UnityEngine;
using TMPro;


public class E_UIManager : SingletonTemplate<E_UIManager>
{ 

    #region F/P
    [SerializeField, Header("Input Field :")] TMP_InputField inputField = null;
    [SerializeField, Header("Encoded text :")] TMP_Text Encodedtext = null;
    [SerializeField, Header("Default Encoded value :")] string EncodedValue  = "ENCODED :";
    string originalValue = "";

    #endregion

    #region Methods

    void Start() => originalValue = EncodedValue;

    /// <summary>
    /// Update Engine Text
    /// </summary>
    public void ChangeText()
    {
        string _toDecode = inputField.text.ToUpper();
        inputField.text = "";
        EncodedValue = EncodedValue + E_GameManager.Instance?.GetDecodeLetterWithEngine(_toDecode);
        Encodedtext.text = EncodedValue;
    }

    /// <summary>
    /// Reset UI And Delete Text
    /// </summary>
    public void ResetUI()
    {
        inputField.text = "";
        Debug.Log(Encodedtext.text);                //TODO Remove
        Encodedtext.text = originalValue;
        EncodedValue = originalValue;
    }
    #endregion

}
