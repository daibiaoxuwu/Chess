using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{

    void OnSceneGUI()
    {
        MapGenerator mg = target as MapGenerator;

        if (Handles.Button(mg.transform.position + Vector3.up * 5, Quaternion.LookRotation(Vector3.up), 1, 1, Handles.CylinderHandleCap))
        {
            mg.Generate();
        }
    }
}
