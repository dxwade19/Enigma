using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class E_LightLetterPoint : MonoBehaviour, IHandlerItem<string>
{
    #region F/P
    [SerializeField, Header("Item ID")] string id = "LightPoint";
    [SerializeField, Header("Light Color")] Color lightColor = Color.yellow;
    [SerializeField, Header("Light Intensity")] float intensity = 60000;
    [SerializeField, Header("Light On Time"), Range(0, 10)] float timeOn = 2;
    Light light = null;

    public string ID => id.ToUpper();

    public Vector3 Position => transform.position;
    #endregion

    #region Methods

    #region Unity Methods
    void Start() => InitItem();
    #endregion

    #region IHandlerItem*
    public void InitItem() => E_LightPointManager.Instance?.Add(this);

    public void Enable()
    {
        if (!light)
            light = gameObject.AddComponent<Light>();
        
        light.type = LightType.Point;
        light.intensity = intensity;
        light.transform.position = transform.position;
        light.color = lightColor;
        Destroy(light, timeOn);
        
    }

    public void Disable()
    {
        if (light)
            Destroy(light);
    }
    #endregion

    #endregion
}
