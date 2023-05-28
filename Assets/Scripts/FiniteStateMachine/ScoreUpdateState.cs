using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdateState : BaseStateClass
{
    private NewGameManager gm;
    private Dictionary<string, Vector3> puckPositions = new Dictionary<string, Vector3>();
    private bool StillMyTurn = false;

    public ScoreUpdateState(NewGameManager gameManager)
    {
        gm = gameManager;
        InitializePuckPositions();
    }
    private void InitializePuckPositions()
    {
        puckPositions.Add("Black", gm.blackPuckWorldPos);
        puckPositions.Add("White", gm.whitePuckWorldPos);
        puckPositions.Add("Queen", gm.blackPuckWorldPos);
        puckPositions.Add("Striker", new Vector3(0f, gm.StrikerTransY, 0f));
    }

    public override void End()
    {
        Debug.Log("Ending ScoreUIUpdateState");
        gm.Player1Image.fillAmount = 1f;
        gm.Player2Image.fillAmount = 1f;
        gm.strikerBarSlider.value = 0f;
    }

    public override void Start()
    {
        StillMyTurn = false;
        Debug.Log("Starting ScoreUIUpdateState");
        if (gm.PottedPucks.Count == 0)
        {
            ChangeTheTurn();
        }
        if (gm._foul)
        {
            gm._foul = false;
            StillMyTurn = false;
            return;
        }

        if(gm.turn == Turn.P1)
        {
            foreach (GameObject puck in gm.PottedPucks)
            {
                if(puck.CompareTag("Black") || puck.CompareTag("Queen"))
                {
                    // Keep the turn
                    StillMyTurn = true;
                    return;
                }
            }
            StillMyTurn = false;
        }
        else
        {
            foreach (GameObject puck in gm.PottedPucks)
            {
                if(puck.CompareTag("White") || puck.CompareTag("Queen"))
                {
                    // Keep the turn
                    StillMyTurn = true;
                    return;
                }
            }
            StillMyTurn = false;
        }
    }

    public override void Update()
    {
        if (gm.PottedPucks.Count > 0)
        {
            GameObject puck = gm.PottedPucks[0];
            puck.GetComponent<Pucks>().EnableColor();

            if (puckPositions.TryGetValue(puck.tag, out Vector3 targetPosition))
            {
                
                targetPosition.x *= (puck.CompareTag("Queen") && (gm.turn == Turn.P2)) ?  -1f : 1f;
                targetPosition.y *= (puck.CompareTag("Striker") && (gm.turn == Turn.P1)) ?  -1f : 1f;
                if (Vector3.Distance(targetPosition, puck.transform.position) > 0.005f)
                {
                    puck.transform.position = Vector3.Lerp(puck.transform.position, targetPosition, Time.deltaTime * 10f);
                }
                else
                {
                    RemovePuckAndUpdateUI(puck);
                }
            }
        }
        else
        {
            ChangeTheTurn();
        }
    }

    private void RemovePuckAndUpdateUI(GameObject puck)
    {
        if (puck.tag == "Striker")
        {
            gm.UpdateScoreUI();
            gm.PottedPucks.Remove(puck);
            gm.CarromAI.WhitePucks.Remove(puck.transform);
            return;
        }
        if (puck.tag == "Queen")
        {
            if (gm.turn == Turn.P1) gm.Player1score += 2;
            else gm.Player2score += 2;
        }
        else if(puck.tag == "Black")
        {
            gm.Player1score++;
        }
        else if(puck.tag == "White")
        {
            gm.Player2score++;
        }

        gm.UpdateScoreUI();
        puck.SetActive(false);
        gm.PottedPucks.Remove(puck);
        gm.CarromAI.WhitePucks.Remove(puck.transform);
    }

    private void ChangeTheTurn()
    {
        if(!StillMyTurn)
        {
            gm.turn = (gm.turn == Turn.P1) ? Turn.P2 : Turn.P1;
        }
        gm.SetNewState(gm.turn == Turn.P1 ? gm.IdleState : gm.AIIdleState);
    }
}
