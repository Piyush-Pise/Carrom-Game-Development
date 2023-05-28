using UnityEngine;
using UnityEngine.UI;

public class ScoreUIUpdater : MonoBehaviour
{
    public ScoreUIUpdateChannelSO scoreUIUpdateChannelSO;
    private Text _scoreText;
    void Start()
    {
        if(_scoreText == null)
        {
            _scoreText = GetComponent<Text>();
            _scoreText.text = "0";
        }
    }

    void OnEnable() => scoreUIUpdateChannelSO.OnEventRaised += UpdateValue;
    void OnDisable() => scoreUIUpdateChannelSO.OnEventRaised -= UpdateValue;

    void UpdateValue(int newValue) => _scoreText.text = newValue.ToString();
}
