using UnityEngine;
using UnityEngine.UI;
using UnityEditor.AnimatedValues;

using UnityEditor;

[CustomEditor(typeof(AnimatableLayoutElement), true)]
[CanEditMultipleObjects]
public class AnimatableLayoutElementEditor : UnityEditor.UI.LayoutElementEditor
{
	SerializedProperty m_PercentagePreferredWidth;
	SerializedProperty m_PercentagePreferredHeight;

	protected override void OnEnable()
	{
		m_PercentagePreferredWidth = serializedObject.FindProperty("m_PercentagePreferredWidth");
		m_PercentagePreferredHeight = serializedObject.FindProperty("m_PercentagePreferredHeight");

		base.OnEnable();
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.PropertyField(m_PercentagePreferredWidth);
		EditorGUILayout.PropertyField(m_PercentagePreferredHeight);
		serializedObject.ApplyModifiedProperties();
		base.OnInspectorGUI();
	}

}
