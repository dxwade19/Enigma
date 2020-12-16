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
        string _decodedText = E_GameManager.Instance?.DecodeText(_toDecode);
        Encodedtext.text = defaultEncodedValue + _decodedText;
    }

    public void ResetUI()
    {
        inputField.text = "";
        Encodedtext.text = defaultEncodedValue;
    }

}
