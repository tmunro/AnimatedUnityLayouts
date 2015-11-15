using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RectTransform))]
[ExecuteInEditMode]
public class AnimatableVerticalLayoutGroup : VerticalLayoutGroup
{
    public bool active = true;
    // protected override void OnEnable()
    // {
    //     SetLayoutVertical();
    //     CalculateLayoutInputVertical();
    //     SetLayoutVertical();
    //
    // }
    // protected override void OnDisable()
    // {
    //     CalculateLayoutInputVertical();
    //     // CalculateLayoutInputVertical();
    //     // CalculateLayoutInputVertical();
    //     // CalculateLayoutInputVertical();
    //     SetLayoutVertical();
    //     // SetLayoutVertical();
    //     // SetLayoutVertical();
    //     // SetLayoutVertical();
    //
    //
    //     // base.OnDisable();
    // }
    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();
        CalcAlongAxis(0, true);
    }

    public override void CalculateLayoutInputVertical()
    {
        CalcAlongAxis(1, true);
    }

    public override void SetLayoutHorizontal()
    {
        if(!active)
            return;
        SetChildrenAlongAxis(0, true);
    }

    public override void SetLayoutVertical()
    {
        Debug.Log("SetLayoutVertical called, active is "+active);

        if(!active)
            return;
        SetChildrenAlongAxis(1, true);
    }

    protected override void OnEnable()
    {
        // LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
        //
        StartCoroutine(CalculateLayout());
    }
    IEnumerator CalculateLayout()
    {
        yield return new WaitForEndOfFrame();

        var rectTransform = (RectTransform)transform;

        Debug.LogFormat("END OF FRAME preferredHeight: {0} ", preferredHeight);
        Debug.LogFormat("END OF FRAME rect height: {0}", ((RectTransform)transform).rect.size[1]);

        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, preferredHeight);

        CalculateLayoutInputVertical();
        CalculateLayoutInputHorizontal();
        SetChildrenAlongAxis(0, true);
        SetChildrenAlongAxis(1, true);

        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
    }
}
