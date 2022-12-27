using UnityEditor;
using UnityEngine;
using System;

public static class UiLibraryMenus
{
    private const int MenuPriority = 50;

    private const string PrefabManagerPath = "Assets/Main/ScriptableObjects/DropdownPrefabManager.asset";

    private static PrefabManager LocatePrefabManager() => AssetDatabase.LoadAssetAtPath<PrefabManager>(PrefabManagerPath);

    private static void SafeInstantiate(Func<PrefabManager, GameObject> itemSelector)
    {
        var prefabManager = LocatePrefabManager();

        if (!prefabManager)
        {
            Debug.LogWarning($"PrefabManager not found at path {PrefabManagerPath}");
            return;
        }

        var item = itemSelector(prefabManager);
        var instance = PrefabUtility.InstantiatePrefab(item, Selection.activeTransform);

        Undo.RegisterCreatedObjectUndo(instance, $"Create {instance.name}");
        Selection.activeObject = instance;
    }

    [MenuItem("GameObject/UI/Tinker/DropdownCustom", priority = MenuPriority)]
    private static void CreateButton()
    {
        SafeInstantiate(prefabManager => prefabManager.TDropdown);
    }
}