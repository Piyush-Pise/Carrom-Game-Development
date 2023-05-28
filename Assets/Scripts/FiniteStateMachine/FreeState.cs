using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeState : BaseStateClass
{
    private NewGameManager gm;
    public FreeState(NewGameManager gameManager)
    {
        gm = gameManager;
    } 
    public override void End()
    {
        Debug.Log("Ending FreeState");
    }
    public override void Start()
    {
        gm.StopCountDown();
        Debug.Log("Starting FreeState");
        gm.Striker.GetComponent<CircleCollider2D>().isTrigger = false;
        gm.StrikerRB.AddForce(gm.direction * gm.newScale * gm.val, ForceMode2D.Impulse);
        gm.newScale = 0f;
    }

    public override void Update()
    {
        bool flag = false;
        foreach (Transform tr in gm.Pucks)
        {
            if(tr.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
            {
                flag = true;
                break;
            }
        }
        if(!flag)
        {
            gm.SetNewState(gm.ScoreUpdateState);
        }
    }
}