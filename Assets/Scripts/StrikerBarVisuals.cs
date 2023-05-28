using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrikerBarVisuals : MonoBehaviour
{
    [SerializeField]private Image _BGRenderer;
    [SerializeField]private Image _HandleRenderer;
    
    private Color disableColor = new Color(1f,1f,1f,0.57f);

    public void EnableStrikerBar()
    {
        _BGRenderer.color = Color.white;
        _HandleRenderer.color = Color.white;
    }

    public void DisableStrikerBar()
    {
        _BGRenderer.color = disableColor;
        _HandleRenderer.color = disableColor;
    }
}
