using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class E_LightLetterPoint : MonoBehaviour, IHandlerItem<string>
{
    [SerializeField, Header("Item ID")] string id = "LightPoint";
    [SerializeField, Header("Light Color")] Color lightColor = Color.yellow;
    [SerializeField, Header("Light On Time"), Range(0, 10)] float timeOn = 2;

    public string ID => id.ToUpper();


    void Start() => InitItem();

    public void InitItem()
    {
        E_LightPointManager.Instance?.Add(this);
    }

    public void Enable()
    {
        Light _pointLight = gameObject.AddComponent<Light>();
        _pointLight.type = LightType.Point;
        _pointLight.transform.position = transform.position;
        _pointLight.color = lightColor;
        Destroy(_pointLight, timeOn);
    }

    public void Disable() { }

}
