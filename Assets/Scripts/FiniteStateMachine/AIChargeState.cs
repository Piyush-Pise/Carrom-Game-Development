using UnityEngine;

public class AIChargeState : BaseStateClass
{
    private NewGameManager gm;
    private Striker striker;

    public AIChargeState(NewGameManager gameManager)
    {
        gm = gameManager;
        striker = gameManager.Striker.GetComponent<Striker>();
    }

    public override void End()
    {
        Debug.Log("Ending AIChargeState");
        gm.ArrowAssembly.gameObject.SetActive(false);
        striker.DisableRenderer();
    }

    public override void Start()
    {
        Debug.Log("Starting AI ChargeState");
        gm.ArrowAssembly.gameObject.SetActive(true);
        gm.ArrowAssembly.position = gm.Striker.position;
        gm.direction = gm.CarromAI._AIStrikerDirection;
        gm.newScale = gm.CarromAI._AINewScale;
    }

    public override void Update()
    {
        bool flag = UpdateArrowRotationAndScale();
        if (!flag)
        {
            gm.SetNewState(gm.FreeState);
        }
    }

    private bool UpdateArrowRotationAndScale()
    {
        bool flag = false;
        Vector3 targetScale = Vector3.one * gm.newScale;
        if (Vector3.Distance(targetScale, gm.ArrowAssembly.localScale) > 0.01f)
        {
            gm.ArrowAssembly.localScale = Vector3.Lerp(gm.ArrowAssembly.localScale, targetScale, Time.deltaTime * 1f);
            flag = true;
        }

        Vector3 targetRotation = gm.direction;
        if (Vector3.Distance(targetRotation, gm.ArrowAssembly.right) > 0.01f)
        {
            gm.ArrowAssembly.right = Vector3.Lerp(gm.ArrowAssembly.right, targetRotation, Time.deltaTime * 9f);
            flag = true;
        }
        return flag;
    }
}
