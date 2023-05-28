using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Turn
{
    P1, P2
}

public class NewGameManager : MonoBehaviour
{
    [Header("Components")]
    public Transform Board;
    public Transform Striker;
    public Transform ArrowAssembly;
    public Rigidbody2D StrikerRB;
    public Transform Pucks;
    public RectTransform blackPuckImg;
    public RectTransform WhitePuckImg;

    [Header("CrromAI")]
    public CarromAI CarromAI;

    [Header("UI")]
    public Text timer;
    public Slider strikerBarSlider;
    public Image Player1Image;
    public Image Player2Image;

    [Header("Animator")]
    public Animator GameOverAnimator;

    [Header("Turn")]
    public Turn turn;

    [Header("ChannelsSO")]
    public ScoreUIUpdateChannelSO blackScoreCh;
    public ScoreUIUpdateChannelSO WhiteScoreCh;

    [Header("Variables")]
    // For Scaling
    // Do not change these values
    public Vector2 StrikerMovRangeX = new Vector2(-1.3247f, 1.3311f);
    public float StrikerTransY = -1.5993f;
    //////////
    public float strechLimitInPixels = 150f;
    public float newScale;
    public Vector2 direction;
    public float val = 5f;
    public List<GameObject> PottedPucks;
    public bool _foul;

    // Finite State Machine
    public BaseStateClass State;
    public IdleState IdleState;
    public ChargeState ChargeState;
    public FreeState FreeState;
    public ScoreUpdateState ScoreUpdateState;
    public AIIdleState AIIdleState;
    public AIChargeState AIChargeState;
    public GameEndState GameEndState;
    
    private int player1score = 0;
    private int player2score = 0;

    public int Player1score { get => player1score; set => player1score = value; }
    public int Player2score { get => player2score; set => player2score = value; }

    [Header("For UI to World cordinates conversion")]
    public Vector3 blackPuckWorldPos;
    public Vector3 whitePuckWorldPos;

    private IEnumerator Coroutine;
    private bool IsCountDownRunning = false;


    private void Awake()
    {
        SetScalesAndInitializeStates();
    }

    void Start()
    {
        InitializeVaraibles();
    }

    void Update()
    {
        State.Update();
    }

    public void SetNewState(BaseStateClass newState)
    {
        State.End();
        State = newState;
        State.Start();
    }

    private void SetScalesAndInitializeStates()
    {
        SetScales();
        IdleState = new IdleState(this);
        ChargeState = new ChargeState(this);
        FreeState = new FreeState(this);
        ScoreUpdateState = new ScoreUpdateState(this);
        AIIdleState = new AIIdleState(this);
        AIChargeState = new AIChargeState(this);
        GameEndState = new GameEndState(this);
    }

    private void InitializeVaraibles()
    {
        Application.targetFrameRate = 90;
        Player1score = 0;
        Player2score = 0;
        IsCountDownRunning = false;
        _foul = false;
        State = IdleState;
        SetNewState(IdleState);
        turn = Turn.P1;
        StartCoroutine(Timer(120));
        PottedPucks = new List<GameObject>();
        Striker.position = new Vector3(0f, StrikerTransY, 0f);
    }

    void SetScales()
    {
        float HalfHorizontalDist = Screen.width * 5.0f / Screen.height;
        float newMultiplier = (HalfHorizontalDist < 3) ? (HalfHorizontalDist / 2.25f) : (4.8f / 4.5f);

        Board.localScale *= newMultiplier;
        StrikerMovRangeX *= newMultiplier;
        Pucks.localScale *= newMultiplier;
        StrikerTransY *= newMultiplier;

        float vetricalDistPerPixel = (10.0f / Screen.height);
        blackPuckWorldPos = blackPuckImg.TransformPoint(Vector3.zero);
        float x2 = (blackPuckWorldPos.x - Screen.width/2f) * vetricalDistPerPixel;
        float y2 = (blackPuckWorldPos.y - Screen.height/2f) * vetricalDistPerPixel;
        blackPuckWorldPos = new Vector3(x2, y2, 0f);

        whitePuckWorldPos = WhitePuckImg.TransformPoint(Vector3.zero);
        x2 = (whitePuckWorldPos.x - Screen.width/2f) * vetricalDistPerPixel;
        y2 = (whitePuckWorldPos.y - Screen.height/2f) * vetricalDistPerPixel;
        whitePuckWorldPos = new Vector3(x2, y2, 0f);
    }

    // Coroutine For 2 minute timer.
    private IEnumerator Timer(int t)
    {
        int _time = t;
        while (_time > 0)
        {
            _time -= 1;
            timer.text = (_time / 60).ToString() + ":" + (_time % 60).ToString();
            yield return new WaitForSecondsRealtime(1f);
        }
        SetNewState(GameEndState);
    }

    public void StartCountDown()
    {
        if (IsCountDownRunning)
        {
            return;
        }
        Coroutine = StrikerCountDown(15f);
        StartCoroutine(Coroutine);
    }
    public void StopCountDown()
    {
        StopCoroutine(Coroutine);
        IsCountDownRunning = false;
    }

    private IEnumerator StrikerCountDown(float t)
    {
        IsCountDownRunning = true;
        float _time = t;
        while (_time > 0)
        {
            _time -= 0.1f;
            if(turn == Turn.P1)
            {
                Player1Image.fillAmount = _time/t;
            }
            else
            {
                Player2Image.fillAmount = _time/t;

            }
            yield return new WaitForSecondsRealtime(0.1f);
        }
        IsCountDownRunning = false;
        SetNewState(ScoreUpdateState);
    }

    public void UpdateScoreUI()
    {
        if(blackScoreCh != null) 
        {
            blackScoreCh.OnEventRaised(Player1score);
        }
        if(WhiteScoreCh != null)
        {
            WhiteScoreCh.OnEventRaised(player2score);
        }
    }

    public void SetTimeScaleToZero()
    {
        Debug.Log("Time Scale = 0");
        Time.timeScale = 0f;
    }
}
