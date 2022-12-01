using UnityEngine;

public class PlayerController : PawnController
{
    #region MEMBERS

    private Collider2D[] collider2Ds = new Collider2D[16];
    
    #endregion

    #region PROPERTIES

    public Camera MainCamera { get; set; }

    #endregion

    #region FUNCTIONS

    protected override void Start()
    {
        base.Start();
        localTransform = transform;
    }

    protected override void Update()
    {
        ProcessInput(GetInput());
        CatchNpc();
        
        base.Update();
    }

    private void CatchNpc()
    {
        float size = 0.08f;
        Vector2 position2D = new Vector2(localTransform.position.x, localTransform.position.y);
        int resultsCount = Physics2D.OverlapCircleNonAlloc(position2D, size, collider2Ds);

        if (resultsCount == 0)
        {
            return;
        }

        for (int i = 0; i < resultsCount; i++)
        {
            collider2Ds[i].gameObject.GetComponent<NPCController>().StopMovement();
        }
    }

    private void ProcessInput(Vector3 moveVector)
    {
        localTransform.position += moveVector.normalized * (speed * Time.deltaTime);
    }

    private Vector3 GetInput()
    {
        Vector3 moveInput = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            moveInput.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput.x = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveInput.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveInput.y = -1;
        }
        
        return moveInput; 
    }

    #endregion
}
