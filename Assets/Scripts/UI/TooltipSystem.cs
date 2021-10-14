using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem current;
    public Tooltip tooltip;
    public Ease animEaseList;
    public void Awake()
    {
        current = this;
    }

    private void Start()
    {
        //Hide();
    }

    public static void Show(string content, string header = "")
    {
        //current.tooltip.gameObject.SetActive(true);
        current.tooltip.transform.DOScale(0, 0.25f)
            .SetEase(Ease.InOutQuart)
            .OnStepComplete(() =>
            {
                current.tooltip.SetText(content, header);
                current.tooltip.transform.DOScale(1, 0.4f).SetEase(Ease.InOutQuart);
            });
        //current.tooltip.SetText(content, header);
        //current.tooltip.gameObject.SetActive(true);
    }
    public static void Hide()
    {
        current.tooltip.transform.DOScale(0, 0.25f)
            .SetEase(Ease.InOutQuart)
            .OnStepComplete(()=>
        {
            //current.tooltip.gameObject.SetActive(false);
        });
        
    }
}
