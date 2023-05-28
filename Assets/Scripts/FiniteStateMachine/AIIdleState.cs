using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : BaseStateClass
{
    private NewGameManager gm;
    private Striker striker;
    private CircleCollider2D strikerCollider;
    private bool HasStrikerMovedToCentre = false;

    public AIIdleState(NewGameManager gameManager)
    {
        gm = gameManager;
        striker = gameManager.Striker.GetComponent<Striker>();
        strikerCollider = gameManager.Striker.GetComponent<CircleCollider2D>();
    }  
    public override void End()
    {
        Debug.Log("Ending AIIdleState");
    }

    public override void Start()
    {
        HasStrikerMovedToCentre = false;
        Debug.Log("Starting AIIdleState");
        gm.StartCountDown();
        striker.EnableRenderer();
        strikerCollider.enabled = true;
        strikerCollider.isTrigger = true;
        gm.ArrowAssembly.gameObject.SetActive(false);
        gm.PottedPucks.Clear();
        gm.CarromAI.CalculatePossiblePosition();
    }

    public override void Update()
    {
        if (!HasStrikerMovedToCentre)
        {
            MoveStrikerToCentre();
        }
        else
        {
            MoveStrikerToTargetedPosition();
        }
    }

private void MoveStrikerToCentre()
{
    Vector3 targetPosition = new Vector3(0f, -gm.StrikerTransY, 0f);
    if (Vector3.Distance(gm.Striker.position, targetPosition) > 0.01f)
    {
        SmoothlyMoveStriker(targetPosition);
    }
    else
    {
        HasStrikerMovedToCentre = true;
    }
}

    private void MoveStrikerToTargetedPosition()
    {
        if (Vector3.Distance(gm.Striker.position, gm.CarromAI._AIStrikerPosition) > 0.01f)
        {
            SmoothlyMoveStriker(gm.CarromAI._AIStrikerPosition);
        }
        else
        {
            gm.SetNewState(gm.AIChargeState);   
        }
    }

    private void SmoothlyMoveStriker(Vector3 targetPosition)
    {
        gm.Striker.position = Vector3.Lerp(gm.Striker.position, targetPosition, Time.deltaTime * 8f);
    }
}

