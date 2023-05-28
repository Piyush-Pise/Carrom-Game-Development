using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : BaseStateClass
{
    private NewGameManager gm;
    private Striker striker;
    private CircleCollider2D strikerCollider;
    public ChargeState(NewGameManager gameManager)
    {
        gm = gameManager;
        striker = gameManager.Striker.GetComponent<Striker>();
        strikerCollider = gameManager.Striker.GetComponent<CircleCollider2D>();
    }  
    //private Vector2 direction;
    public override void End()
    {
        Debug.Log("Ending ChargeState");
        striker.DisableTouchAssist();
    }

    public override void Start()
    {
        Debug.Log("Starting ChargeState");
        gm.ArrowAssembly.gameObject.SetActive(true);
        gm.strikerBarSlider.enabled = false;
        gm.ArrowAssembly.position = gm.Striker.position;
    }

    public override void Update()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Moved)
        {
            Vector2 strikerScreenPosition = Camera.main.WorldToScreenPoint(gm.Striker.position);
            gm.direction = strikerScreenPosition - touch.position;
            gm.newScale = gm.direction.magnitude / gm.strechLimitInPixels;
            gm.direction = gm.direction.normalized;
            gm.newScale = Mathf.Clamp(gm.newScale, 0f, 1.25f);
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            if (gm.newScale >= 0.3f)
            {
                gm.SetNewState(gm.FreeState);
            }
            else
            {
                gm.SetNewState(gm.IdleState);
            }
            gm.ArrowAssembly.gameObject.SetActive(false);
        }
        Update_Helper_Arrow_Rotation_And_Scale();
    }

    private void Update_Helper_Arrow_Rotation_And_Scale()
    {
        Vector3 temp = Vector3.one * gm.newScale;
        gm.ArrowAssembly.localScale = Vector3.Lerp(gm.ArrowAssembly.localScale, temp, Time.deltaTime * 20f);

        temp = gm.direction;
        gm.ArrowAssembly.right = Vector3.Lerp(gm.ArrowAssembly.right, temp, Time.deltaTime * 20f);
    }
}
