using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BoardCreator))]
public class BoardCreatorInspector : Editor 
{
	public BoardCreator Current
	{
		get
		{
			return (BoardCreator)target;
		}
	}

	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector();
		
		if (GUILayout.Button("Clear"))
			Current.Clear();
		if (GUILayout.Button("Grow"))
			Current.Grow();
		if (GUILayout.Button("Shrink"))
			Current.Shrink();
		if (GUILayout.Button("Grow Area"))
			Current.GrowArea();
		if (GUILayout.Button("Shrink Area"))
			Current.ShrinkArea();
		if (GUILayout.Button("Save"))
			Current.Save();
		if (GUILayout.Button("Load"))
			Current.Load();
		
		if (GUI.changed)
			Current.UpdateMarker ();
	}
}
