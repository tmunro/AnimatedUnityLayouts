using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RectTransform))]
[ExecuteInEditMode]
public class AnimatableHorizontalLayoutGroup : HorizontalLayoutGroup
{
    [SerializeField]
    protected bool _active = true;

    public override void SetLayoutHorizontal()
    {
        if(!_active)
            return;
        SetChildrenAlongAxis(0, false);
    }

    public override void SetLayoutVertical()
    {
        if(!_active)
            return;
        SetChildrenAlongAxis(1, false);
    }

    protected override void OnEnable()
    {
        StartCoroutine(CalculateLayout());
    }
    IEnumerator CalculateLayout()
    {
        yield return new WaitForEndOfFrame();

        var rectTransform = (RectTransform)transform;
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, preferredWidth);

        CalculateLayoutInputVertical();
        CalculateLayoutInputHorizontal();
        SetChildrenAlongAxis(0, false);
        SetChildrenAlongAxis(1, false);

        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
    }
}
