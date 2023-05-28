using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndState : BaseStateClass
{
    private NewGameManager gm;
    public GameEndState(NewGameManager gameManager)
    {
        gm = gameManager;
    } 
    public override void End()
    {
        Debug.Log("Game Ended");
    }
    public override void Start()
    {
        Debug.Log("Game Ended State started");
        gm.StopAllCoroutines();
        gm.strikerBarSlider.enabled = false;
        gm.strikerBarSlider.GetComponent<StrikerBarVisuals>().DisableStrikerBar();
        gm.GameOverAnimator.SetBool("IsGameOver",true);
        gm.Invoke("SetTimeScaleToZero", 1f);
    }

    public override void Update()
    {
        return;
    }
}