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
        SetChildrenAlongAxis(0, true);
    }

    public override void SetLayoutVertical()
    {
        if(!_active)
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
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, preferredWidth);

        CalculateLayoutInputVertical();
        CalculateLayoutInputHorizontal();
        SetChildrenAlongAxis(0, true);
        SetChildrenAlongAxis(1, true);

        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
    }
}
