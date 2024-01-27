using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LSystem))]
public class LSystemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LSystem lSystem = (LSystem)target;

        DrawDefaultInspector();

        GUILayout.Space(10);

        if (GUILayout.Button("Add Rule"))
        {
            lSystem.Rules.Add(new LSystemRule());
        }

        GUILayout.Space(10);

        if (GUILayout.Button("Generate"))
        {
            lSystem.Generate();
        }
    }
}
