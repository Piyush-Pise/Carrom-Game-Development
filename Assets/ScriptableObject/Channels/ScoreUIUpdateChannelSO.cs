using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/New UI Point Update Event Channel")]
public class ScoreUIUpdateChannelSO : ScriptableObject
{
    public UnityAction<int> OnEventRaised;

    public void RaiseEventint(int newValue)
    {
        OnEventRaised?.Invoke(newValue);
    }
}