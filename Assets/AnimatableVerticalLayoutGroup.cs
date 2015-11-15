using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RectTransform))]
[ExecuteInEditMode]
public class AnimatableVerticalLayoutGroup : VerticalLayoutGroup
{
    public bool active = true;

    public override void SetLayoutHorizontal()
    {
        if(!active)
            return;
        SetChildrenAlongAxis(0, true);
    }

    public override void SetLayoutVertical()
    {
        if(!active)
            return;
        SetChildrenAlongAxis(1, true);
    }

    protected override void OnEnable()
    {
        StartCoroutine(CalculateLayout());
    }
    IEnumerator CalculateLayout()
    {
        yield return new WaitForEndOfFrame();

        var rectTransform = (RectTransform)transform;

        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, preferredHeight);

        CalculateLayoutInputVertical();
        CalculateLayoutInputHorizontal();
        SetChildrenAlongAxis(0, true);
        SetChildrenAlongAxis(1, true);

        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
    }
}
