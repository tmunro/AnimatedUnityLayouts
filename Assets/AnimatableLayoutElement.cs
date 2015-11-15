using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
[ExecuteInEditMode]
public class AnimatableLayoutElement : LayoutElement
{
    // protected void Update()
    // {
    //     Debug.LogFormat("UPDATE preferredHeight: {0} ", m_Group.preferredHeight);
    // }
    // protected override void Start()
    // {
    //     Debug.LogFormat("START preferredHeight: {0} ", m_Group.preferredHeight);
    // }
    // protected override void Awake()
    // {
    //     Debug.LogFormat("AWAKE preferredHeight: {0} ", m_Group.preferredHeight);
    // }

    // [SerializeField] private bool m_IgnoreLayout = false;
    // [SerializeField] private float m_MinWidth = -1;
    // [SerializeField] private float m_MinHeight = -1;
    // [SerializeField] private float m_PreferredWidth = -1;
    // [SerializeField] private float m_PreferredHeight = -1;
    // [SerializeField] private float m_FlexibleWidth = -1;
    // [SerializeField] private float m_FlexibleHeight = -1;

    [SerializeField] private float m_PercentagePreferredHeight = 0.5f;
    [SerializeField] private float m_PercentagePreferredWidth = 0.5f;

    // public virtual bool ignoreLayout { get { return m_IgnoreLayout; } set { if (SetPropertyUtility.SetStruct(ref m_IgnoreLayout, value)) SetDirty(); } }
    //
    // public virtual void CalculateLayoutInputHorizontal() { }
    // public virtual void CalculateLayoutInputVertical() { }
    // public virtual float minWidth { get { return m_MinWidth; } set { if (SetPropertyUtility.SetStruct(ref m_MinWidth, value)) SetDirty(); } }
    // public virtual float minHeight { get { return m_MinHeight; } set { if (SetPropertyUtility.SetStruct(ref m_MinHeight, value)) SetDirty(); } }
    // public virtual float preferredWidth { get { return m_PreferredWidth; } set { if (SetPropertyUtility.SetStruct(ref m_PreferredWidth, value)) SetDirty(); } }
    // public virtual float preferredHeight { get { return m_PreferredHeight; } set { if (SetPropertyUtility.SetStruct(ref m_PreferredHeight, value)) SetDirty(); } }
    [SerializeField] private AnimatableVerticalLayoutGroup m_Group;
    protected LayoutGroup layoutGroup
    {
        get
        {
            if (m_Group == null)
            m_Group = GetComponent<AnimatableVerticalLayoutGroup>();
            return m_Group;
        }
    }

    public override float preferredHeight
    {
        get
        {
            return m_Group.preferredHeight * m_PercentagePreferredHeight;
        }
    }
    public override float minHeight { get { return m_Group.minHeight * m_PercentagePreferredHeight; } }
    // public virtual float flexibleWidth { get { return m_FlexibleWidth; } set { if (SetPropertyUtility.SetStruct(ref m_FlexibleWidth, value)) SetDirty(); } }
    // public virtual float flexibleHeight { get { return m_FlexibleHeight; } set { if (SetPropertyUtility.SetStruct(ref m_FlexibleHeight, value)) SetDirty(); } }
    public override int layoutPriority { get { return 100; } }
    //
    //
    //     protected LayoutElement()
    //     { }
    //
    //     #region Unity Lifetime calls
    //
    //     protected override void OnEnable()
    //     {
    //         base.OnEnable();
    //         SetDirty();
    //     }
    //
    //     protected override void OnTransformParentChanged()
    //     {
    //         SetDirty();
    //     }
    //
    //     protected override void OnDisable()
    //     {
    //         SetDirty();
    //         base.OnDisable();
    //     }
    //
    //     protected override void OnDidApplyAnimationProperties()
    //     {
    //         SetDirty();
    //     }
    //
    //     protected override void OnBeforeTransformParentChanged()
    //     {
    //         SetDirty();
    //     }
    //
    //     #endregion
    //
    //     protected void SetDirty()
    //     {
    //         if (!IsActive())
    //             return;
    //         LayoutRebuilder.MarkLayoutForRebuild(transform as RectTransform);
    //     }
    //
    // #if UNITY_EDITOR
    //     protected override void OnValidate()
    //     {
    //         SetDirty();
    //     }
    //
    // #endif
}
