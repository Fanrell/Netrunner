using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyBehavior))]
public class EnemyEditor : Editor
{   
    EnemyBehavior enemy;
    public override void OnInspectorGUI()
    {
        enemy = (EnemyBehavior)target;
        serializedObject.Update();
        GUILayout.Label("HP: ");
        enemy.maxhp = Convert.ToInt32(EditorGUILayout.Slider(enemy.maxhp,1,10));
        GUILayout.Label("Speed: ");
        enemy.speed = EditorGUILayout.Slider(enemy.speed,1,10);
        GUILayout.Label("Distance of Sight: ");
        enemy.distance = EditorGUILayout.Slider(enemy.distance, 1, 15);
        GUILayout.Label("Period between shoots ");
        enemy.periodShoot = EditorGUILayout.Slider(enemy.periodShoot, 1, 10);
        GUILayout.Label("Patrols points");
        EditorGUILayout.PropertyField(serializedObject.FindProperty("pointsList"),true);
        serializedObject.ApplyModifiedProperties();
        
        
    }


}
