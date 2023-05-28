using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Striker : MonoBehaviour
{
    [SerializeField]private SpriteRenderer _renderer;
    [SerializeField]private GameObject _TouchAssistant;

    public void CanTakeShot()
    {
        _renderer.color = Color.yellow;
    }
    public void CanNotTakeShot()
    {
        _renderer.color = Color.red;
    }
    public void DisableTouchAssist()
    {
        _TouchAssistant.SetActive(false);
        _renderer.enabled = false;
    }
    public void EnableTouchAssist()
    {
        _TouchAssistant.SetActive(true);
        _renderer.enabled = true;
    }
    public void EnableRenderer()
    {
        _renderer.enabled = true;
    }
    public void DisableRenderer()
    {
        _renderer.enabled = false;
    }
}
