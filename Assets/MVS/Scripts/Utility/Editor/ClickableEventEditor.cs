using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[CustomEditor(typeof(ClickableEvent))]
public class ClickableEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.backgroundColor = Color.red;
        if (GUILayout.Button("Call event", GUILayout.MinHeight(50)))
        {
            (serializedObject.FindProperty("_event").GetUnderlyingValue() as UnityEvent).Invoke();
        }
    }
}
