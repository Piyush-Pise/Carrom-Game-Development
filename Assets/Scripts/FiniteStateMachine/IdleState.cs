using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdleState : BaseStateClass
{
    private NewGameManager gm;
    private Striker striker;
    private CircleCollider2D strikerCollider;
    private StrikerBarVisuals strikerBarVisuals;
    private Slider StrikerBar;

    public IdleState(NewGameManager gameManager)
    {
        gm = gameManager;
        striker = gameManager.Striker.GetComponent<Striker>();
        strikerCollider = gameManager.Striker.GetComponent<CircleCollider2D>();
        strikerBarVisuals = gameManager.strikerBarSlider.GetComponent<StrikerBarVisuals>();
        StrikerBar = gameManager.strikerBarSlider;
    }   
    public override void End()
    {
        Debug.Log("Ending IdleState");
        gm.strikerBarSlider.enabled = false;
        strikerBarVisuals.DisableStrikerBar();
    }

    public override void Start()
    {
        Debug.Log("Starting IdleState");
        gm.StartCountDown();
        striker.EnableTouchAssist();
        gm.strikerBarSlider.enabled = true;
        strikerBarVisuals.EnableStrikerBar();
        strikerCollider.enabled = true;
        strikerCollider.isTrigger = true;
        gm.ArrowAssembly.gameObject.SetActive(false);
        gm.PottedPucks.Clear();
    }

    public override void Update()
    {
        SmoothlyMoveStriker();

        if (CanTakeShot() && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                Collider2D collider = Physics2D.OverlapPoint(touchPosition);

                if (collider != null && collider.name == "TouchAssistTrigger")
                {
                    gm.SetNewState(gm.ChargeState);
                }
            }
        }
    }

    private void SmoothlyMoveStriker()
    {
        Vector3 targetPosition = new Vector3(GetNewX(), gm.StrikerTransY, 0f);
        gm.Striker.position = Vector3.Lerp(gm.Striker.position, targetPosition, Time.deltaTime * 15f);
    }
    public float GetNewX()
    {
        // Linear Interpolation for determine the strikers position
        return ((gm.StrikerMovRangeX.y - gm.StrikerMovRangeX.x) / 2f)*(StrikerBar.value + 1) + gm.StrikerMovRangeX.x;
    }

    private bool CanTakeShot()
    {
        bool canTakeShot = !strikerCollider.IsTouchingLayers(LayerMask.GetMask("Puck"));

        if (canTakeShot)
        {
            striker.CanTakeShot();
        }
        else
        {
            striker.CanNotTakeShot();
        }

        return canTakeShot;
    }
}
