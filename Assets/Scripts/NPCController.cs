using UnityEngine;

public class NPCController : PawnController
{
    #region MEMBERS

    [SerializeField]
    [Min(1f)]
    private float minRunAwayDistance = 1f;

    private float squareMinRunAwayDistance;
    private bool isAbleToMove = true;
    

    #endregion

    #region PROPERTIES

    public Transform PlayerTransform { get; set; }

    #endregion

    #region FUNCTIONS

    public void StopMovement()
    {
        isAbleToMove = false;
        Debug.Log("It Works!");
    }

    protected override void Start()
    {
        base.Start();
        squareMinRunAwayDistance = minRunAwayDistance * minRunAwayDistance;
    }

    protected override void Update()
    {
        if (isAbleToMove == false)
        {
            return;
        }
        
        RunAwayFromPlayer();
        
        base.Update();
    }

    private void RunAwayFromPlayer()
    {
        Vector3 directionToNpc = PlayerTransform.position.GetDirectionTo(localTransform.position);
        
        float distance = directionToNpc.sqrMagnitude;

        if (distance > squareMinRunAwayDistance)
        {
            return;
        }

        float facingValue = Vector3.Dot(directionToNpc.normalized, PlayerTransform.forward);

        if (facingValue <= 0)
        {
            return;
        }

        localTransform.position += directionToNpc.normalized * (speed * Time.deltaTime * facingValue);
        localTransform.forward = directionToNpc.normalized;
    }

    #endregion
}
