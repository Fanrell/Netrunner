using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerBehavior))]
public class PlayerEditor : Editor
{
   public override void OnInspectorGUI()
   {
      PlayerBehavior player = (PlayerBehavior)target;
      EditorGUILayout.LabelField("Max HP");
      player.maxhp = System.Convert.ToInt32(EditorGUILayout.Slider(player.maxhp, 1,10));
      EditorGUILayout.LabelField("Max Ammo");
      player.maxamo = System.Convert.ToInt32(EditorGUILayout.Slider(player.maxamo, 1,100));
      EditorGUILayout.LabelField("Szybkość poruszania się");
      player.speed = EditorGUILayout.Slider(player.speed, 1,10);
      EditorGUILayout.LabelField("Wysokość skoku");
      player.wysokoscSkoku = EditorGUILayout.Slider(player.wysokoscSkoku, 1,10);
      EditorGUILayout.LabelField("Prędkość biegu");
      player.predkoscBiegania = EditorGUILayout.Slider(player.predkoscBiegania, 1,10);
      EditorGUILayout.LabelField("Czułość myszki");
      player.czuloscMyszki = EditorGUILayout.Slider(player.czuloscMyszki, 1,5);
      EditorGUILayout.LabelField("Zakres rozglądania się Góra / Dół");
      player.zakresMyszyGoraDol = EditorGUILayout.Slider(player.zakresMyszyGoraDol, 1,90);
   }
}
