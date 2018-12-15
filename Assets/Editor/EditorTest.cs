using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using UnityEditor;
using UnityEngine.EventSystems;

[CustomEditor(typeof(SineAnimation)), CanEditMultipleObjects]
public class SineAnimationEditor : Editor//, IScrollHandler
{
    private float age;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Randomize Sine Function", EditorStyles.whiteLabel))
        {
            serializedObject.FindProperty("m_Period").floatValue = Random.Range(0f, 10f);
            serializedObject.FindProperty("m_Amplitude").floatValue = Random.Range(0f, 10f);
            serializedObject.FindProperty("m_PhaseShift").floatValue = Random.Range(0f, 1f);
            serializedObject.ApplyModifiedProperties();
        }
    }

    private void OnSceneGUI()
    {
        Event e = Event.current;
        Debug.Log(e.keyCode);
        Debug.Log(e.character);
        Debug.Log(e.pressure);
        Debug.Log(e.button);
        Debug.Log(e.modifiers);
        Debug.Log(e.type);
        Debug.Log(e.rawType);

        GUILayout.BeginArea(new Rect(100, 100, 100, 100));
        //GUILayout.Label("joifoweiiiiiiiiiiiiiiiiiiiiiiiojwejfoj");
        //GUILayout.TextField("age");
        //age = EditorGUILayout.FloatField(/*"Age",*/ age/*, GUIStyle.none*/);
        //if (GUILayout.Button("改变之"))
        //{
        //    Debug.Log(age);
        //}
        //GUILayout.EndArea();
    }

    [InitializeOnLoadMethod]
    private static void Init()
    {
        //SceneView.onSceneGUIDelegate += OnSceneGUI;
    }

    private static void OnSceneGUI(SceneView sceneView)
    {
        Event e = Event.current;
        if (e != null && e.button == 1 && e.type == EventType.MouseUp)
        {
            //右键单击啦，在这里显示菜单
            GenericMenu menu = new GenericMenu();
            menu.AddItem(new GUIContent("菜单项1"), false, OnMenuClick, "menu_1");
            menu.AddItem(new GUIContent("菜单项2"), false, OnMenuClick, "menu_2");
            menu.AddItem(new GUIContent("菜单项3"), false, OnMenuClick, "menu_3");
            menu.ShowAsContext();
        }
    }

    private static void OnMenuClick(object userData)
    {
        //EditorUtility.DisplayDialog("Tip", "OnMenuClick" + userData.ToString(), "Ok");
    }
}

internal static class Example2
{
    [MenuItem("Edit/Reset Selected Objects Position")]
    private static void ResetPosition()
    {
        //var transforms = Selection.gameObjects.Select(go => go.transform).ToArray();
        //var so = new SerializedObject(transforms);
        //// you can Shift+Right Click on property names in the Inspector to see their paths
        //so.FindProperty("m_LocalPosition").vector3Value = Vector3.zero;
        //so.ApplyModifiedProperties();

        var go = Selection.activeGameObject;
        var ao = go.GetComponent<StatePatternExample5.StatePatternExample5>();
        var so = new SerializedObject(ao);
        so.FindProperty("m_HAge").intValue = 500;
        so.ApplyModifiedProperties();
    }
}