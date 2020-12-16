using UnityEngine;
using TMPro;


public class E_UIManager : SingletonTemplate<E_UIManager>
{ 

    #region F/P
    [SerializeField, Header("Input Field :")] TMP_InputField inputField = null;
    [SerializeField, Header("Encoded text :")] TMP_Text Encodedtext = null;
    [SerializeField, Header("Default Encoded value :")] string defaultEncodedValue  = "ENCODED :";
    #endregion

    #region Methods

    public void ChangeText()
    {
        string _toDecode = inputField.text.ToUpper();
        inputField.text = "";
        defaultEncodedValue = defaultEncodedValue + E_GameManager.Instance?.DecodeLetter(_toDecode);
        Encodedtext.text = defaultEncodedValue;
    }
    //Remake
    public void ResetUI()
    {
        inputField.text = "";
        Debug.Log(Encodedtext.text);                //TODO Remove
        Encodedtext.text = defaultEncodedValue;
    }
    #endregion

}
