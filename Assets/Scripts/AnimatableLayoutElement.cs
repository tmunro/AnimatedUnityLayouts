using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
[ExecuteInEditMode]
public class AnimatableLayoutElement : LayoutElement
{
    [SerializeField] private float m_PercentagePreferredHeight = 0.5f;
    [SerializeField] private float m_PercentagePreferredWidth = 0.5f;

    private LayoutGroup m_Group;
    protected LayoutGroup layoutGroup
    {
        get
        {
            if (m_Group == null)
                m_Group = GetComponent<LayoutGroup>();
            return m_Group;
        }
    }

    public override float preferredHeight { get { return layoutGroup.preferredHeight * m_PercentagePreferredHeight; } }
    public override float preferredWidth { get { return layoutGroup.preferredWidth * m_PercentagePreferredWidth; } }
    public override float minHeight { get { return layoutGroup.minHeight * m_PercentagePreferredHeight; } }
    public override float minWidth { get { return layoutGroup.minWidth * m_PercentagePreferredWidth; } }
    public override float flexibleWidth { get { return layoutGroup.flexibleWidth * m_PercentagePreferredWidth; } }

    public override int layoutPriority { get { return 100; } }
}
