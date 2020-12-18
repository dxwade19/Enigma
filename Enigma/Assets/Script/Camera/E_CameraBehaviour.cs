using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class E_CameraBehaviour : MonoBehaviour, IHandlerItem<int>
{
    #region F/P
    [SerializeField, Header("Camera ID")] int id = 0;
    [SerializeField, Header("Camera Component")] Camera camComponent = null;
    
    public int ID => id;
    public bool IsValid => camComponent;
    #endregion

    #region Methods

    #region Unity Methods
    void Awake() => InitItem();
    #endregion


    #region CustomMethods

    #region Init
    public void InitItem()
    {
        if (!camComponent)
            camComponent = gameObject.GetComponent<Camera>();

        E_CameraManager.Instance?.Add(this);
    }
    #endregion

    #region Enable/Disable

    public void Enable()
    {
        if (!IsValid) return;
        camComponent.enabled = true;
    }
    public void Disable()
    {
        if (!IsValid) return;
        camComponent.enabled = false;
    }
    #endregion

    #endregion

    #endregion
}
