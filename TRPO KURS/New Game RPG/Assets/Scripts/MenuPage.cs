using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CanvasGroup))]
public class MenuPage : MonoBehaviour
{
    private CanvasGroup canvasgroup;

    void Start()
    {
        canvasgroup = GetComponent<CanvasGroup>();
    }
    public void Show()
    {
        canvasgroup.alpha = 1f;
        canvasgroup.interactable = true;
        canvasgroup.blocksRaycasts = true;
    }

    public void Hide()
    {
        canvasgroup.alpha = 0f;
        canvasgroup.interactable = false;
        canvasgroup.blocksRaycasts = false;
    }
}
