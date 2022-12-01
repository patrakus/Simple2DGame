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
        
        float value = squareMinRunAwayDistance - distance;

        if (value <= 0)
        {
            return;
        }

        localTransform.position += directionToNpc.normalized * (speed * Time.deltaTime * value);
    }

    #endregion
}
