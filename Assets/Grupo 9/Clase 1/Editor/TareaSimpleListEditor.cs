using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TareaSimpleList))]
public class TareaSimpleListEditor : Editor
{
    public static string input = "Input";


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        TareaSimpleList tester = target as TareaSimpleList;

        // ---

        EditorGUILayout.LabelField("-- List management --");

        input = EditorGUILayout.TextField(input);

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Add Item"))
        {
            tester.AddItem(input);
        }

        if (GUILayout.Button("Remove Item"))
        {
            tester.RemoveItem(input);
        }

        if (GUILayout.Button("Add Range"))
        {
            tester.AddRange(input.Split(", "));
        }

        EditorGUILayout.EndHorizontal();
    }
}
