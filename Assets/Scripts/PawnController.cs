using System;
using UnityEngine;

public abstract class PawnController : MonoBehaviour
{
    #region MEMBERS
    
    [SerializeField]
    [Min(1f)]
    protected float speed = 5f;

    protected Transform localTransform;
    protected float margin = 0.2f;

    #endregion

    #region PROPERTIES

    public Camera MainCamera { get; set; }

    #endregion

    #region FUNCTIONS

    protected virtual void Start()
    {
        MainCamera = Camera.main;
        localTransform = transform;
    }

    protected virtual void Update()
    {
        ContainToCameraBounds();
    }
    
    private void ContainToCameraBounds()
    {
        Vector3 screenPositionLowerLeftCorner = MainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));
        screenPositionLowerLeftCorner.z = 0;
        Vector3 screenPositionUpperRightCorner = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenPositionUpperRightCorner.z = 0;

        Vector3 newPosition = localTransform.position; 

        if (localTransform.position.x > screenPositionUpperRightCorner.x)
        {
            newPosition.x = localTransform.position.x - (screenPositionUpperRightCorner.x + margin);
        }
        if (localTransform.position.x < screenPositionLowerLeftCorner.x)
        {
            newPosition.x = localTransform.position.x + (screenPositionUpperRightCorner.x - margin);
        }
        
        if (localTransform.position.y > screenPositionUpperRightCorner.y)
        {
            newPosition.y = localTransform.position.y - (screenPositionUpperRightCorner.y + margin);
        }
        if (localTransform.position.y < screenPositionLowerLeftCorner.y)
        {
            newPosition.y = localTransform.position.y + (screenPositionUpperRightCorner.y - margin);
        }
        
        localTransform.position = newPosition;
    }

    #endregion
}