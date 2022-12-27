using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

// Remove [CreateAssetMenu] when you've created an instance, because you don't need more than one.
[CreateAssetMenu(menuName = "Tinker/PrefabManager")]
public class PrefabManager : ScriptableObject
{
#if UNITY_EDITOR
    public GameObject TDropdown;
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(PrefabManager))]
public class PrefabManagerSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.HelpBox("If you move this file somewhere else, also change the path in UiLibraryMenus! ", MessageType.Info);
    }
}
#endif