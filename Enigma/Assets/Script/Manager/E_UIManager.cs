using UnityEngine;
using TMPro;


public class E_UIManager : SingletonTemplate<E_UIManager>
{
    [SerializeField, Header("Input Field :")] TMP_InputField inputField = null;
    [SerializeField, Header("Encoded text :")] TMP_Text Encodedtext = null;
    [SerializeField, Header("Default Encoded value :")] string defaultEncodedValue  = "ENCODED :";

    public void ChangeText()
    {
        string _toDecode = inputField.text.ToUpper();
        defaultEncodedValue = defaultEncodedValue + E_GameManager.Instance?.DecodeLetter(_toDecode);
        Encodedtext.text = defaultEncodedValue;
        inputField.text = "";
    }

    public void ResetUI()
    {
        inputField.text = "";
        Encodedtext.text = "ENCODED :";
    }

}
